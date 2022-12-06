using ApiProject.Data.Map;
using ApiProject.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiProject.Data
{
    public class ProjectApiDb : DbContext
    {
        public ProjectApiDb(DbContextOptions<ProjectApiDb>options)
            : base(options)
        {
        }

        public DbSet<ClienteModel> Clientes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ClienteMap());

            base.OnModelCreating(modelBuilder);
        }
    }
}
