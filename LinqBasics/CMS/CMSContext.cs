using System;
using Microsoft.EntityFrameworkCore;

namespace LinqBasics.CMS
{
    public class CMSContext : DbContext
    {
        public DbSet<StudentEntity> Students { get; set; }
        public DbSet<CourseEntity> Courses { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            string path = "/Users/petr/Projects/LinqBasics/LinqBasics/CMS.db";
            builder.UseSqlite($"Filename={path}");
        }
    }
}
