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

        public JObject GetFromServerJObject(string InputUrl, string InputRequestPath)
        {
            try
            {
                Client = new RestClient(InputUrl);
                Request = new RestRequest(InputRequestPath, Method.GET);
                var content = Client.Execute(Request);
                JObject obs = JObject.Parse(content.Content);
                IReportMng.IReporter.WriteToLog(IReportUtil.Status.Pass,
                    "The Request: " + InputRequestPath + " of type:'GET' was sent to the server and the server responded with ok 200 successfuly");
                return obs;
            }
            catch (Exception e)
            {
                IReportMng.IReporter.WriteToLog(IReportUtil.Status.Fail,
                    "The Request: " + InputRequestPath + " of type:'GET' was sent to the server and the server responded with an error massage", e, driver);
            }
            return null;
        }

        public JArray GetFromServerJArray(string InputUrl, string InputRequestPath)
        {
            try
            {
                Client = new RestClient(InputUrl);
                Request = new RestRequest(InputRequestPath, Method.GET);
                var content = Client.Execute(Request);
                JArray obs = JArray.Parse(content.Content);
                IReportMng.IReporter.WriteToLog(IReportUtil.Status.Pass,
                    "The Request: " + InputRequestPath + "  of type:'GET' was sent to the server and the server responded with ok 200 successfuly");
                return obs;
            }
            catch (Exception e)
            {
                IReportMng.IReporter.WriteToLog(IReportUtil.Status.Fail,
                    "The Request: " + InputRequestPath + "  of type:'GET' was sent to the server and the server responded with an error massage", e, driver);
            }
            return null;
        }

        public IRestResponse SendToServer(string InputUrl, string InputRequestPath, string InputName_Header, string InputValue_Header)
        {
            try
            {
                Client = new RestClient(InputUrl);
                Request = new RestRequest(InputRequestPath, Method.POST);
                Request.AddHeader(InputName_Header, InputValue_Header);
                //     Request.AddJsonBody(InputBody);
                var content = Client.Execute(Request);
                //   JArray obs = JArray.Parse(content.Content);
                IReportMng.IReporter.WriteToLog(IReportUtil.Status.Pass,
                       "The Request: " + InputRequestPath + "  of type:'POST' was sent to the server and the server responded with ok 200 successfuly");
                return content;
            }
            catch (Exception e)
            {
                IReportMng.IReporter.WriteToLog(IReportUtil.Status.Fail,
                    "The Request: " + InputRequestPath + "  of type:'POST' was sent to the server and the server responded with an error massage", e, driver);
            }
            return null;
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

