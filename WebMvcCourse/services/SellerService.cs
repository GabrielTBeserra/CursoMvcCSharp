using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebMvcCourse.Data;
using WebMvcCourse.Models;

namespace WebMvcCourse.services
{
    public class SellerService
    {
        private readonly WebMvcCourseContext _context;

        public SellerService(WebMvcCourseContext context)
        {
            _context = context;
        }

        public List<Seller> FindAll()
        {
            return _context.Seller.ToList();
        }
    }
}
