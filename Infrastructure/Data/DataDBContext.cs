using Domain.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public  class DataDBContext : DbContext
    {
        public DataDBContext( DbContextOptions<DataDBContext> options)  : base (options)
        {
        }
        public DbSet<User> Users { get; set; }
    }
}
