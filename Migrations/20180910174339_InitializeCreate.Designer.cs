﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using dungeon;

namespace dungeon.Migrations
{
    [DbContext(typeof(DungeonContext))]
    [Migration("20180910174339_InitializeCreate")]
    partial class InitializeCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.2-rtm-30932")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("dungeon.Character", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Advancedmoves");

                    b.Property<string>("Alignment");

                    b.Property<int>("Armor");

                    b.Property<string>("Bonds");

                    b.Property<int>("Charisma");

                    b.Property<int>("Coin");

                    b.Property<int>("Constitution");

                    b.Property<int>("Damage");

                    b.Property<int>("Dexterity");

                    b.Property<string>("Gear");

                    b.Property<int>("Hitpoints");

                    b.Property<int>("Intelligence");

                    b.Property<int>("Level");

                    b.Property<string>("Looks");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<int>("PlayerId");

                    b.Property<string>("Race");

                    b.Property<string>("SessionId")
                        .IsRequired();

                    b.Property<string>("Spells");

                    b.Property<string>("Startingmoves");

                    b.Property<int>("Strength");

                    b.Property<int>("Wisdom");

                    b.Property<int>("XP");

                    b.HasKey("Id");

                    b.HasIndex("SessionId");

                    b.ToTable("Characters");
                });

            modelBuilder.Entity("dungeon.Log", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedAt");

                    b.Property<string>("Label")
                        .IsRequired();

                    b.Property<int>("PlayerId");

                    b.Property<string>("SessionId")
                        .IsRequired();

                    b.Property<string>("Text")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("SessionId");

                    b.ToTable("Logs");
                });

            modelBuilder.Entity("dungeon.Player", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("Players");
                });

            modelBuilder.Entity("dungeon.PlayerSession", b =>
                {
                    b.Property<int>("PlayerId");

                    b.Property<string>("SessionId");

                    b.HasKey("PlayerId", "SessionId");

                    b.HasIndex("SessionId");

                    b.ToTable("PlayerSessions");
                });

            modelBuilder.Entity("dungeon.Session", b =>
                {
                    b.Property<string>("Id");

                    b.Property<DateTime>("CreatedAt");

                    b.Property<int>("CreatorId");

                    b.Property<int>("DungeonMasterId");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<string>("Password");

                    b.HasKey("Id");

                    b.ToTable("Sessions");
                });

            modelBuilder.Entity("dungeon.Character", b =>
                {
                    b.HasOne("dungeon.Session", "Session")
                        .WithMany("Characters")
                        .HasForeignKey("SessionId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("dungeon.Log", b =>
                {
                    b.HasOne("dungeon.Session", "Session")
                        .WithMany("Logs")
                        .HasForeignKey("SessionId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("dungeon.PlayerSession", b =>
                {
                    b.HasOne("dungeon.Player", "Player")
                        .WithMany("PlayerSessions")
                        .HasForeignKey("PlayerId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("dungeon.Session", "Session")
                        .WithMany("PlayerSessions")
                        .HasForeignKey("SessionId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
