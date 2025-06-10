using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;

namespace Kolokwium2.Models;

[PrimaryKey(nameof(MatchId), nameof(PlayerId))]
[Table("Player_Match")]
public class PlayerMatch
{
    [ForeignKey(nameof(Match))]
    public int MatchId { get; set; }
    
    [ForeignKey(nameof(Player))]
    public int PlayerId { get; set; }
    
    public int MVPs { get; set; }
    
    [Precision(4, 2)]
    public decimal Rating { get; set; }
    
    
    [JsonIgnore]
    public Match Match { get; set; }
    [JsonIgnore]
    public Player Player { get; set; }
}