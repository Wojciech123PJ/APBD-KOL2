namespace Kolokwium2.Data;

public class PlayerMatchInputDto
{
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public DateTime BirthDate { get; set; }
    public ICollection<MatchDto> Matches { get; set; }
}

public class MatchDto
{
    public int MatchId { get; set; }
    public int Mvps { get; set; }
    public decimal Rating { get; set; }
}