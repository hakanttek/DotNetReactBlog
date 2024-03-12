using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ReactWebBlogger.Application.DTOs;
using ReactWebBlogger.Application.Services;
using ReactWebBlogger.Contracts.Services;
using ReactWebBlogger.Domain.Entities;
using System.Security.Claims;

namespace ReactWebBlogger.Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LoginController : ControllerBase
    {
        private readonly IUserTokenService<UserDto> _userTokenService;
        private readonly IUserService<UserDto> _userService;

        public LoginController(IUserTokenService<UserDto> userTokenService, IUserService<UserDto> userService)
        {
            _userTokenService = userTokenService;
            _userService = userService;
        }

        [HttpPost("in", Name = "PostUserLogin")]
        [AllowAnonymous]
        public async Task<IActionResult> PostUserLogin(UserLoginDto userLoginDto)
        {
            if (userLoginDto.Username is null)
                return BadRequest("Please enter username.");
            else if (userLoginDto.Password is null)
                return BadRequest("Please enter username.");

            UserDto? user = await _userService.GetUserByUsernameAsync(userLoginDto.Username);
            if (user is null)
                return NotFound("Username is not exist.");
            else if (user.Password != userLoginDto.Password)
                return NotFound("Password is incorrect.");
            else if(user.Username is not null && user.Role is not null)
            {
                // Create claims
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                    new Claim(ClaimTypes.Name, user.Username),
                    new Claim(ClaimTypes.Role, user.Role)
                };

                // Create ClaimsIdentity
                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                // Create AuthenticationProperties
                var authProperties = new AuthenticationProperties
                {
                    // todo: add later IsPersistent = model.RememberMe

                };

                // Sign in the user
                await HttpContext.SignInAsync(
                    CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(claimsIdentity),
                    authProperties);

                return Ok("You are loged in.");
            }
            else
            {
                return BadRequest("User name or user role is null.");
            }
        }

        [HttpPost("out", Name = "PostUserLogout")]
        [AllowAnonymous]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            return Ok("You are loged out.");
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> GetJwtToken(UserLoginDto userLogin)
        {
            if (userLogin.Username is null)
                return BadRequest("Please, enter username.");

            UserDto? userDto = await _userService.GetUserByUsernameAsync(userLogin.Username);
            if(userDto is null)
                return BadRequest("User is not exist.");
            else if(userDto.Password != userLogin.Password)
            {
                return BadRequest("Wrong password.");
            }
            else
            {
                var token = _userTokenService.CreateJwtToken(userDto);
                return Ok(token);
            }
        }
    }
}
