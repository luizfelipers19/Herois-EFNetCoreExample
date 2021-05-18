﻿using EFCore.Domain;

using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFCore.Repo
{
    public class HeroiContexto : DbContext
    {
        public DbSet<Heroi> Herois { get; set; }

        public DbSet<Batalha> Batalhas { get; set;}

        public DbSet<Arma> Armas { get; set; }

        public DbSet<HeroiBatalha> HeroisBatalhas { get; set; }

        public DbSet<IdentidadeSecreta> IdentidadesSecretas { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source = (localdb)\MSSQLLocalDB; Initial Catalog = HeroApp; Integrated Security = True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<HeroiBatalha>(entity => {
                entity.HasKey(e => new { e.BatalhaId, e.HeroiId });
            
            });
        }

    }
}
