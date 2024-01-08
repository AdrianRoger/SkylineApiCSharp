using Microsoft.EntityFrameworkCore;
using Skyline.Models;
using Skyline_api.Models;
using System.Collections.Generic;

namespace Skyline.Context
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        public DbSet<Contato> Contato { get; set; }
        public DbSet<Cidade> Cidade { get; set; }
        public DbSet<Voo> Voo { get; set; }
        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Reserva> Reserva { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configurações de relacionamento aqui
            modelBuilder.Entity<Cidade>()
                .HasMany(c => c.VoosOrigem)
                .WithOne(v => v.Origem)
                .HasForeignKey(v => v.OrigemId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Cidade>()
                .HasMany(c => c.VoosDestino)
                .WithOne(v => v.Destino)
                .HasForeignKey(v => v.DestinoId)
                .OnDelete(DeleteBehavior.Restrict);

            // Configuração da unicidade para o campo Email na tabela Contato
            modelBuilder.Entity<Usuario>()
                .HasIndex(u => u.Email)
                .IsUnique();

            //Configuração default para os atributos Booleanos
            modelBuilder.Entity<Usuario>()
                .Property(u => u.Ativo)
                .HasDefaultValue(true);

            modelBuilder.Entity<Reserva>()
                .Property(r => r.Cancelada)
                .HasDefaultValue(false);

            modelBuilder.Entity<Contato>()
                .Property(c => c.Resolvido)
                .HasDefaultValue(false);

            //Definindo opadrão on delete para Restrict
            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }
        }
    }
}