using Microsoft.EntityFrameworkCore;
using ProAgil.WebAPI.model;

namespace ProAgil.WebAPI.data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) 
            : base(options) {}
        
        public DbSet<Evento> Eventos { get; set; }        
    }
}