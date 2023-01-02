using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace WebAPI.Model;

public class MockModel
{
    [Key]
    public string ValueOne { get; set; }
    [Required]
    public string ValueTwo { get; set; }
    [Range(1,5)]
    public int Rating { get; set; }
    [JsonIgnore]
    public ICollection<MockModelThree> Collection { get; set; }

    public MockModel()
    {
    }
}