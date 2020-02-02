using System;
using System.Threading.Tasks;
using CognitiveServicesTemplate.Api.WebApi.Identity;

namespace CognitiveServicesTemplate.Api.WebApi.Service.Contract
{
    public interface ITokenLoginService
    {
        Task<string> GenerateToken(string userId);
        Task<LoginToken> RecoverLoginToken(Guid token);
    }
}