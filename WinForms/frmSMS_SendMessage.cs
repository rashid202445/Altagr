using Altagr.Class;
using Nancy.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Altagr.WinForms
{
    public partial class frmSMS_SendMessage : frmMasterList
    {
        public frmSMS_SendMessage()
        {
            InitializeComponent();
        }
        void gg()
        {
            //	ALSayagih
            //f7a7ad50d16467f60f10b9f5da969750

            var client = new RestClient("https://api.releans.com/v2/message");
            client.Timeout = -1;
            var request = new RestRequest(Method.POST);
            request.AddHeader("Authorization", "f7a7ad50d16467f60f10b9f5da969750");
            request.AddParameter("sender", "ALSayagih");
            request.AddParameter("mobile", "+14155550101");
            request.AddParameter("content", "Hello");

            IRestResponse response = client.Execute(request);
            Console.WriteLine(response.Content);
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
        private async Task<string> GetAPIReponse()
        {
            Dictionary<string,string> fields = new Dictionary<string, string>();
            fields.Add("sender", "ALSayagih");
            fields.Add("mobile", "+967777700192");
            fields.Add("content", "Hello from Releans API");

            var serializer = new JavaScriptSerializer();
            var serializedResult = serializer.Serialize(fields);
            var data = new StringContent(serializedResult, Encoding.UTF8, "application/json");

            var httpclient = new HttpClient();
            httpclient.DefaultRequestHeaders.Add("Authorization", "Bearer f7a7ad50d16467f60f10b9f5da969750");
            var response = await httpclient.PostAsync("https://api.releans.com/v2/message", data);
            string page = response.Content.ReadAsStringAsync().Result;

            return page;
        }

        private void frmSMS_SendMessage_Load(object sender, EventArgs e)
        {
            RefreshData();
            Session.Response.ListChanged += Response_ListChanged;
        }

        private void Response_ListChanged(object sender, ListChangedEventArgs e)
        {
            RefreshData();
      //  Task task=    GetAPIReponse();
        }

        public override void RefreshData()
        {
            gridControl1.DataSource = Session.Response;
            base.RefreshData();
        }
    }
}
