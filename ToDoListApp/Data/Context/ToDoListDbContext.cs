using Microsoft.EntityFrameworkCore;
using System.Security.Policy;
using ToDoListApp.Data.Models;

namespace ToDoListApp.Data.Context
{
    public class ToDoListDbContext : DbContext
    {
        public ToDoListDbContext()
        {
        }

        public ToDoListDbContext(DbContextOptions<ToDoListDbContext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql("server=localhost;database=todolistapp;user=root;password=nismah005", new MySqlServerVersion(new Version(10, 1, 40)));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Member>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.HasIndex(e => e.Email).IsUnique();
                entity.HasMany(d => d.Tasks);
                
            });

            modelBuilder.Entity<ToDoTask>(entity =>
            {
                entity.HasKey(e => e.Id);               
            });
        }

        public DbSet<Member> Members { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<ToDoTask> ToDoTask { get; set; }
    }
}
