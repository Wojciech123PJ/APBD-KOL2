using System.ComponentModel.DataAnnotations;

namespace Kolokwium2.Data;

public class PlayerMatchInputDto
{
    [Required]
    public string FirstName { get; set; } = string.Empty;
    [Required]
    public string LastName { get; set; } = string.Empty;
    [Required]
    public DateTime BirthDate { get; set; }
    [Required]
    public ICollection<MatchDto> Matches { get; set; }
}

public class MatchDto
{
    [Required]
    public int MatchId { get; set; }
    [Required]
    public int Mvps { get; set; }
    [Required]
    public decimal Rating { get; set; }
}