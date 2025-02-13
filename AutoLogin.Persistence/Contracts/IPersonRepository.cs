using AutoLogin.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoLogin.Persistence.Contracts
{
    public interface IPersonRepository
    {
        Person GetPerson(long id);

        Person savePerson(Person person);
    }
}
