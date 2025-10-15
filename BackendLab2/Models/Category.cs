using System.ComponentModel.DataAnnotations;

namespace BackendLab2.Models;

public class Category
{
    [Key]
    public Guid Id { get; set; }

    [MaxLength(50)] public string Name { get; set; } = string.Empty;

    public ICollection<Record> Records { get; set; } = new List<Record>();
}