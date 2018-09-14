using System;
using System.Collections.Generic;
using System.Linq;
using System.Configuration;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace dungeon
{
    public class DungeonContext : DbContext
    {
        public DungeonContext(DbContextOptions<DungeonContext> options) : base(options) { }

        public DbSet<Player> Players { get; set; }
        public DbSet<Session> Sessions { get; set; }
        public DbSet<PlayerSession> PlayerSessions { get; set; }
        public DbSet<Character> Characters { get; set; }
        public DbSet<CharacterClass> CharacterClasses { get; set; }
        public DbSet<Log> Logs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PlayerSession>()
                .HasKey(ps => new { ps.PlayerId, ps.SessionId });

            modelBuilder.Entity<PlayerSession>()
                .HasOne(ps => ps.Player)
                .WithMany(p => p.PlayerSessions)
                .HasForeignKey(ps => ps.PlayerId);

            modelBuilder.Entity<PlayerSession>()
                .HasOne(ps => ps.Session)
                .WithMany(s => s.PlayerSessions)
                .HasForeignKey(ps => ps.SessionId);

            modelBuilder.Entity<Session>()
                .HasMany(s => s.Characters)
                .WithOne(c => c.Session);

            modelBuilder.Entity<Session>()
                .HasMany(s => s.Logs)
                .WithOne(l => l.Session);
        }
    }
}
    