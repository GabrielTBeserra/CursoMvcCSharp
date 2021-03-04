using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebMvcCourse.Models;

namespace WebMvcCourse.Data
{
    public class WebMvcCourseContext : DbContext
    {
        public WebMvcCourseContext (DbContextOptions<WebMvcCourseContext> options)
            : base(options)
        {
        }

        public DbSet<Department> Department { get; set; }
        public DbSet<Seller> Seller { get; set; }
        public DbSet<SalesRecord> SalesRecords { get; set; }

    }
}
