using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BackendLab2.Models;

public class Record
{
    [Key]
    public int Id { get; set; }
    public int UserId { get; set; }
    [ForeignKey(nameof(UserId)), Required]
    public required User User { get; set; }
    public int CategoryId { get; set; }
    [ForeignKey(nameof(CategoryId)), Required]
    public required Category Category { get; set; }
    public required DateTime CreatedAt { get; set; } = DateTime.Now;
    public required decimal Expenses { get; set; }
}