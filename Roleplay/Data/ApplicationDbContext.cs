using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PR5_Roleplay.Models;

namespace Roleplay.Data
{
    public class ApplicationDbContext : IdentityDbContext<IdentityUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Adventure> Adventures { get; set; }
        public DbSet<AdventurePlayer> AdventurePlayers { get; set; }
        public DbSet<Character> Characters { get; set; }
        public DbSet<CharacterClass> CharacterClasses  { get; set; }
        public DbSet<Player> Players { get; set; }
        public DbSet<Session> Sessions { get; set; }
        public DbSet<SessionPlayer> SessionPlayers { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.HasDefaultSchema("PR5");
            builder.Entity<Adventure>().ToTable("Adventure");
            builder.Entity<AdventurePlayer>().ToTable("AdventurePlayer");
            builder.Entity<Character>().ToTable("Character");
            builder.Entity<CharacterClass>().ToTable("CharacterClass");
            builder.Entity<Player>().ToTable("Player");
            builder.Entity<Session>().ToTable("Session");
            builder.Entity<SessionPlayer>().ToTable("SessionPlayer");
        }
    }
}
