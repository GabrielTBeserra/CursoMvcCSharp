using System;

namespace WebMvcCourse.services.Exceptions
{
    public class IntegrityException: ApplicationException
    {
        public IntegrityException(string message) : base(message)
        {
        }
    }
}