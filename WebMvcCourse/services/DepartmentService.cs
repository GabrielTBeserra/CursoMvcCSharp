using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
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

        public async Task<List<Department>> FindAllAsync()
        {
            return await _context.Department.OrderBy(x => x.Name).ToListAsync();
        }
    }
}