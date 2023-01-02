using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Web_API.models;

public class Team
{
    [Key]
    public string TeamName { get; set; }
    [Required, MaxLength(50)]
    public string NameOfCoach { get; set; }
    public int Ranking { get; set; }
    public List<Player> Players { get; set; }

    public Team()
    {
        Players = new List<Player>();
    }
}