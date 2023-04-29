using Core.Configuration;
using Core.Dtos;
using Core.Entities;
using Core.Repositories;
using Core.Services;
using Core.UnitOfWorks;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Shared.Dtos;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Service.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly List<Client> _clients;
        private readonly ITokenService _tokenService;
        private readonly UserManager<AppUser> _userManager;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IGenericRepository<UserRefreshToken> _userRefreshTokenService;

        public AuthenticationService(IOptions<List<Client>> clients, ITokenService tokenService, 
            UserManager<AppUser> userManager, IUnitOfWork unitOfWork, 
            IGenericRepository<UserRefreshToken> userRefreshTokenService)
        {
            _clients = clients.Value;
            _tokenService = tokenService;
            _userManager = userManager;
            _unitOfWork = unitOfWork;
            _userRefreshTokenService = userRefreshTokenService;
        }

        public Task<Response<TokenDto>> CreateRefreshTokenAsync(string refreshToken)
        {
            throw new NotImplementedException();
        }

        public async Task<Response<TokenDto>> CreateTokenAsync(LoginDto loginDto)
        {
            if (loginDto == null)
            {
                throw new ArgumentNullException(nameof(loginDto));
            }
            var user = await _userManager.FindByEmailAsync(loginDto.Email);
            return null;
        }

        public Task<Response<ClientTokenDto>> CreateTokenByClientAsync(ClientLoginDto clientLoginDto)
        {
            throw new NotImplementedException();
        }

        public Task<Response<NoDataDto>> RevokeRefreshTokenAsync(string refreshToken)
        {
            throw new NotImplementedException();
        }
    }
}
