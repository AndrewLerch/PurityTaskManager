using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using PurityTaskManager.Attributes;

namespace PurityTaskManager.DTOs;

public class CreateTaskDto
{
    [Required]
    public string Title { get; set; }

    public string? Description { get; set; } = "";

    [Required]
    [DisplayName("Due Date")]
    [DataType(DataType.Date, ErrorMessage = "Must be a date")]
    [DisplayFormat(DataFormatString = "{0:dd/MM/yy}", ApplyFormatInEditMode = true)]
    [FutureDate]
    public DateTime DueDate { get; set; }
}