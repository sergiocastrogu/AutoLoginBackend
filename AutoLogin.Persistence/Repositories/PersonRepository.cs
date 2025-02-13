using AutoLogin.Domain.Entities;
using AutoLogin.Persistence.Context;
using AutoLogin.Persistence.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoLogin.Persistence.Repositories
{
    public class PersonRepository: IPersonRepository
    {
        private readonly LoginDbContext _context;

        public PersonRepository(LoginDbContext context)
        {
            _context = context;
        }

        public Person GetPerson(long id)
        {
            return _context.Persons.Where(p => p.Id == id).FirstOrDefault();
        }

        public Person savePerson(Person person)
        {
            try
            {
                _context.Persons.Add(person);
                _context.SaveChanges();
                return person;
            }
            catch (Exception ex) {
                return person;
            }
        }
    }
}
