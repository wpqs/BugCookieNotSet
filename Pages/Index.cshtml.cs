using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace BugCookieNotSet.Pages
{
    public class IndexModel : PageModel
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        [BindProperty]
        public string Comment { get; set; }
        public IndexModel(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public void OnGet()
        {
            var result = true;
            var cookies = new MyCookies(_httpContextAccessor);
            if (cookies.Set(".AspNetCore.Culture", "fr-CH") == false)
                result = false;
            Comment = (result) ? $"Success: {cookies.Get(".AspNetCore.Culture")}" : $"{cookies.Get(".AspNetCore.Culture")}";

        }
    }
}
