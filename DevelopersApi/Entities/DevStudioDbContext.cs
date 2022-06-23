using Microsoft.EntityFrameworkCore;
using System;
using System.Reflection;

namespace DevelopersApi.Entities_Models {

    public partial class DevStudioDbContext : DbContext { 
    
        public virtual DbSet<Developer> Developers { get; set; }
        public virtual DbSet<Game> Games { get; set; }
        public virtual DbSet<DeveloperGame> DeveloperGames { get; set; }

        public DevStudioDbContext() { }
        public DevStudioDbContext(DbContextOptions<DevStudioDbContext> options) : base(options) { }


        protected override void OnModelCreating(ModelBuilder modelBuilder) {

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(DeveloperEfConfiguration).GetTypeInfo().Assembly);

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}