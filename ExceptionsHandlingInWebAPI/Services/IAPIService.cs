using System.Collections.Generic;
using ExceptionsHandlingInWebAPI.Models;

namespace ExceptionsHandlingInWebAPI.Services
{
    public interface IAPIService
    {
        List<Person> GenericExceptionSearchBy(string firstName = null);
        List<Person> CustomExceptionSearchBy(string firstName = null);
    }
}
