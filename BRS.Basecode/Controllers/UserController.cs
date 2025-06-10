using BRS.Basecode.Resources.Constants;
using BRS.Basecode.Services.Interfaces;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace BRS.Basecode.WebApp.Controllers
{
    [EnableCors]
    [ApiController]
    [Route(Common.Route.BASE)]
    public class UserController : Controller
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllUser()
        {
            var result = await _userService.GetAllUser();
            return Ok(result);
        }
    }
}
