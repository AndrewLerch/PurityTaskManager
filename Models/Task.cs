using System.ComponentModel.DataAnnotations;
using PurityTaskManager.Attributes;

namespace PurityTaskManager.Models;

public class Task
{
    public int Id { get; set; }

    [Required]
    public string Title { get; set; } = string.Empty;

    public string? Description { get; set; } = string.Empty;

    [FutureDate]
    public DateTime DueDate { get; set; }

    public bool IsCompleted { get; set; } = false;
}