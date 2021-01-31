using System;
using System.Collections.Generic;
using System.Linq;
using ExceptionsHandlingInWebAPI.Exceptions;
using ExceptionsHandlingInWebAPI.Models;

namespace ExceptionsHandlingInWebAPI.Services
{
    public class APIService : IAPIService
    {
        public List<Person> GenericExceptionSearchBy(string firstName = null)
        {
            List<Person> persons = GetNullList();

            if (firstName == null)
            {
                throw new ArgumentNullException($"The parameter cannot be null");
            }

            return persons.Where(p => p.FirstName.StartsWith(firstName)).ToList();
        }

        public List<Person> CustomExceptionSearchBy(string firstName = null)
        {
            List<Person> persons = GetNullList();

            if (firstName == null)
            {
                throw new MyCustomException($"The parameter cannot be null");
            }

            return persons.Where(p => p.FirstName.StartsWith(firstName)).ToList();
        }


        private List<Person> GetNullList()
        {
            return null;
        }
    }
}
