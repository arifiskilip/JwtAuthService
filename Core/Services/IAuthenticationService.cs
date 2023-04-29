using Core.Dtos;
using Shared.Dtos;
using System.Threading.Tasks;

namespace Core.Services
{
    public interface IAuthenticationService
    {
        Task<Response<TokenDto>> CreateTokenAsync(LoginDto loginDto);
        Task<Response<ClientTokenDto>> CreateTokenByClientAsync(ClientLoginDto clientLoginDto);
        Task<Response<TokenDto>> CreateRefreshTokenAsync(string refreshToken);
        Task<Response<NoDataDto>> RevokeRefreshTokenAsync(string refreshToken);
    }
}
