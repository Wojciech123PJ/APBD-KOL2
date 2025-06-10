using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;

namespace Kolokwium2.Models;

[Table("Match")]
public class Match
{
    [Key]
    public int MatchId { get; set; }
        
    [ForeignKey(nameof(Tournament))]
    public int TournamentId { get; set; }
    
    [ForeignKey(nameof(Map))]
    public int MapId { get; set; }
    
    public DateTime MatchDate { get; set; }
    
    public int Team1Score { get; set; }
    
    public int Team2Score { get; set; }
    
    [Precision(4, 2)]
    public decimal? BestRacting { get; set; }
    
    
    
    [JsonIgnore]
    public Tournament Tournament { get; set; }
    [JsonIgnore]
    public Map Map { get; set; }
    
    public ICollection<PlayerMatch> PlayerMatches { get; set; }
}