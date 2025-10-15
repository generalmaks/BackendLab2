using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BackendLab2.Models;

public class Record
{
    [Key]
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    [ForeignKey(nameof(UserId)), Required]
    public required User User { get; set; }
    public Guid CategoryId { get; set; }
    [ForeignKey(nameof(CategoryId)), Required]
    public required Category Category { get; set; }
    public required DateTime CreatedAt { get; set; } = DateTime.Now;
    public required decimal Expenses { get; set; }
}