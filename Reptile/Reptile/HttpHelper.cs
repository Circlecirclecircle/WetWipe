using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.IO;

namespace Reptile
{
    public class HttpHelper
    {
        public static string Request(string url)
        {
            HttpWebResponse response = _Request(url);
            //这里要把HttpCode 为302 的Response 处理一下

            string result = null;
            switch(response.StatusCode)
            {
                case HttpStatusCode.OK:
                    result=ReadResponse(response);
                    break;
                case HttpStatusCode.Redirect: //重定向
                    int i = 0;
                    HttpWebResponse tempResponse = response;
                    while(i<10)
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

            return result;
        }

        private static HttpWebResponse _Request(string url)
        {
            HttpWebRequest request = WebRequest.CreateHttp(url);

            HttpWebResponse response =(HttpWebResponse)request.GetResponseAsync().Result;

            return response;
        }

        private static string ReadResponse(HttpWebResponse response)
        {
            string result = null;

            using (StreamReader reader = new StreamReader(response.GetResponseStream()))
            {
                 result=reader.ReadToEnd();
            }

            return result;
        }
    }
}
