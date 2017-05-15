using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Http;
using System.Net;
using Core;

namespace Common
{
    public class HttpClientHelper : IHttpHelper
    {
        public string GetRedirectUrl(string url)
        {
            throw new NotImplementedException();
        }

        public string Request(string url)
        {
            string result = null;

            HttpClient httpClient = new HttpClient();

            HttpResponseMessage responseMessage = httpClient.GetAsync(url).Result;

            switch(responseMessage.StatusCode)
            {
                case HttpStatusCode.OK:
                    result = responseMessage.Content.ReadAsStringAsync().Result;
                    break;
                case HttpStatusCode.Redirect:

                    

                    break;
            }
        }
    }
}
