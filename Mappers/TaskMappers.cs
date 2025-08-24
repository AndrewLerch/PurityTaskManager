using PurityTaskManager.DTOs;
using Task = PurityTaskManager.Models.Task;

namespace PurityTaskManager.Mappers;

public static class TaskMappers
{
    public static TaskDto ToTaskDto(this Task task)
    {
        return new TaskDto
        {
            Id = task.Id,
            Title = task.Title,
            Description = task.Description,
            DueDate = task.DueDate,
            IsCompleted = task.IsCompleted
        };
    }

    public static Task ToTask(this CreateTaskDto dto)
    {
        return new Task
        {
            Title = dto.Title,
            Description = dto.Description,
            DueDate = dto.DueDate
        };
    }
}