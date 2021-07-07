using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Articles.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Articles.Infrastructure
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Article> Articles { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
    }
}
