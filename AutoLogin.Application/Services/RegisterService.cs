using AutoLogin.Application.Interfaces;
using AutoLogin.Domain.Dtos.request;
using AutoLogin.Domain.Dtos.response;
using AutoLogin.Domain.Entities;
using AutoLogin.Persistence.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace AutoLogin.Application.Services
{
    public class RegisterService : IRegisterService
    {
        private readonly IUserRepository _userRepository;
        private readonly IPersonRepository _personRepository;
        public RegisterService(IPersonRepository personRepository, IUserRepository userRepository)
        {
            _personRepository = personRepository;
            _userRepository = userRepository;
        }

        public ResponseBase<ResponseLoginDto> getUserData(IEnumerable<Claim> claims)
        {
            var userName = claims.FirstOrDefault(c => c.Type == ClaimTypes.UserData)?.Value;
            User user = _userRepository.getByUserName(userName);
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
                SecondName = person.SecondName
            };
            return new ResponseBase<ResponseLoginDto> { Data = response, Message = "Sin errores", StatusCode = 200 };

        }

        public ResponseBase<string> registerUser(RegisterRequestDto registerRequest)
        {
            Person person = new Person
            {
                Id = 0,
                Identification = registerRequest.Identification,
                FirstName = registerRequest.FirstName,
                SecondName = registerRequest.SecondName,
                LastName = registerRequest.FirstLastName,
                SecondLastName = registerRequest.SecondLastName,
                Email = registerRequest.Email,
                Phone = registerRequest.PhoneNumber
            };
            Person newPerson = _personRepository.savePerson(person);

            if (newPerson.Id == 0)
            {
                return new ResponseBase<string> { Data = null, Message = "No se pudo registrar el usuario", StatusCode = 400 };
            }

            User user = new User
            (
                0,
                newPerson.Id,
                registerRequest.Email,
                registerRequest.Password,
                true
            );
            User newUser = _userRepository.saveUser(user);
            if (newUser.Id == 0)
            {
                return new ResponseBase<string> { Data = null, Message = "No se pudo registrar el usuario", StatusCode = 400 };
            }

            return new ResponseBase<string> { Data = null, Message = "Registro Exitoso", StatusCode = 200 };
        }
    }
}
