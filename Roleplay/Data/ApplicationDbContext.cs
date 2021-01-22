using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PR5_Roleplay.Models;
using Roleplay.Areas.Identity.Data;

namespace Roleplay.Data
{
    public class ApplicationDbContext : IdentityDbContext<CustomUser>
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
            builder.Entity<Character>().Property(p => p.CharacterAge).IsRequired();
            builder.Entity<Character>().Property(p => p.FavouriteWeapon).IsRequired();
            

            //CharacterClass
            builder.Entity<CharacterClass>().ToTable("CharacterClass");
            builder.Entity<CharacterClass>().Property(p => p.CharacterClassName).IsRequired();
            builder.Entity<CharacterClass>().Property(p => p.CharacterClassDescription).IsRequired();
            builder.Entity<CharacterClass>().Property(p => p.CharacterClassIcon).IsRequired();
            builder.Entity<CharacterClass>().HasData(
                new CharacterClass
                {
                    CharacterClassID = 1,
                    CharacterClassName = "Barbarian",
                    CharacterClassIcon = "fas fa-dumbbell",
                    CharacterClassDescription = "Big, strong and reckless"
                },
                new CharacterClass
                {
                    CharacterClassID = 2,
                    CharacterClassName = "Bard",
                    CharacterClassIcon = "fas fa-guitar",
                    CharacterClassDescription = "Melodic and charismatic to the core"
                },
                new CharacterClass
                {
                    CharacterClassID = 3,
                    CharacterClassName = "Cleric",
                    CharacterClassIcon = "fas fa-plus-square",
                    CharacterClassDescription = "Healing wonder"
                },
                new CharacterClass
                {
                    CharacterClassID = 4,
                    CharacterClassName = "Fighter",
                    CharacterClassIcon = "fas fa-fist-raised",
                    CharacterClassDescription = "Weapons Master"
                },
                new CharacterClass
                {
                    CharacterClassID = 5,
                    CharacterClassName = "Monk",
                    CharacterClassIcon = "fas fa-praying-hands",
                    CharacterClassDescription = "religious with a punch"
                },
                new CharacterClass
                {
                    CharacterClassID = 6,
                    CharacterClassName = "Paladin",
                    CharacterClassIcon = "fas fa-jedi",
                    CharacterClassDescription = "There can be only one divine, mine"
                },
                new CharacterClass
                {
                    CharacterClassID = 7,
                    CharacterClassName = "Ranger",
                    CharacterClassIcon = "fas fa-bullseye",
                    CharacterClassDescription = "Expert marksman"
                },
                new CharacterClass
                 {
                     CharacterClassID = 8,
                     CharacterClassName = "Druid",
                     CharacterClassIcon = "fas fa-paw",
                     CharacterClassDescription = "In tune with nature and it's animals"
                 },
                new CharacterClass
                  {
                      CharacterClassID = 9,
                      CharacterClassName = "Rogue",
                      CharacterClassIcon = "fas fa-user-ninja",
                      CharacterClassDescription = "Sneaky thieving raskal"
                  },
                new CharacterClass
                  {
                      CharacterClassID = 10,
                      CharacterClassName = "Sorcerer",
                      CharacterClassIcon = "fas fa-hand-sparkles",
                      CharacterClassDescription = "Uncontrollable power at it's fingertips"
                  },
                new CharacterClass
                   {
                       CharacterClassID = 11,
                       CharacterClassName = "Wizard",
                       CharacterClassIcon = "fas fa-hat-wizard",
                       CharacterClassDescription = "Spelcaster that can keep it's cool"
                   }
            );

            //Player : moet niet worden aangemaakt tenzij uitbreiding spelersgroep
            builder.Entity<Player>().ToTable("Player"); 
            builder.Entity<Player>().Property(p => p.UserName).IsRequired();
            builder.Entity<Player>().Ignore(p => p.Name);
          

            builder.Entity<CustomUser>()
                .HasOne(p => p.player)
                .WithOne(c => c.CustomUser)
                .HasForeignKey<Player>(p => p.UserID);

            //Session
            builder.Entity<Session>().ToTable("Session");
            builder.Entity<Session>().Property(p => p.SessionGamemaster).IsRequired();
            builder.Entity<Session>().Property(p => p.Date).IsRequired();

            //SessionPlayer
            builder.Entity<SessionPlayer>().ToTable("SessionPlayer");
        }
    }
}
