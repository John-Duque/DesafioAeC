using DesafioAeC.Domain.Entities;
using DesafioAeC.Infra.Mapping;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace DesafioAeC.Infra.Context
{
    public class MyContext : DbContext
    {
        public DbSet<AluraEntity> Aluras { get; set; }
        public IConfiguration _configuration { get; }

        public MyContext(DbContextOptions<MyContext> options, IConfiguration configuration) : base(options)
        {
            _configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string? connectionString = "server=localhost;DataBase=dbAPI;Uid=root;Pwd=03200109";
            optionsBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<AluraEntity>(new AluraMap().Configure);
        }
    }
}

