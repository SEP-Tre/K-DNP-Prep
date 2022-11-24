using System.ComponentModel.DataAnnotations;

namespace Domain.Dto;

public class ChildCreationDto
{
    [Required, MaxLength(50)] public string Name { get; set; }
    [Required, Range(3, 6)] public int Age { get; set; }
    [Required] public string Gender { get; set; }

    public ChildCreationDto(string name, int age, string gender)
    {
        Name = name;
        Age = age;
        Gender = gender;
    }

    public ChildCreationDto()
    {
    }
}