using System.ComponentModel.DataAnnotations;

namespace BackendLab2.Models;

public class Category
{
    [Key]
    public int Id { get; init; }

    [MaxLength(50)] public string Name { get; set; } = string.Empty;
}