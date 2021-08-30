using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using TaksaCheckIn.Models;

namespace TaksaCheckIn.Controllers.Base
{
    //[Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class ApiControllerBase : ControllerBase
    {
        protected readonly ClaimsPrincipal _user;
        protected readonly string _userID;
        protected readonly string _userName;
        protected readonly string _roleName;
        protected readonly string _roleID;

        public ApiControllerBase(IHttpContextAccessor httpContextAccessor)
        {
            var user = httpContextAccessor.HttpContext.User;
            _user = user;
            _userID = user?.FindFirstValue(ClaimTypes.NameIdentifier);
            _userName = user?.FindFirstValue(ClaimTypes.Name);
            _roleName = user?.FindFirstValue(ClaimTypes.Role);
            _roleID = user?.FindFirstValue("RoleId");
        }

        protected internal virtual ForbiddenResult Forbidden()
        {
            return new ForbiddenResult(Request);
        }

        protected ForbiddenResult Forbidden(string reason)
        {
            return new ForbiddenResult(Request, reason);
        }
    }
}
