using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace FormularioMySQL.Models
{
    public partial class BDContexto : DbContext
    {
        public BDContexto()
        {
        }

        public BDContexto(DbContextOptions<BDContexto> options)
            : base(options)
        {
        }

        public virtual DbSet<Formulario> Formularios { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySql("server=sql10.freemysqlhosting.net;user=sql10503239;password=bkrRlXPcA7;database=sql10503239", Microsoft.EntityFrameworkCore.ServerVersion.Parse("5.5.62-mysql"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseCollation("latin1_swedish_ci")
                .HasCharSet("latin1");

            modelBuilder.Entity<Formulario>(entity =>
            {
                entity.HasKey(e => e.IdAluno)
                    .HasName("PRIMARY");

                entity.ToTable("Formulario");

                entity.Property(e => e.IdAluno)
                    .HasColumnType("int(11)")
                    .ValueGeneratedNever()
                    .HasColumnName("idAluno");

                entity.Property(e => e.AvaliacaoAula)
                    .HasColumnType("int(11)")
                    .HasColumnName("avaliacaoAula");

                entity.Property(e => e.ComentarioAula)
                    .HasMaxLength(100)
                    .HasColumnName("comentarioAula");

                entity.Property(e => e.DataAula)
                    .HasMaxLength(20)
                    .HasColumnName("dataAula");

                entity.Property(e => e.NomeAluno)
                    .HasMaxLength(40)
                    .HasColumnName("nomeAluno");

                entity.Property(e => e.NomeDisciplina)
                    .HasMaxLength(100)
                    .HasColumnName("nomeDisciplina");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
