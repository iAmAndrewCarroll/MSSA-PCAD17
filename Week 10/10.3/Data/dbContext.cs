using _10._3.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace _10._3.Data
{
    public class CarDbContext : DbContext
    {
        public DbSet<Car> Cars { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlite("Data Source=cars.db");
        }
    }
}
