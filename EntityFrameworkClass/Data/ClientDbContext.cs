using EntityFrameworkClass.Models;
using Microsoft.EntityFrameworkCore;

namespace EntityFrameworkClass.Data
{
    public class ClientDbContext:DbContext
    {
        public ClientDbContext(DbContextOptions<ClientDbContext> options) : base(options) {
            
        }
        public DbSet<Client> Clients { get; set; }

    }
}
