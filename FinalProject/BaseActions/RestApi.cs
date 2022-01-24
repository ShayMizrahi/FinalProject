using FinalProject.Utilities;
using FinalProject.Utilities.Reporting;
using Newtonsoft.Json.Linq;
using OpenQA.Selenium;
using RestSharp;
using System;


namespace FinalProject.BaseActions
{
    public class RestApi
    {

        public static string request = "/accounts/13344";
        public static string api = "http://parabank.parasoft.com/parabank/services/bank/";
        public RestClient Client;
        public RestRequest Request;
        public IRestResponse Response;
        public IWebDriver driver;

        public RestApi(IWebDriver driver)
        {
            this.driver = driver;
        }

        public JObject GetFromeServerJObject(string InputUrl, string InputRequest)
        {
            try
            {
                Client = new RestClient(InputUrl);
                Request = new RestRequest(InputRequest, Method.GET);
                var content = Client.Execute(Request);
                JObject obs = JObject.Parse(content.Content);
                IReportMng.IReporter.WriteToLog(IReportUtil.Status.Pass,
                    "The Request was send to the server and got back with massage 200 successfuly");
                return obs;
            }
            catch (Exception e)
            {
                IReportMng.IReporter.WriteToLog(IReportUtil.Status.Fail,
                    "The Request was send to the server and got back with  error massage", e, driver);
            }
            return null;
        }

        public JArray GetFromeServerJArray(string InputUrl, string InputRequest)
        {
            try
            {
                Client = new RestClient(InputUrl);
                Request = new RestRequest(InputRequest, Method.GET);
                var content = Client.Execute(Request);
                JArray obs = JArray.Parse(content.Content);
                IReportMng.IReporter.WriteToLog(IReportUtil.Status.Pass,
                    "The Request was send to the server and got back with massage 200 successfuly");
                return obs;
            }
            catch (Exception e)
            {
                IReportMng.IReporter.WriteToLog(IReportUtil.Status.Fail,
                    "The Request was send to the server and got back with  error massage", e, driver);
            }
            return null;
        }

        public JObject SendToServer(string InputUrl, string InputRequest, string InputBody)
        {
            Client = new RestClient(InputUrl);
            Request = new RestRequest(InputRequest, Method.POST);
            Request.AddJsonBody(InputBody);
            var content = Client.Execute(Request);
            JObject obs = JObject.Parse(content.Content);

            return obs;
        }

        public JObject DeleteFromServer(string InputUrl, string InputRequest, string InputBody)
        {
            Client = new RestClient(InputUrl);
            Request = new RestRequest(InputRequest, Method.DELETE);
            Request.AddJsonBody(InputBody);
            var content = Client.Execute(Request);
            JObject obs = JObject.Parse(content.Content);

            return obs;
        }


    }
}

