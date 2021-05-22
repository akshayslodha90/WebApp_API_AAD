using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ComplaintLoggingSystem.Helpers
{
    public static class UserToolBox
    {

        public static string GetEmailId()
        {
           

            var _httpContext = AppContext.Current;
            var emailId = _httpContext.User.Identity.Name;
            

            return "ab123@gmail.com";
        }
    }

    public static class AppContext
    {
        private static IHttpContextAccessor _httpContextAccessor;
        

        public static void Configure(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
            
        }

     
        public static HttpContext Current => _httpContextAccessor.HttpContext;
    }
}
