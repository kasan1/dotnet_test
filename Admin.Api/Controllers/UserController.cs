using Agro.Admin.Logic.User;
using Agro.Shared.Api.AttributeExtension;
using Agro.Shared.Api.Controllers;
using Agro.Shared.Data.Enums.Identity;
using Agro.Shared.Data.Primitives;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Agro.Admin.Api.Controllers
{
    /// <summary>
    /// Контроллер для работы с пользователями
    /// </summary>
    public class UserController : BaseController
    {
        private readonly IUserLogic _logic;
        public UserController(IUserLogic logic)
        {
            _logic = logic;
        }

        /// <summary>
        /// Список ролей и разрешений пользователя
        /// </summary>
        /// <returns></returns>
        //[HttpGet("UserRoles")]
        //[AllowAnonymous]
        //public async Task<IActionResult> UserRoles()
        //{
        //    try
        //    {
        //        var _ = await _logic.UserRoles(CurrentUserId);
        //        return Ok(_);
        //    }
        //    catch (Exception e)
        //    {
        //        return ExceptionResult(e);
        //    }
        //}

        /// <summary>
        /// Список разрешений
        /// </summary>
        /// <param name="culture"></param>
        /// <returns></returns>
        [HttpGet("Permissions")]
        public IActionResult Permissions()
        {
            try
            {
                var enumVals = new List<object>();
                foreach (var i in Enum.GetValues(typeof(PermissionEnum)))
                {
                    enumVals.Add(new
                    {
                        key = i.GetHashCode(),
                        value = i.ToString()
                    });
                }
                return Ok(enumVals);
            }
            catch (Exception e)
            {
                return ExceptionResult(e);
            }
        }

        /// <summary>
        /// Список ролей
        /// </summary>
        /// <returns></returns>
        [HttpGet("Roles")]
        public IActionResult Roles()
        {
            try
            {
                var enumVals = new List<object>();
                foreach (var i in Enum.GetValues(typeof(RoleType)))
                {
                    enumVals.Add(new
                    {
                        key = i.GetHashCode(),
                        value = i.ToString()
                    });
                }
                return Ok(enumVals);
            }
            catch (Exception e)
            {
                return ExceptionResult(e);
            }
        }

        [HttpPost("AddRoleToUser")]
        [UserRoleAttributeExtension(RoleType.Admin)]
        public async Task AddRoleToUser(Guid UserId, RoleType roleEnum)
        {
            try
            {
                var z = await _logic.AddRoleToUser(UserId, roleEnum);
            }
            catch (Exception e)
            {
                
            }
                        
        }
    }
}
