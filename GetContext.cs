using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Ladaprojekt
{
    internal class GetContext : DbContext
    {
        public DbSet<Course> Course { get; set; } = null!;
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost;Port=5432;User Id=postgres;Password=MasterPassword;Database=StudentManagmentSystemDb");
        }
    
}
}
