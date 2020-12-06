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
            //Adventure
            builder.Entity<Adventure>().ToTable("Adventure");
            builder.Entity<Adventure>().Property(p => p.Title).IsRequired();
            builder.Entity<Adventure>().Property(p => p.Summary).IsRequired();
            builder.Entity<Adventure>().Property(p => p.Author).IsRequired();

            //AdventurePlayer
            builder.Entity<AdventurePlayer>().ToTable("AdventurePlayer");

            //Character
            builder.Entity<Character>().ToTable("Character");
            builder.Entity<Character>().Property(p => p.CharacterName).IsRequired();
            builder.Entity<Character>().Property(p => p.CharacterDescription).IsRequired();
            builder.Entity<Character>().Property(p => p.CharacterName).IsRequired();

            //CharacterClass
            builder.Entity<CharacterClass>().ToTable("CharacterClass");
            builder.Entity<CharacterClass>().Property(p => p.CharacterClassName).IsRequired();
            builder.Entity<CharacterClass>().Property(p => p.CharacterClassDescription).IsRequired();
            builder.Entity<CharacterClass>().Property(p => p.CharacterClassIcon).IsRequired();

            //Player
            builder.Entity<Player>().ToTable("Player");
            builder.Entity<Player>().Property(p => p.Email).IsRequired();
            builder.Entity<Player>().Property(p => p.UserName).IsRequired();
            builder.Entity<Player>().Property(p => p.Password).IsRequired();

            //Session
            builder.Entity<Session>().ToTable("Session");

            //SessionPlayer
            builder.Entity<SessionPlayer>().ToTable("SessionPlayer");
        }
    }
}
