using System.Security.Claims;

namespace DataDisplay.Api.WebApi.Extension
{
    public static class ClaimsPrincipalExtension
    {
        public static string GetId(this ClaimsPrincipal principal)
        {
            return principal.FindFirstValue(ClaimTypes.NameIdentifier);
        }
    }
}