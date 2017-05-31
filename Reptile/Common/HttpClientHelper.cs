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
        private HttpClient _HttpClient = new HttpClient();

        private const int _RedirectMaxCount = 20;

        public string GetRedirectUrl(string url)
        {
            HttpResponseMessage responseMessage = _HttpClient.GetAsync(url).Result;

            if(responseMessage.StatusCode!=HttpStatusCode.Redirect)
            {
                return null;
            }

            return responseMessage.Headers.Location.ToString();
        }

        public string Request(string url)
        {
            return Request(url,null);
        }

        public string Request(string url,int? loopCount=null)
        {
            string result = null;

            HttpResponseMessage responseMessage = _HttpClient.GetAsync(url).Result;

            switch(responseMessage.StatusCode)
            {
                case HttpStatusCode.OK:
                    result = responseMessage.Content.ReadAsStringAsync().Result;
                    break;
                case HttpStatusCode.Redirect:
                    if (loopCount == null)
                        result=Request(responseMessage.Headers.Location.ToString(),_RedirectMaxCount);
                    else if(loopCount>0)
                    {
                        result = Request(responseMessage.Headers.Location.ToString(), loopCount - 1);
                    }
                    break;
                default:
                    throw new Exception($"请求错误:{responseMessage.StatusCode} 详细内容:{responseMessage.Content.ReadAsStringAsync().Result}");
            }

            return result;
        }
    }
}
