using Kolokwium2.Data;
using Kolokwium2.DTOs;
using Kolokwium2.Models;
using Microsoft.EntityFrameworkCore;

namespace Kolokwium2.Services;

public class DbService : IDbService
{
    private readonly DatabaseContext _context;
    
    public DbService(DatabaseContext context)
    {
        _context = context;
    }

    public async Task AddPlayerMatches(PlayerMatchInputDto dto)
    {
        using var transaction = await _context.Database.BeginTransactionAsync();

        try
        {
            var player = new Player
            {
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                BirthDate = dto.BirthDate,
            };
            await _context.Players.AddAsync(player);
            await _context.SaveChangesAsync();
            
            foreach (var match in dto.Matches)
            {
                var matchExists = await _context.Matches.FirstOrDefaultAsync(m => m.MatchId == match.MatchId);
                if (matchExists == null)
                    throw new ArgumentException($"Match with ID {match.MatchId} not found. ");
                
                var playerMatch = new PlayerMatch
                {
                    MatchId = match.MatchId, // ???
                    // Match = matchExists, // ????
                    PlayerId = player.PlayerId, 
                    MVPs = match.Mvps,
                    Rating = match.Rating,
                };
                await _context.PlayerMatches.AddAsync(playerMatch);
                
                // Check bestRating
                if (matchExists.BestRacting < match.Rating)
                    matchExists.BestRacting = match.Rating;
            }
            
            await _context.SaveChangesAsync();
            await transaction.CommitAsync();
        }
        catch (Exception ex)
        {
            await transaction.RollbackAsync();
            throw;
        }
    }

    public async Task<PlayerMatchesOutputDto> GetPlayerMatches(int playerId)
    {
        var playerMatchesOutputDto = await _context.Players
            .Where(p => p.PlayerId == playerId)
            .Select(p => new PlayerMatchesOutputDto
            {
                PlayerId = p.PlayerId,
                FirstName = p.FirstName,
                LastName = p.LastName,
                BirthDate = p.BirthDate,
                Matches = p.PlayerMatches.Select(pm => new MatchesDto()
                {
                    Tournament = pm.Match.Tournament.Name,
                    Map = pm.Match.Map.Name,
                    Date = pm.Match.MatchDate,
                    Mvps = pm.MVPs,
                    Rating = pm.Rating,
                    Team1Score = pm.Match.Team1Score,
                    Team2Score = pm.Match.Team2Score,
                }).ToList()
            }).FirstOrDefaultAsync();

        if (playerMatchesOutputDto is null)
            throw new ArgumentException($"Player with ID {playerId} not found");
        
        return playerMatchesOutputDto;
    }
}