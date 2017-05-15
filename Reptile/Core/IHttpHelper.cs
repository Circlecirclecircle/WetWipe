using System;
using System.Collections.Generic;
using System.Text;

namespace Core
{
    public interface IHttpHelper
    {
        string Request(string url);

        string GetRedirectUrl(string url);
    }
}
