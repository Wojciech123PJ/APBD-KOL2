using Kolokwium2.Models;
using Microsoft.EntityFrameworkCore;

namespace Kolokwium2.Data;

public class DatabaseContext : DbContext
{
    public DbSet<Map> Maps { get; set; }
    public DbSet<Player> Players { get; set; }
    public DbSet<Tournament> Tournaments { get; set; }
    public DbSet<Match> Matches { get; set; }
    public DbSet<PlayerMatch> PlayerMatches { get; set; }


    protected DatabaseContext()
    {
    }

    public DatabaseContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Map>().HasData(new List<Map>
        {
            new Map
            {
                MapId = 1,
                Name = "Inferno",
                Type = "Defuse"
            },
            new Map
            {
                MapId = 2,
                Name = "Mirage",
                Type = "Defuse"
            },
            new Map
            {
                MapId = 3,
                Name = "Office",
                Type = "Hostage"
            }
        });

        modelBuilder.Entity<Player>().HasData(new List<Player>
        {
            new Player
            {
                PlayerId = 1,
                FirstName = "Alex",
                LastName = "Smith",
                BirthDate = new DateTime(2000, 5, 20),
            },
            new Player
            {
                PlayerId = 2,
                FirstName = "Filip",
                LastName = "Bielski",
                BirthDate = new DateTime(1980, 3, 27),
            }
        });

        modelBuilder.Entity<Tournament>().HasData(new List<Tournament>
        {
            new Tournament
            {
                TournamentId = 1,
                Name = "CS2 Summer Camp",
                StartDate = new DateTime(2025, 7, 2, 15, 0, 0),
                EndDate = new DateTime(2025, 7, 9, 15, 0, 0),
            },
            new Tournament
            {
                TournamentId = 2,
                Name = "CS2 Dreamhack Open",
                StartDate = new DateTime(2025, 11, 2, 15, 0, 0),
                EndDate = new DateTime(2025, 11, 9, 15, 0, 0),
            },
        });

        modelBuilder.Entity<Match>().HasData(new List<Match>
        {
            new Match
            {
                MatchId = 1,
                TournamentId = 1,
                MapId = 1,
                MatchDate = new DateTime(2025, 7, 3, 15, 0, 0),
            },
            new Match
            {
                MatchId = 2,
                TournamentId = 1,
                MapId = 2,
                MatchDate = new DateTime(2025, 7, 4, 15, 0, 0),
            }
        });

        modelBuilder.Entity<PlayerMatch>().HasData(new List<PlayerMatch>
        {
            new PlayerMatch
            {
                MatchId = 1,
                PlayerId = 1,
                MVPs = 1,
                Rating = 5.77m
            },
            new PlayerMatch
            {
                MatchId = 1,
                PlayerId = 2,
                MVPs = 0,
                Rating = 7.89m
            },
        });

        
    }
}