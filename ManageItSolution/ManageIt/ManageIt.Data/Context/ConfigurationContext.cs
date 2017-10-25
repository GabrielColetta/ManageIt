using ManageIt.Data.Configurations;
using ManageIt.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ManageIt.Data.Context
{
    public class ConfigurationContext : DbContext
    {
        public ConfigurationContext()
        {

        }

        public ConfigurationContext(DbContextOptions<ConfigurationContext> options) 
            : base(options)
        {

        }

        public DbSet<Info> Infos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionBuilder)
        {
            optionBuilder.UseSqlServer(@"Server=(local)\SQLEXPRESS01;Database=MANAGEIT;Trusted_Connection=True;");
            base.OnConfiguring(optionBuilder);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.HasDefaultSchema("MNIT");
            builder.ApplyConfiguration(new InfoConfiguration());
            base.OnModelCreating(builder);
        }
    }
}
