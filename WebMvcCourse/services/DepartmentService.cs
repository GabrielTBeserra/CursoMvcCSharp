using System.Collections.Generic;
using System.Linq;
using WebMvcCourse.Data;
using WebMvcCourse.Models;

namespace WebMvcCourse.services
{
    public class DepartmentService
    {
        private readonly WebMvcCourseContext _context;

        public DepartmentService(WebMvcCourseContext context)
        {
            _context = context;
        }

        public List<Department> FindAll()
        {
            return _context.Department.OrderBy(x => x.Name).ToList();
        }
    }
}