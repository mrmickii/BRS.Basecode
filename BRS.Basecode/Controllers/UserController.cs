using BRS.Basecode.Resources.Constants;
using BRS.Basecode.Services.DTO;
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

        [HttpGet(Common.Route.ID)]
        public async Task<IActionResult> GetUserById(int id)
        {
            var result = await _userService.GetUserById(id);
            return Ok(result);
        }

        [HttpPost(Common.Route.CREATE)]
        public async Task<IActionResult> CreateUser([FromBody]CreateUserDTO model)
        {
            await _userService.CreateUser(model);
            return Ok(Common.Messages.USER_CREATED);
        }

        [HttpPut(Common.Route.UPDATE)]
        public async Task<IActionResult> UpdateUser([FromBody]UserDTO model, int userId)
        {
            if(model.UserId != userId)
            {
                return BadRequest();
            }
            await _userService.UpdateUser(model);
            return Ok(Common.Messages.USER_UPDATED);
        }

        [HttpPut(Common.Route.UPDATE_PIN)]
        public async Task<IActionResult> UpdatePin([FromBody]UpdatePinDTO model, int userId)
        {
            if(model.UserId != userId)
            {
                return BadRequest();
            }

            await _userService.UpdatePin(model);
            return Ok(Common.Messages.USER_UPDATED);
        }
    }
}
