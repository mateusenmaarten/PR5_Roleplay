﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Roleplay.Data;

namespace Roleplay.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20201212171154_customPlayer")]
    partial class customPlayer
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("PR5")
                .HasAnnotation("ProductVersion", "3.1.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(128)")
                        .HasMaxLength(128);

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(128)")
                        .HasMaxLength(128);

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(128)")
                        .HasMaxLength(128);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(128)")
                        .HasMaxLength(128);

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("PR5_Roleplay.Models.Adventure", b =>
                {
                    b.Property<int>("AdventureID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Author")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Genre")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MainVillain")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Summary")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AdventureID");

                    b.ToTable("Adventure");
                });

            modelBuilder.Entity("PR5_Roleplay.Models.AdventurePlayer", b =>
                {
                    b.Property<int>("AdventurePlayerID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AdventureID")
                        .HasColumnType("int");

                    b.Property<int>("PlayerID")
                        .HasColumnType("int");

                    b.Property<bool>("isGameMaster")
                        .HasColumnType("bit");

                    b.HasKey("AdventurePlayerID");

                    b.HasIndex("AdventureID");

                    b.HasIndex("PlayerID");

                    b.ToTable("AdventurePlayer");
                });

            modelBuilder.Entity("PR5_Roleplay.Models.Character", b =>
                {
                    b.Property<int>("CharacterID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CharacterAge")
                        .HasColumnType("int");

                    b.Property<int>("CharacterClassID")
                        .HasColumnType("int");

                    b.Property<string>("CharacterDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CharacterGender")
                        .IsRequired()
                        .HasColumnType("nvarchar(1)");

                    b.Property<string>("CharacterName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FavouriteWeapon")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HomeTown")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PlayerID")
                        .HasColumnType("int");

                    b.HasKey("CharacterID");

                    b.HasIndex("CharacterClassID");

                    b.HasIndex("PlayerID");

                    b.ToTable("Character");
                });

            modelBuilder.Entity("PR5_Roleplay.Models.CharacterClass", b =>
                {
                    b.Property<int>("CharacterClassID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CharacterClassDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CharacterClassIcon")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CharacterClassName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CharacterClassID");

                    b.ToTable("CharacterClass");

                    b.HasData(
                        new
                        {
                            CharacterClassID = 1,
                            CharacterClassDescription = "Big, strong and reckless",
                            CharacterClassIcon = "fas fa-dumbbell",
                            CharacterClassName = "Barbarian"
                        },
                        new
                        {
                            CharacterClassID = 2,
                            CharacterClassDescription = "Melodic and charismatic to the core",
                            CharacterClassIcon = "fas fa-guitar",
                            CharacterClassName = "Bard"
                        },
                        new
                        {
                            CharacterClassID = 3,
                            CharacterClassDescription = "Healing wonder",
                            CharacterClassIcon = "fas fa-plus-square",
                            CharacterClassName = "Cleric"
                        },
                        new
                        {
                            CharacterClassID = 4,
                            CharacterClassDescription = "Weapons Master",
                            CharacterClassIcon = "fas fa-fist-raised",
                            CharacterClassName = "Fighter"
                        },
                        new
                        {
                            CharacterClassID = 5,
                            CharacterClassDescription = "religious with a punch",
                            CharacterClassIcon = "fas fa-praying-hands",
                            CharacterClassName = "Monk"
                        },
                        new
                        {
                            CharacterClassID = 6,
                            CharacterClassDescription = "There can be only one divine, mine",
                            CharacterClassIcon = "fas fa-jedi",
                            CharacterClassName = "Paladin"
                        },
                        new
                        {
                            CharacterClassID = 7,
                            CharacterClassDescription = "Expert marksman",
                            CharacterClassIcon = "fas fa-bullseye",
                            CharacterClassName = "Ranger"
                        },
                        new
                        {
                            CharacterClassID = 8,
                            CharacterClassDescription = "In tune with nature and it's animals",
                            CharacterClassIcon = "fas fa-paw",
                            CharacterClassName = "Druid"
                        },
                        new
                        {
                            CharacterClassID = 9,
                            CharacterClassDescription = "Sneaky thieving raskal",
                            CharacterClassIcon = "fas fa-user-ninja",
                            CharacterClassName = "Rogue"
                        },
                        new
                        {
                            CharacterClassID = 10,
                            CharacterClassDescription = "Uncontrollable power at it's fingertips",
                            CharacterClassIcon = "fas fa-hand-sparkles",
                            CharacterClassName = "Sorcerer"
                        },
                        new
                        {
                            CharacterClassID = 11,
                            CharacterClassDescription = "Spelcaster that can keep it's cool",
                            CharacterClassIcon = "fas fa-hat-wizard",
                            CharacterClassName = "Wizard"
                        });
                });

            modelBuilder.Entity("PR5_Roleplay.Models.Player", b =>
                {
                    b.Property<int>("PlayerID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Country")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsGameMaster")
                        .HasColumnType("bit");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PlayerID");

                    b.HasIndex("UserID")
                        .IsUnique()
                        .HasFilter("[UserID] IS NOT NULL");

                    b.ToTable("Player");
                });

            modelBuilder.Entity("PR5_Roleplay.Models.Session", b =>
                {
                    b.Property<int>("SessionID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AdventureID")
                        .HasColumnType("int");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int>("Duration")
                        .HasColumnType("int");

                    b.Property<bool>("IsPlayed")
                        .HasColumnType("bit");

                    b.Property<string>("Recap")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Time")
                        .HasColumnType("datetime2");

                    b.HasKey("SessionID");

                    b.HasIndex("AdventureID");

                    b.ToTable("Session");
                });

            modelBuilder.Entity("PR5_Roleplay.Models.SessionPlayer", b =>
                {
                    b.Property<int>("SessionPlayerID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("PlayerID")
                        .HasColumnType("int");

                    b.Property<int>("SessionID")
                        .HasColumnType("int");

                    b.HasKey("SessionPlayerID");

                    b.HasIndex("PlayerID");

                    b.HasIndex("SessionID");

                    b.ToTable("SessionPlayer");
                });

            modelBuilder.Entity("Roleplay.Areas.Identity.Data.CustomUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Roleplay.Areas.Identity.Data.CustomUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Roleplay.Areas.Identity.Data.CustomUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Roleplay.Areas.Identity.Data.CustomUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Roleplay.Areas.Identity.Data.CustomUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("PR5_Roleplay.Models.AdventurePlayer", b =>
                {
                    b.HasOne("PR5_Roleplay.Models.Adventure", "Adventure")
                        .WithMany("AdventurePlayers")
                        .HasForeignKey("AdventureID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PR5_Roleplay.Models.Player", "Player")
                        .WithMany("AdventurePlayers")
                        .HasForeignKey("PlayerID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("PR5_Roleplay.Models.Character", b =>
                {
                    b.HasOne("PR5_Roleplay.Models.CharacterClass", "CharacterClass")
                        .WithMany("Characters")
                        .HasForeignKey("CharacterClassID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PR5_Roleplay.Models.Player", "Player")
                        .WithMany("Characters")
                        .HasForeignKey("PlayerID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("PR5_Roleplay.Models.Player", b =>
                {
                    b.HasOne("Roleplay.Areas.Identity.Data.CustomUser", "CustomUser")
                        .WithOne("player")
                        .HasForeignKey("PR5_Roleplay.Models.Player", "UserID");
                });

            modelBuilder.Entity("PR5_Roleplay.Models.Session", b =>
                {
                    b.HasOne("PR5_Roleplay.Models.Adventure", "Adventure")
                        .WithMany("Sessions")
                        .HasForeignKey("AdventureID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("PR5_Roleplay.Models.SessionPlayer", b =>
                {
                    b.HasOne("PR5_Roleplay.Models.Player", "Player")
                        .WithMany("SessionPlayers")
                        .HasForeignKey("PlayerID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PR5_Roleplay.Models.Session", "Session")
                        .WithMany("SessionPlayers")
                        .HasForeignKey("SessionID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
