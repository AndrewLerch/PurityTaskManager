using Task = PurityTaskManager.Models.Task;

namespace PurityTaskManager.Interfaces;

public interface ITaskRepository
{
    List<Task> GetTasks(bool includeCompleted = false);
    Task? GetTaskById(int id);
    Task AddTask(Task task);
    Task CompleteTask(int id);
}