using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Web_API.models;

public class Player
{
    [Required,Key, MaxLength(50)]
    public string Name { get; set; }
    [Range(0,99)]
    public int ShirtNumber { get; set; }
    public decimal Salary { get; set; }
    public int GoalsThisSeason { get; set; }
    [Required]
    public string Position { get; set; }
    
    public string TeamName { get; set; }
    
    
}