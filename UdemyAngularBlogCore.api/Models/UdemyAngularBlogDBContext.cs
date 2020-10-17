using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace UdemyAngularBlogCore.api.Models
{
    public partial class UdemyAngularBlogDBContext : DbContext
    {
        public UdemyAngularBlogDBContext()
        {
        }

        public UdemyAngularBlogDBContext(DbContextOptions<UdemyAngularBlogDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Article> Article { get; set; }
        public virtual DbSet<Category> Category { get; set; }
        public virtual DbSet<Comment> Comment { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Article>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CategoryId).HasColumnName("categoryId");

                entity.Property(e => e.ContentSummary)
                    .IsRequired()
                    .HasColumnName("content_summary")
                    .HasMaxLength(500);

                entity.Property(e => e.MainContent)
                    .IsRequired()
                    .HasColumnName("mainContent");

                entity.Property(e => e.Picture)
                    .HasColumnName("picture")
                    .HasMaxLength(300);

                entity.Property(e => e.PublishDate)
                    .HasColumnName("publishDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasColumnName("title")
                    .HasMaxLength(500);

                entity.Property(e => e.ViewCount).HasColumnName("viewCount");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Article)
                    .HasForeignKey(d => d.CategoryId)
                    .HasConstraintName("FK_Article_Category");
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<Comment>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.ArticleId).HasColumnName("articleId");

                entity.Property(e => e.MainContent)
                    .IsRequired()
                    .HasColumnName("mainContent");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(100);

                entity.Property(e => e.PublishDate)
                    .HasColumnName("publishDate")
                    .HasColumnType("datetime");

                entity.HasOne(d => d.Article)
                    .WithMany(p => p.Comment)
                    .HasForeignKey(d => d.ArticleId)
                    .HasConstraintName("FK_Comment_Article");
            });
        }
    }
}
