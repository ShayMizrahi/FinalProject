using FinalProject.BaseActions;
using OpenQA.Selenium;


namespace FinalProject.Flows
{
    public class ParaBankApi_flow
    {
        public string custumerDetails = "/accounts/13344";
        public string Transactions = "/accounts/13344/transactions/month/2022-01-23T12%3A38%3A23.155Z/type/CREDIT";
        public string post = "/createAccount?customerId=12345&newAccountType=CHECKING&fromAccountId=500&api_key=shay";
        public string url = "http://parabank.parasoft.com/parabank/services/bank";

        public RestApi restSharp;
        public BasicActions actions;

        public ParaBankApi_flow(IWebDriver driver, RestApi restSharp, BasicActions actions)
        {
            this.restSharp = restSharp;
            this.actions = actions;
        }


        public void api()
        {

            var Acount = restSharp.GetFromeServerJObject(url, "/login/" + 
                ParaBankSite_flow.newUserName + "/" + ParaBankSite_flow.newPassword + "?api_key=12345");

            var firstNameValue = Acount["firstName"].ToString();
            actions.Validation(firstNameValue, "Shay", "firstNameValue");

            var lastNameValue = Acount["lastName"].ToString();
            actions.Validation(lastNameValue, "Mizrahi", "lastNameValue");

            var address = Acount["address"];
            var streetValue = address["street"].ToString();
            actions.Validation(streetValue.ToString(), "Carmel 5", "street");

            var cityValue = address["city"].ToString();
            actions.Validation(cityValue, "Rehovot", "city");

            var stateValue = address["state"].ToString();
            actions.Validation(stateValue, "Israel", "state");

            var phoneNumberValue = Acount["phoneNumber"].ToString();
            actions.Validation(phoneNumberValue, "548013506", "phoneNumber");

            var ssnValue = Acount["ssn"].ToString();
            actions.Validation(ssnValue, "2432", "ssn");

            var ListOfTranscations_Acount = restSharp.GetFromeServerJArray(url, "/accounts/13344/transactions");

        }
        public object data = new
        {
            id = 25,
            employee_name = "Shay Mizrahi",
            employee_salary = 95601,
            employee_age = 36,
            profile_image = ""
        };


    }
}
