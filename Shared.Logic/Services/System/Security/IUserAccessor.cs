using System;

namespace Agro.Shared.Logic.Services.System.Security
{
    public interface IUserAccessor
    {
        string GetCurrentUsername();

        Guid GetCurrentUserId();
    }
}
