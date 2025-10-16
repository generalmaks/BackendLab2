using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace BackendLab2.Models;

public class Record
{
    [Key]
    public int Id { get; init; }
    [Required]
    public required int UserId { get; set; }
    [ForeignKey(nameof(UserId)), JsonIgnore]
    public User? User { get; set; }
    [Required]
    public required int CategoryId { get; set; }
    [ForeignKey(nameof(CategoryId)), JsonIgnore]
    public Category? Category { get; set; }
    public required DateTime CreatedAt { get; set; } = DateTime.Now;
    public required decimal Expenses { get; set; }
}