using System;
using System.Threading.Tasks;
using DataDisplay.Api.WebApi.Identity;

namespace DataDisplay.Api.WebApi.Service.Contract
{
    public interface ITokenLoginService
    {
        Task<string> GenerateToken(string userId);
        Task<LoginToken> RecoverLoginToken(Guid token);
    }
}