using System;
using System.Net;

namespace HttpRequestTest
{
    public class Class1
    {
        public static void Request()
        {
            HttpWebRequest request = WebRequest.CreateHttp("https://www.baidu.com");

            request.AllowAutoRedirect = false;
        }
    }
}
