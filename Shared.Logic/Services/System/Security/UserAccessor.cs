using System;
using System.Linq;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;

namespace Agro.Shared.Logic.Services.System.Security
{
    public class UserAccessor : IUserAccessor
    {
        #region Fields

        private readonly IHttpContextAccessor _httpContextAccessor;

        #endregion

        #region Constructor

        public UserAccessor(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        #endregion

        #region Public functions

        public Guid GetCurrentUserId()
        {
            var userIdStr = _httpContextAccessor.HttpContext.User?.Claims
                .SingleOrDefault(claim => claim.Type == "userId")?.Value;

            if (Guid.TryParse(userIdStr, out var userId))
            {
                return userId;
            }

            return Guid.Empty;
        }

        public string GetCurrentUsername()
        {
            return _httpContextAccessor.HttpContext.User?.Claims
                .SingleOrDefault(claim => claim.Type == ClaimTypes.NameIdentifier).Value;
        }

        #endregion
    }
}
