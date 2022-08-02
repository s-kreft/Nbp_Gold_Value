using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace nbp_gold_value
{
    public partial class nbpContext : DbContext
    {
        public nbpContext()
        {
        }

        public nbpContext(DbContextOptions<nbpContext> options)
            : base(options)
        {
        }

        public virtual DbSet<GoldValue> GoldValues { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseMySql("server=localhost;user=root;password=root;database=nbp", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.27-mysql"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseCollation("utf8mb4_0900_ai_ci")
                .HasCharSet("utf8mb4");

            modelBuilder.Entity<GoldValue>(entity =>
            {
                

                entity.ToTable("gold_value");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Cena).HasColumnName("price");

                entity.Property(e => e.Data).HasColumnName("price_date");

                entity.HasAlternateKey(e => e.Id);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
