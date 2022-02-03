using FinalProject.BaseActions;
using FinalProject.Utilities;
using FinalProject.Utilities.Reporting;
using Newtonsoft.Json.Linq;
using OpenQA.Selenium;
using RestSharp;

namespace FinalProject.Flows
{
    public class ParaBankApi_flow
    {
        public string custumerDetails = "/accounts/13344";
        public string Transactions = "/accounts/13344/transactions/month/2022-01-23T12%3A38%3A23.155Z/type/CREDIT";
        public string post = "/createAccount?customerId=12345&newAccountType=CHECKING&fromAccountId=500&api_key=shay";
        public string url = "http://parabank.parasoft.com/parabank/services/bank";
        public string urlPost = "https://parabank.parasoft.com/parabank/services_proxy/bank";
        public string cookieURL = "https://parabank.parasoft.com/parabank/index.htm";
        public string idValue;
        public RestApi restSharp;
        public BasicActions actions;

        public RestClient Client;
        public RestRequest Request;
        public IRestResponse Response;

        public ParaBankApi_flow(IWebDriver driver, RestApi restSharp, BasicActions actions)
        {
            this.restSharp = restSharp;
            this.actions = actions;
        }


        public void api()
        {
            var getCookie = restSharp.GetCookieFromServer(cookieURL);
            string shay = getCookie.ToString();
     //       var getValueCookie = getCookie.Substring(getCookie.Length - 32);


            logIn();

            


            // find the new customer
            var Customer = restSharp.GetFromServerJObject(url, "/login/" +
                ParaBankSite_flow.newUserName + "/" + ParaBankSite_flow.newPassword + "?api_key=12345");

            // validate the fields of customer
            ValidateCusumerFields(Customer, "Shay", "Mizrahi", "Carmel 5", "Rehovot",
                "Israel", "548013506", "548013506");
           
            var idValue = Customer["id"].ToString();
            

            // update the fields of customer
            var UpadteCustomer = restSharp.SendToServer(urlPost, "/customers/update/" + idValue +
                "?firstName=Oron&lastName=Kastel&street=Sirkin 8&city=Givatym&state=Israel&zipCode=75654125&phoneNumber=054857299&ssn=1234&username=" +
                ParaBankSite_flow.newUserName + "&password=" + ParaBankSite_flow.newPassword + "",
                "Cookie", shay);

            // find the customer
            var NewCustomer = restSharp.GetFromServerJObject(url, "/login/" +
               ParaBankSite_flow.newUserName + "/" + ParaBankSite_flow.newPassword + "");

            idValue = NewCustomer["id"].ToString();

            // validate the fields of customer
            ValidateCusumerFields(NewCustomer, "Oron", "Kastel", "Sirkin 8", "Givatym",
                "Israel", "054857299", "1234");




            var CreatNewAcount = restSharp.SendToServer(urlPost, "/createAccount?customerId=" + idValue + "&newAccountType=0&fromAccountId=13566",
                "Cookie", getCookie);
            

            var Acounts = restSharp.GetFromServerJArray(url, "/customers/" + idValue + "/accounts");
            var Acount = Acounts[1];

            ValidateAcountFields(Acount, idValue, "CHECKING", "100");

        }

        public void ValidateCusumerFields(JObject obj, string InputFirstName, string InputLastName, 
            string InputStreet, string InputCity, string InputState, string InputphoneNumber, string InputSsnValue)
        {
            IReportMng.IReporter.CreatNode("Validate customer fields");

            var firstNameValue = obj["firstName"].ToString();
            actions.Validation(firstNameValue, InputFirstName, "firstNameValue");

            var lastNameValue = obj["lastName"].ToString();
            actions.Validation(lastNameValue, InputLastName, "lastNameValue");

            var address = obj["address"];
            var streetValue = address["street"].ToString();
            actions.Validation(streetValue.ToString(), InputStreet, "street");

            var cityValue = address["city"].ToString();
            actions.Validation(cityValue, InputCity, "city");

            var stateValue = address["state"].ToString();
            actions.Validation(stateValue, InputState, "state");

            var phoneNumberValue = obj["phoneNumber"].ToString();
            actions.Validation(phoneNumberValue, InputphoneNumber, "phoneNumber");

            var ssnValue = obj["ssn"].ToString();
            actions.Validation(ssnValue, InputSsnValue, "ssn");
        }

        public void ValidateAcountFields(JToken aryj, string InputCustomerid, string InputType, string InputBalance)
        {
            IReportMng.IReporter.CreatNode("Validate acount fields");
           

            var customeridValue = aryj["customerId"].ToString();
            actions.Validation(customeridValue, InputCustomerid, "customeridValue");

            var typeValue = aryj["type"].ToString();
            actions.Validation(typeValue, InputType, "typeValue");

            var balanceValue = aryj["balance"].ToString();
            actions.Validation(balanceValue, InputBalance, "balanceValue");
        }

        public IRestResponse logIn()
        {
            IReportMng.IReporter.CreatNode("Log-in  api");
            var Customer = restSharp.login("https://parabank.parasoft.com/parabank/login.htm", "?username= +ParaBankSite_flow.newUserName + &password=" + ParaBankSite_flow.newPassword);
            
            return Customer;
        }

        public JObject setParamenters(string inputName, string InputValue)
        {
            IReportMng.IReporter.CreatNode("Set paramenters");
          
            var Customer = restSharp.GetFromServerJObject(url, "/setParameter/" + inputName + "/" + InputValue);

            return Customer;
        }



    }
}
