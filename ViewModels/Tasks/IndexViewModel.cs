namespace PurityTaskManager.ViewModels;
using PurityTaskManager.DTOs;

public class IndexViewModel
{
    public IndexViewModel() { }

    public List<TaskDto> Tasks { get; set; } = new List<TaskDto>();

    public bool ShowCompleted { get; set; } = false;
}