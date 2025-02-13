using AutoLogin.Application.Interfaces;
using AutoLogin.Domain.Dtos.request;
using AutoLogin.Domain.Dtos.response;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace AutLogin.Controllers
{

    [ApiController]
    [EnableCors]
    [Route("/api/[controller]")]
    public class UserController: ControllerBase
    {
        private readonly ILoginService _loginService;
        private readonly IRegisterService _registerService;

        public UserController(ILoginService loginService, IRegisterService registerService)
        {
            _loginService = loginService;
            _registerService = registerService;
        }

        [HttpPost]
        [Route("register")]
        public IActionResult registerUser(RegisterRequestDto request)
        {
            ResponseBase<string> result = _registerService.registerUser(request);
            return StatusCode(result.StatusCode, result);
        }

        [HttpPost]
        [Route("login")]
        public IActionResult login(LoginRequestDto request)
        {
            ResponseBase<ResponseLoginDto> result = _loginService.Login(request);
            return StatusCode(result.StatusCode, result);
        }

        [Authorize]
        [HttpGet]
        [Route("getUserData")]
        public IActionResult getUserData()
        {
            var claims = User.Claims;
            ResponseBase<ResponseLoginDto> result = _registerService.getUserData(claims);
            return StatusCode(result.StatusCode, result);
        }


    }
}
