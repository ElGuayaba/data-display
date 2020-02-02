using System;
using Microsoft.AspNetCore.Identity;

namespace DataDisplay.Api.WebApi.Identity
{
    public class LoginToken
    {
        public Guid Id { get; set; }
        public string IdentityUserId { get; set; }
        public IdentityUser IdentityUser { get; set; }
    }
}