using System.Threading.Tasks;
using CognitiveServicesTemplate.Api.WebApi.Service.Implementation;

namespace CognitiveServicesTemplate.Api.WebApi.Service.Contract
{
    public interface IJwtTokenService
    {
        Task<JwtToken> Generate(string userId);
    }
}