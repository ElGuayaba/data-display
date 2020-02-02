using System.Threading.Tasks;
using DataDisplay.Api.WebApi.Service.Implementation;

namespace DataDisplay.Api.WebApi.Service.Contract
{
    public interface IJwtTokenService
    {
        Task<JwtToken> Generate(string userId);
    }
}