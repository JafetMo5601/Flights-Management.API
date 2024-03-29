﻿using FlightsManager.Models;
using FlightsManager.Models.Vuelos;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FlightsManager.DB
{
    public class ApplicationDBContext: IdentityDbContext<IdentityUser>
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Aerolinea> Aerolineas { get; set; }
        public DbSet<Aeropuerto> Aeropuertos { get; set; }
        public DbSet<Asiento> Asientos { get; set; }
        public DbSet<Avion> Aviones { get; set; }
        public DbSet<Horario> Horarios { get; set; }
        public DbSet<Pais> Paises { get; set; }
        public DbSet<Reservas> Reservas { get; set; }
        public DbSet<Tarifa> Tarifas { get; set; }
        public DbSet<Vuelo> Vuelos { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<User>()
                .HasIndex(u => u.UserId)
                .IsUnique();

            builder.Entity<Vuelo>()
                .HasOne(v => v.AeropuertoDestino)
                .WithMany()
                .OnDelete(DeleteBehavior.NoAction);

            builder.Entity<Vuelo>()
                .HasOne(v => v.AeropuertoPartida)
                .WithMany()
                .OnDelete(DeleteBehavior.NoAction);
        }

    }
}
