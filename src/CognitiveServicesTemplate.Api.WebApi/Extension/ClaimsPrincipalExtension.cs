﻿using System.Security.Claims;

namespace CognitiveServicesTemplate.Api.WebApi.Extension
{
    public static class ClaimsPrincipalExtension
    {
        public static string GetId(this ClaimsPrincipal principal)
        {
            return principal.FindFirstValue(ClaimTypes.NameIdentifier);
        }
    }
}