using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using PottersREST.Delegates;

namespace PottersREST.Controllers
{
    public class URLHelper : IURLHelper
    {

        HttpContext context;
        public URLHelper(HttpContext context)
        {
            this.context = context;
        }

        public static string pots_base = @"pots/pots";
        public static string potters_base = @"potters/potters";
        public string buildURLBase()
        {
            var request = context.Request;
            string basestr = (request.IsHttps ? "https" : "http") + @"://" + request.Host + @"/" + request.PathBase.Value;
            return basestr;
        }

        public string buildPotURL(int id)
        {
            return buildURLBase() + pots_base + @"/" + id;
        }

        public string buildPotterURL(int id)
        {
            return buildURLBase() + potters_base + @"/" + id;
        }
    }
}
