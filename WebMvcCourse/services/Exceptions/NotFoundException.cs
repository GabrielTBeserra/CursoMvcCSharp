using System;

namespace WebMvcCourse.services.Exceptions
{
    public class NotFoundException: ApplicationException
    {
        public NotFoundException(string message) : base(message)
        {
            
        }
    }
}