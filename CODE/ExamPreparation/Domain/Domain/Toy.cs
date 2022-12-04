using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Domain.Domain;

public class Toy
{
    [Key]
    public int Id { get; set; }
    [Required, MaxLength(20)]
    public string Name{ get; set; }
    public string Color{ get; set; }
    public string Condition{ get; set; }
    public bool IsFavourite{ get; set; }
    
    public int ChildId { get; set; }

    public Toy(int id, string name, string color, string condition, bool isFavourite)
    {
        Id = id;
        Name = name;
        Color = color;
        Condition = condition;
        IsFavourite = isFavourite;
    }

    public Toy()
    {
    }
}