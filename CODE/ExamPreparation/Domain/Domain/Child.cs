using System.ComponentModel.DataAnnotations;

namespace Domain.Domain;

public class Child
{
    [Key]
    public int Id { get; set;}
    [Required, MaxLength(50)]
    public string Name { get; set;}
    [Required, Range(3,6)]
    public int Age { get; set;}
    [Required]
    public string Gender { get; set;}
    
    public ICollection<Toy> Toys { get; set; }

    public Child(int id, string name, int age, string gender)
    {
        Id = id;
        Name = name;
        Age = age;
        Gender = gender;
    }

    public Child()
    {
    }
}