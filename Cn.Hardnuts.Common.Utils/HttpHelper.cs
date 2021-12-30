using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cn.Hardnuts.Common.Utils
{
    public class HttpHelper
    {
        static HttpClientHelper hc = new HttpClientHelper();

        public static string? Post(string url, string strJson)
        {
            return hc.Post(url, strJson);
        }
    }
}
