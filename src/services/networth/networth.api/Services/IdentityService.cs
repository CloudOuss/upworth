using System;
using System.Linq;
using NetworthApplication.Common.Interfaces;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace NetworthApi.Services
{
    public class IdentityService : IIdentityService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public IdentityService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }
        
        public Guid UserId 
            => Guid.Parse(_httpContextAccessor.HttpContext?.User?.Claims.FirstOrDefault(c=>c.Type == "uid")?.Value ?? throw new InvalidOperationException());

        public string UserName => _httpContextAccessor.HttpContext?.User?.Claims.FirstOrDefault(c=>c.Type == ClaimTypes.NameIdentifier)?.Value;
    }
}