using EFStep.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFStep.DAL
{
    internal class AppDbContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("server=msi;database=BB102EF;Trusted_connection=true;Integrated security=true;Encrypt=false;");
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Group> Groups { get; set; }

    }
}
