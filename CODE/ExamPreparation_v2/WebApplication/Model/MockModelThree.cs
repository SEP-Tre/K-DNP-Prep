using System.ComponentModel.DataAnnotations;

namespace WebAPI.Model;

public class MockModelThree
{
    [Key]
    public string Name { get; set; }
    public string MockModelValueOne { get; set; }

    public MockModelThree()
    {
    }
}