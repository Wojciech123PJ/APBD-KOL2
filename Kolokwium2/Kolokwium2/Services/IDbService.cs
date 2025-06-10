using Kolokwium2.Data;
using Kolokwium2.DTOs;

namespace Kolokwium2.Services;

public interface IDbService
{
    Task<PlayerMatchesOutputDto> GetPlayerMatches(int playerId);
    Task AddPlayerMatches(PlayerMatchInputDto dto);
}