using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace BlogAspNet2.Models
{
    public partial class BlogAspNetContext : DbContext
    {
        public virtual DbSet<Category> Category { get; set; }
        public virtual DbSet<Post> Post { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer(@"Server=localhost; Database=BlogAspNet;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>(entity =>
            {
                entity.Property(e => e.Name).HasMaxLength(50);
            });

            modelBuilder.Entity<Post>(entity =>
            {
                entity.Property(e => e.Datetime).HasColumnType("date");

                entity.Property(e => e.FkCategoryId).HasColumnName("FK_CategoryId");

                entity.Property(e => e.Post1)
                    .HasColumnName("Post")
                    .HasMaxLength(2000);

                entity.Property(e => e.Title).HasMaxLength(50);

                entity.HasOne(d => d.FkCategory)
                    .WithMany(p => p.Post)
                    .HasForeignKey(d => d.FkCategoryId)
                    .HasConstraintName("FK__Post__FK_Categor__398D8EEE");
            });
        }
    }
}
