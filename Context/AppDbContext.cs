using ApiGestores.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiGestores.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options): base(options)
        {
                
        }

        public DbSet<GestoresBD> GestoresDB { get; set; }
    }
}