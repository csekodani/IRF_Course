using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace IRF_Project_Work
{
    public static class Api_Helper
    {
        public static HttpClient ApiClient { get; set; }  //make it static because we want to open it once per application

        public static void InitializeClient()
        {
            ApiClient = new HttpClient();
            ApiClient.DefaultRequestHeaders.Accept.Clear();
            ApiClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/xml")); //we want xml response

        }
    }
}
