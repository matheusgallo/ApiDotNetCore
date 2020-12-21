

using Domain;
using Microsoft.EntityFrameworkCore;

namespace Repository.Data
{
    public class RepositoryContext: DbContext
    {
        public RepositoryContext(DbContextOptions<RepositoryContext> options) : base(options) {}

        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Tarefa> Tarefa { get; set; }
      

    }
}
