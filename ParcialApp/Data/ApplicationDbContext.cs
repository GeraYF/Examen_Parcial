using Microsoft.EntityFrameworkCore;
using ParcialApp.Controllers;
using ParcialApp.Models; 

namespace ParcialApp.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Transaccion> Transacciones { get; set; }
    }
}
