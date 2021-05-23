using Microsoft.AspNetCore.Http;

namespace ComplaintLoggingSystem.Helpers
{
    public static class UserToolBox
    {

        public static string GetEmailId()
        {


            var _httpContext = AppContext.Current;
            var emailId = _httpContext.User.Identity.Name;


            return emailId;
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
