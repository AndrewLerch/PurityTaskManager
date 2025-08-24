using Microsoft.EntityFrameworkCore;
using Task = PurityTaskManager.Models.Task;

namespace PurityTaskManager.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions options)
    : base(options) { }

    public DbSet<Task> Tasks { get; set; }
}