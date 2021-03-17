using System;

namespace WebMvcCourse.services.Exceptions
{
    public class DbConcurrencyException: ApplicationException
    {
        public DbConcurrencyException(string message) : base(message)
        {
        }
    }
}