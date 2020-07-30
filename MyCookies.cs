using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace BugCookieNotSet
{
    public class MyCookies
    {
        public IHttpContextAccessor Accessor { get; private set; }

        public MyCookies(IHttpContextAccessor accessor)
        {
            Accessor = accessor;
        }

        public string Get(string name)
        {
            var rc = "fail";
            if (Accessor.HttpContext.Request.Cookies.TryGetValue(name, out var result)) 
                rc = $"{name}={result}"; 
            return rc;
        }

        public bool Set(string name, string value)
        {
            var rc = false;
            Accessor.HttpContext.Response.Cookies.Append(name, value);
            if (Accessor.HttpContext.Request.Cookies.TryGetValue(name, out var result) && (result == value))
                rc = true;
            return rc;
        }
    }
}
