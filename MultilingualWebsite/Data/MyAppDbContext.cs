using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using MultilingualWebsite.Models;

namespace MultilingualWebsite.Data
{
    public partial class MyAppDbContext : DbContext
    {
        public MyAppDbContext()
        {
        }

        public MyAppDbContext(DbContextOptions<MyAppDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Language> Languages { get; set; }
        public virtual DbSet<Texts> Texts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("name=DefaultConnection");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Language>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Culture)
                    .HasColumnName("culture")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.LanguageName)
                    .HasColumnName("language_name")
                    .HasMaxLength(25)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Texts>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.KeyText)
                    .HasColumnName("key_text")
                    .HasMaxLength(80)
                    .IsUnicode(false);

                entity.Property(e => e.KeyValue)
                    .HasColumnName("key_value")
                    .HasColumnType("text");

                entity.Property(e => e.LanguageId).HasColumnName("language_id");

                entity.HasOne(d => d.Language)
                    .WithMany(p => p.Texts)
                    .HasForeignKey(d => d.LanguageId)
                    .HasConstraintName("FK__Texts__language___29572725");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
