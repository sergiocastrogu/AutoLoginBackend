using AutoLogin.Application.Interfaces;
using AutoLogin.Domain.Dtos.request;
using AutoLogin.Domain.Dtos.response;
using AutoLogin.Domain.Entities;
using AutoLogin.Persistence.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoLogin.Application.Services
{
    public class LoginService : ILoginService
    {

        private readonly IUserRepository _userRepository;
        private readonly IPersonRepository _personRepository;
        private readonly ISecureService _secureService;

        public LoginService(IUserRepository userRepository, IPersonRepository personRepository, ISecureService secureService)
        {
            _userRepository = userRepository;
            _personRepository = personRepository;
            _secureService = secureService;
        }

        public ResponseBase<ResponseLoginDto> Login(LoginRequestDto request)
        {
            User user = _userRepository.getByUserName(request.UserName);

            if (user==null || user.validatePassword(request.Password))
            {
                return new ResponseBase<ResponseLoginDto> { Data = null, Message = "Por favor verifique los datos e intente nuevamente", StatusCode = 400 };
            }

            Person person = _personRepository.GetPerson(user.PersonId);

            ResponseLoginDto response = new ResponseLoginDto
            {
                Email = person.Email,
                FirstLastName = person.FirstName,
                FirstName = person.LastName,
                Id = person.Id,
                Identification = person.Identification,
                Phone_Number = person.Phone,
                SecondLastName = person.LastName,
                SecondName = person.SecondName,
                Token = _secureService.GenerateToken(user)
            };
            return new ResponseBase<ResponseLoginDto> { Data = response, Message = "Inicio de sesión exitoso", StatusCode = 200 };
        }
    }
}
