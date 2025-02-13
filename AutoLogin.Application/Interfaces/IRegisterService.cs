using AutoLogin.Domain.Dtos.request;
using AutoLogin.Domain.Dtos.response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoLogin.Application.Interfaces
{
    public interface IRegisterService
    {
        ResponseBase<string> registerUser(RegisterRequestDto registerRequest);
        ResponseBase<ResponseLoginDto> getUserData(IEnumerable<System.Security.Claims.Claim> claims);

    }
}
