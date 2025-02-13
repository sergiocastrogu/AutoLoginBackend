using AutoLogin.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoLogin.Application.Interfaces
{
    public interface ISecureService
    {
        string GenerateToken(User user);
    }
}
