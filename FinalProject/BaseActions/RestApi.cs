using FinalProject.Utilities;
using FinalProject.Utilities.Reporting;
using Newtonsoft.Json.Linq;
using OpenQA.Selenium;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using Cookie = System.Net.Cookie;

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
        [Obsolete]
        public RestResponseCookie cookie = new RestResponseCookie();
        JObject obs;
        public string contentAsString;


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
           //     Request.AddCookie("JSESSIONID", "");
                 var content = Client.Execute(Request);
                obs = JObject.Parse(content.Content);
                IReportMng.IReporter.WriteToLog(IReportUtil.Status.Pass,
                    "The Request: " + InputRequestPath + " of type:'GET' was sent to the server and the server responded with ok 200 successfuly");
                return obs;
            }
            catch (Exception e)
            {
                IReportMng.IReporter.WriteToLog(IReportUtil.Status.Fail,
                    "The Request: " + InputRequestPath + " of type:'GET' was sent to the server and the server responded with an error massage: " + obs.ToString() , e, driver);
            }
            return null;
        }

        public IRestResponse login(string InputUrl, string InputRequestPath)
        {
            try
            {
                Client = new RestClient(InputUrl);

                Request = new RestRequest(InputRequestPath, Method.GET);
                //     Request.AddCookie("JSESSIONID", "");
                var content = Client.Execute(Request);
             //   obs = JObject.Parse(content.Content);
                IReportMng.IReporter.WriteToLog(IReportUtil.Status.Pass,
                    "The Request: " + InputRequestPath + " of type:'GET' was sent to the server and the server responded with ok 200 successfuly");
                return content;
            }
            catch (Exception e)
            {
                IReportMng.IReporter.WriteToLog(IReportUtil.Status.Fail,
                    "The Request: " + InputRequestPath + " of type:'GET' was sent to the server and the server responded with an error massage: " + obs.ToString(), e, driver);
            }
            return null;
        }

        public JObject GetFromServerJObject(string InputUrl, string InputRequestPath, string headerName, string headerValue)
        {
            try
            {
                Client = new RestClient(InputUrl);

                Request = new RestRequest(InputRequestPath, Method.GET);
                Request.AddHeader(headerName, headerValue);
                var content = Client.Execute(Request);
                obs = JObject.Parse(content.Content);
                IReportMng.IReporter.WriteToLog(IReportUtil.Status.Pass,
                    "The Request: " + InputRequestPath + " of type:'GET' was sent to the server and the server responded with ok 200 successfuly");
                return obs;
            }
            catch (Exception e)
            {
                IReportMng.IReporter.WriteToLog(IReportUtil.Status.Fail,
                    "The Request: " + InputRequestPath + " of type:'GET' was sent to the server and the server responded with an error massage: " + obs.ToString(), e, driver);
            }
            return null;
        }

        public string  GetCookieFromServer(string InputUrl)
        {
            Client = new RestClient(InputUrl);

            Request = new RestRequest(InputUrl, Method.GET);
         
            var content = Client.Execute(Request);
            cookie = content.Cookies.First();
            string coockiName = cookie.Name;
            string coockiValue = cookie.Value;
            IReportMng.IReporter.WriteToLog(IReportUtil.Status.Info,
                   "Cookie: " + coockiName + " = " + coockiValue + " was found and stored");
            return coockiName+ "=" +coockiValue;
           

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
                var shay = InputValue_Header.Substring(11);
                Request.AddCookie("JSESSIONID", shay);
                Request.AddHeader(InputName_Header, InputValue_Header);
                Request.AddHeader("Content-Type", "application/json");
                Request.AddHeader("Accept", "application/json");

                //     Request.AddJsonBody(InputBody);
                var content = Client.Execute(Request);
                contentAsString = content.Content;
                //   JArray obs = JArray.Parse(content.Content);
                IReportMng.IReporter.WriteToLog(IReportUtil.Status.Pass,
                       "The Request: " + InputRequestPath + "  of type:'POST' was sent to the server and the server responded with messege: " + contentAsString);
                return content;
            }
            catch (Exception e)
            {
                IReportMng.IReporter.WriteToLog(IReportUtil.Status.Fail,
                    "The Request: " + InputRequestPath + "  of type:'POST' was sent to the server and the server responded with an error massage: " + contentAsString, e, driver);
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

