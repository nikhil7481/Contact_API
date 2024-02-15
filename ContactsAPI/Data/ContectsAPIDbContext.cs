using ContactsAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace ContactsAPI.Data
{
    public class ContectsAPIDbContext : DbContext
    {
        public ContectsAPIDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Contect> Contects { get; set; } 
    }
}
