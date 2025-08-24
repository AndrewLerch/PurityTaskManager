using PurityTaskManager.Data;
using PurityTaskManager.Interfaces;
using Task = PurityTaskManager.Models.Task;

namespace PurityTaskManager.Repositories;

public class TaskRepository : ITaskRepository
{
    private readonly ApplicationDbContext _context;

    public TaskRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public Task? GetTaskById(int id)
    {
        return _context.Tasks.FirstOrDefault(t => t.Id == id);
    }

    public List<Task> GetTasks(bool showCompleted = false)
    {
        var tasks = _context.Tasks.Where(t => t.IsCompleted == showCompleted);

        tasks = tasks.OrderBy(t => t.DueDate);

        return tasks.ToList();
    }

    public Task AddTask(Task task)
    {
        _context.Tasks.Add(task);
        _context.SaveChanges();

        return task;
    }

    public Task CompleteTask(int id)
    {
        var task = _context.Tasks.Find(id);
        if (task == null)
            return null;

        task.IsCompleted = true;
        _context.SaveChanges();
        return task;
    }
}