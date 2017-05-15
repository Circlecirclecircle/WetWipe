using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.IO;
using System.Net.Http;

namespace Common
{
    public class HttpHelper
    {
        public string Request(string url)
        {
            HttpWebResponse response = _Request(url);
            //这里要把HttpCode 为302 的Response 处理一下

            string result = null;
            switch (response.StatusCode)
            {
                case HttpStatusCode.OK:
                    result = ReadResponse(response);
                    break;
                case HttpStatusCode.Redirect: //重定向
                    int i = 0;
                    HttpWebResponse tempResponse = response;
                    while (i < 10)
                    {
                        string u = tempResponse.Headers["Location"];
                        tempResponse = _Request(u);

                        if (tempResponse.StatusCode != HttpStatusCode.Redirect)
                            break;

                        i++;
                    }
                    if (i == 10)
                        throw new Exception($"HttpStatusCode:{HttpStatusCode.Redirect} 10次跳转 截断 Url:{url}");
                    break;
                default:
                    throw new Exception($"HttpStatusCode:{response.StatusCode} Url:{url}");
            }

            response.Dispose();

            return result;
        }

        private HttpWebResponse _Request(string url)
        {
            HttpWebRequest request = WebRequest.CreateHttp(url);

            //request.AllowAutoRedirect = true;

            HttpWebResponse response = (HttpWebResponse)request.GetResponseAsync().Result;

            return response;
        }

        private string ReadResponse(HttpWebResponse response)
        {
            string result = null;
            using (Stream responseStream = response.GetResponseStream())
            using (StreamReader reader = new StreamReader(responseStream))
            {
                result = reader.ReadToEnd();
            }

            return result;
        }

        public string GetRedirectUrl(string url)
        {
            var response = _Request(url);

            if (response.StatusCode != HttpStatusCode.Redirect)
                return null;

            string redirectUrl = response.Headers["Location"]?.ToString();

            response.Dispose();

            return redirectUrl;
        }
    }
}
