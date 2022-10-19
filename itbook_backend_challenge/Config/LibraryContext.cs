using Microsoft.EntityFrameworkCore;
using itbook_backend_challenge.Mapdata.Models;

namespace itbook_backend_challenge.Config
{
    public class LibraryContext : DbContext
    {
        public DbSet<User> User { get; set; }

        public DbSet<Favor> Favor { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL("server=localhost;database=itbook_test;user=root;password=''");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.user_id);
                entity.Property(e => e.user_username).IsRequired();
                entity.Property(e => e.user_password).IsRequired();
                entity.Property(e => e.user_fullname).IsRequired();
                entity.Property(e => e.user_create_at).HasDefaultValueSql();
                entity.Property(e => e.user_update_at).HasDefaultValueSql();
            });

            modelBuilder.Entity<Favor>(entity =>
            {
                entity.HasKey(e => e.favor_id);
                entity.Property(e => e.favor_user_id).IsRequired();
                entity.Property(e => e.favor_book_id).IsRequired();
                entity.Property(e => e.favor_create_at).HasDefaultValueSql();
                entity.Property(e => e.favor_update_at).HasDefaultValueSql();
            });
        }
    }
}