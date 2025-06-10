using Kolokwium2.Models;

namespace Kolokwium2.DTOs;

public class PlayerMatchesOutputDto
{
    public int PlayerId { get; set; }
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public DateTime BirthDate { get; set; }
    public ICollection<MatchesDto> Matches { get; set; }
}

public class MatchesDto
{
    public string Tournament { get; set; } = string.Empty;
    public string Map { get; set; } = string.Empty;
    public DateTime Date { get; set; }
    public int Mvps { get; set; }
    public decimal Rating { get; set; }
    public int Team1Score { get; set; }
    public int Team2Score { get; set; }
}