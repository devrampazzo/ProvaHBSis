using LivrariaHBSIS.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace LivrariaHBSIS.Infra.Data.Context
{
    public class ContextoAplicacao : DbContext
    {
        private string _connString = null;
        public ContextoAplicacao(DbContextOptions<ContextoAplicacao> options) : base(options) { }
        public ContextoAplicacao(string connString) : base()
        {
            _connString = connString;
        }
        public ContextoAplicacao() : base() { }

        public DbSet<Livro> Livros { get; set; }
        public DbSet<Categoria> Categorias { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!string.IsNullOrWhiteSpace(_connString))
                optionsBuilder.UseSqlServer(_connString);

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Livro>().ToTable("Livro");
            modelBuilder.Entity<Livro>().HasKey(l => l.LivroId);
            modelBuilder.Entity<Livro>().Property(l => l.LivroId).UseSqlServerIdentityColumn();
            modelBuilder.Entity<Livro>().Property(l => l.Editora).HasColumnType("varchar(100)").HasMaxLength(100);
            modelBuilder.Entity<Livro>().Property(l => l.NomeAutor).HasColumnType("varchar(100)").HasMaxLength(100);
            modelBuilder.Entity<Livro>().Property(l => l.NomeLivro).HasColumnType("varchar(100)").HasMaxLength(100);

            modelBuilder.Entity<Categoria>().ToTable("Categoria");
            modelBuilder.Entity<Categoria>().HasKey(g => g.CategoriaId);
            modelBuilder.Entity<Categoria>().Property(g => g.CategoriaId).UseSqlServerIdentityColumn();
            modelBuilder.Entity<Categoria>().Property(g => g.Descricao).HasColumnType("varchar(100)").HasMaxLength(100);

            modelBuilder.Entity<Categoria>().HasData(CategoriaSeedData());

            modelBuilder.Entity<Livro>()
                .HasOne(l => l.Categoria)
                .WithMany(g => g.Livros)
                .HasForeignKey(l => l.CategoriaId)
                .OnDelete(DeleteBehavior.Restrict);

            base.OnModelCreating(modelBuilder);
        }

        private Categoria[] CategoriaSeedData()
        {
            return new Categoria[]
            {
                new Categoria
                {
                    CategoriaId = 1,
                    Descricao = "Aventura"
                },
                new Categoria
                {
                    CategoriaId = 2,
                    Descricao = "Romance Nacional"
                },
                new Categoria
                {
                    CategoriaId = 3,
                    Descricao = "Romance Estrangeiro"
                },
                new Categoria
                {
                    CategoriaId = 4,
                    Descricao = "Terror"
                },
                new Categoria
                {
                    CategoriaId = 5,
                    Descricao = "Biografia"
                },
                new Categoria
                {
                    CategoriaId = 6,
                    Descricao = "Autobiografia"
                },
                new Categoria
                {
                    CategoriaId = 7,
                    Descricao = "Autoajuda"
                },
                new Categoria
                {
                    CategoriaId = 8,
                    Descricao = "Religião"
                }
            };
        }
    }
}
