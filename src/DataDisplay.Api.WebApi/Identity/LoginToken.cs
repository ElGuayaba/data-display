using System;
using Microsoft.AspNetCore.Identity;

namespace CognitiveServicesTemplate.Api.WebApi.Identity
{
    public class LoginToken
    {
        public Guid Id { get; set; }
        public string IdentityUserId { get; set; }
        public IdentityUser IdentityUser { get; set; }
    }
}