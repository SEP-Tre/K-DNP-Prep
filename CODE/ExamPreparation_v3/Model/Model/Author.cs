using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Model;

public class Author
{
    [Key] public int Id { get; set; }
    [Required, MaxLength(15)] public string FirstName { get; set; }
    [Required, MaxLength(15)] public string LastName { get; set; }
    [JsonIgnore] public ICollection<Book> Books { get; set; }

    public Author(string firstName, string lastName)
    {
        Id = 0;
        FirstName = firstName;
        LastName = lastName;
        Books = new List<Book>();
    }

    public Author()
    {
        Id = 0;
        Books = new List<Book>();
    }
}