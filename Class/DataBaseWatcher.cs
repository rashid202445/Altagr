using Nancy.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TableEvents.SqlClient;
using TableEvents.SqlClient.Base.Enums;
using TableEvents.SqlClient.Base.EventArgs;
using Twilio;
using Twilio.Rest.Api.V2010.Account;

namespace Altagr.Class
{
    public static class DataBaseWatcher
    {
        public static SqlTableEvents<DAL.tblProducts> Products;
        public static void Products_Changed(object sender, RecordChangedEventArgs<DAL.tblProducts> e)
        {
            Application.OpenForms[0].Invoke(new Action(() =>
            {
                if (e.ChangeType == ChangeType.Insert)
                {
                    Session.Products.Add(e.Entity);
                       Session.ProductsView.Add(Session.ProductViewClass.GetProduct(e.Entity.ID));
                }
                else if (e.ChangeType == ChangeType.Update)
                {
                    var index = Session.Products.IndexOf(Session.Products.Single(x => x.ID == e.Entity.ID));
                    Session.Products.Remove(Session.Products.Single(x => x.ID == e.Entity.ID));
                    Session.Products.Insert(index, e.Entity);

                    var viewIndex = Session.ProductsView.IndexOf(Session.ProductsView.Single(x => x.ID == e.Entity.ID));
                    Session.ProductsView.Remove(Session.ProductsView.Single(x => x.ID == e.Entity.ID));
                    Session.ProductsView.Add(Session.ProductViewClass.GetProduct(e.Entity.ID));
                }
                else if (e.ChangeType == ChangeType.Delete)
                {
                    Session.Products.Remove(Session.Products.Single(x => x.ID == e.Entity.ID));
                    //Session.ProductsView.Remove(Session.ProductsView.Single(x => x.ID == e.Entity.ID));
                }
            }));
        }
        public static SqlTableEvents<DAL.tblAccounts> Accounts;
        public static void Accounts_Changed(object sender, RecordChangedEventArgs<DAL.tblAccounts> e)
        {
            Application.OpenForms[0].Invoke(new Action(() =>
            {
                if (e.ChangeType == ChangeType.Insert)
                {
                    Session.Accounts.Add(e.Entity);
                   // Session.ProductsView.Add(Session.ProductViewClass.GetProduct(e.Entity.ID));
                }
                else if (e.ChangeType == ChangeType.Update)
                {
                    var index = Session.Accounts.IndexOf(Session.Accounts.Single(x => x.ID == e.Entity.ID));
                    Session.Accounts.Remove(Session.Accounts.Single(x => x.ID == e.Entity.ID));
                    Session.Accounts.Insert(index, e.Entity);

                    //var viewIndex = Session.ProductsView.IndexOf(Session.ProductsView.Single(x => x.ID == e.Entity.ID));
                    //Session.ProductsView.Remove(Session.ProductsView.Single(x => x.ID == e.Entity.ID));
                    //Session.ProductsView.Add(Session.ProductViewClass.GetProduct(e.Entity.ID));
                }
                else if (e.ChangeType == ChangeType.Delete)
                {
                    Session.Accounts.Remove(Session.Accounts.Single(x => x.ID == e.Entity.ID));
                    //Session.ProductsView.Remove(Session.ProductsView.Single(x => x.ID == e.Entity.ID));
                }
            }));
        }
        public static SqlTableEvents<DAL.tblReceiving> Receiving;
        public static void Receiving_Changed(object sender, RecordChangedEventArgs<DAL.tblReceiving> e)
        {
            Application.OpenForms[0].Invoke(new Action(() =>
            {
                if (e.ChangeType == ChangeType.Insert)
                {

                 var customer= Session.SMS_CustomersDirectory.SingleOrDefault(s => s.AccountID == e.Entity.ExchangeAccountID);
                    if(customer != null)
                    if (customer.notificationsReceiving )
                    {
                        //  SendSMS(customer.MobileNumbers, "");
                        string msg = "تمت عملية قبض لحساب " + Session.Accounts.SingleOrDefault(x => x.ID== e.Entity.ExchangeAccountID).AccountName + " بمبلغ : " + Convert.ToDouble(e.Entity.Amount) + " " +new DAL.dbDataContext().tblCurrencies.Single(z => z.ID== e.Entity.CurrencyID).CurrencyName;

                            //  string s = SendSMS(customer.MobileNumbers, msg);
                         //   new Sms().sensSms(customer.MobileNumbers, msg);

                         //   Task<string> task = new Sms().GetAPIReponse(customer.MobileNumbers, msg);
                         //   var ds = task.Status;
                            Session.Response.Add("حالة الرسالة : "+ new Sms().sensSms(customer.MobileNumbers, msg) + "الرسالة "+msg);
                    }

                }
            }));
        }
        public static SqlTableEvents<DAL.tblSpending> Spending;
        public static void Spending_Changed(object sender, RecordChangedEventArgs<DAL.tblSpending> e)
        {
            Application.OpenForms[0].Invoke(new Action(() =>
            {
                if (e.ChangeType == ChangeType.Insert)
                {

                    var customer = Session.SMS_CustomersDirectory.SingleOrDefault(s => s.AccountID == e.Entity.ExchangeAccountID);
                    if (customer.notificationsSpending)
                    {
                        SendSMS(customer.MobileNumbers, "");
                    }

                }
            }));
        }
        public static SqlTableEvents<DAL.vewReceiving> vewReceivings;
        public static void vewReceivings_Changed(object sender, RecordChangedEventArgs<DAL.vewReceiving> e)
        {
            Application.OpenForms[0].Invoke(new Action(() =>
            {
                if (e.ChangeType == ChangeType.Insert)
                {

                    var customer = Session.SMS_CustomersDirectory.SingleOrDefault(s => s.AccountID == e.Entity.ExchangeAccountID);
                    if (customer.notificationsSpending)
                    {
                        string msg = "تمت عملية قبض لحساب " + e.Entity.اسم_الحساب + " بمبلغ : " + Convert.ToDouble(e.Entity.المبلغ) + " " + e.Entity.العملة;
                    
                   //   int  num = s.IndexOf("date_created:") + "date_created:".Length;
                   //int   num2 = s.LastIndexOf("=user");
                   //string str3 = s.Substring(num, num2 - num);
                    }

                }
            }));
        }
        public static SqlTableEvents<DAL.tblSMS_CustomersDirectory> SMS_CustomersDirectorys;
        public static void SMS_CustomersDirectorys_Changed(object sender, RecordChangedEventArgs<DAL.tblSMS_CustomersDirectory> e)
        {
            Application.OpenForms[0].Invoke(new Action(() =>
            {
                if (e.ChangeType == ChangeType.Insert)
                {
                    Session.SMS_CustomersDirectory.Add(e.Entity);
                }
                else if (e.ChangeType == ChangeType.Update)
                {
                    var index = Session.SMS_CustomersDirectory.IndexOf(Session.SMS_CustomersDirectory.Single(x => x.ID == e.Entity.ID));
                    Session.SMS_CustomersDirectory.Remove(Session.SMS_CustomersDirectory.Single(x => x.ID == e.Entity.ID));
                    Session.SMS_CustomersDirectory.Insert(index, e.Entity);
                }
                else if (e.ChangeType == ChangeType.Delete)
                {
                    Session.SMS_CustomersDirectory.Remove(Session.SMS_CustomersDirectory.Single(x => x.ID == e.Entity.ID));
                }
            }));
        }

        static string SendSMS(string mobile,string content)
        {

            //	ALSayagih
            //f7a7ad50d16467f60f10b9f5da969750

            var client = new RestClient("https://api.releans.com/v2/message");
            client.Timeout = -1;
            var request = new RestRequest(Method.POST);
            request.AddHeader("Authorization", "f7a7ad50d16467f60f10b9f5da969750");
            request.AddParameter("sender", "ALSayagih");
            request.AddParameter("mobile", "+967"+mobile);
            request.AddParameter("content",content);

            IRestResponse response = client.Execute(request);
            Console.WriteLine(response.Content);
            return response.Content;
            //            {
            //                "api_version": "2021-01-02",
            //  "message": "Your message sent.",
            //  "id": "kpPy7LDdw2Nvmb1YKXAxljV",
            //  "from": "SMS",
            //  "to": "+14155550101",
            //  "region": "United States",
            //  "operator": "null",
            //  "date_created": "2021-01-08 03:47:18 pm",
            //  "date_sent": "2021-01-08 03:47:18 pm",
            //  "dlr_status": "sent",
            //  "status_description": null,
            //  "timezone": "America/Toronto",
            //  "price": 0.01,
            //  "price_unit": "USD",
            //  "code": 77,
            //  "status": 201
            //}
        }
        
    }
   public class Sms
    {
        public async Task<string> GetAPIReponse(string mobile, string content)
        {
            Dictionary<string, string> fields = new Dictionary<string, string>();
            fields.Add("sender", "ALSayagih");
            fields.Add("mobile", "+967"+mobile);
            fields.Add("content", content);

            var serializer = new JavaScriptSerializer();
            var serializedResult = serializer.Serialize(fields);
            var data = new StringContent(serializedResult, Encoding.UTF8, "application/json");

            var httpclient = new HttpClient();
            httpclient.DefaultRequestHeaders.Add("Authorization", "Bearer f7a7ad50d16467f60f10b9f5da969750");
            var response = await httpclient.PostAsync("https://api.releans.com/v2/message", data);
            string page = response.Content.ReadAsStringAsync().Result;

            return page;
        }
        public string sensSms(string mobile, string content)
        {
            // Find your Account SID and Auth Token at twilio.com/console
            // and set the environment variables. See http://twil.io/secure
            string accountSid = Environment.GetEnvironmentVariable("AC6985e4abb3c52de099711885557a9541");
            string authToken = Environment.GetEnvironmentVariable("4a0597c4090b1f1563a01dd2d104820d");

            TwilioClient.Init(accountSid, authToken);

            var message = MessageResource.Create(
                body: content,
                from: new Twilio.Types.PhoneNumber("+13202333399"),
                to: new Twilio.Types.PhoneNumber("+967778382806")
            );

            Console.WriteLine(message.Sid);
            return message.Sid + "  ";
        }
    }
}
