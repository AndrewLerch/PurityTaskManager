using Microsoft.AspNetCore.Mvc;
using PurityTaskManager.DTOs;
using PurityTaskManager.Interfaces;
using PurityTaskManager.Mappers;
using PurityTaskManager.ViewModels;

namespace PurityTaskManager.Controllers;

public class TasksController : Controller
{
    private readonly ITaskRepository _repo;
    public TasksController(ITaskRepository repo)
    {
        _repo = repo;
    }

    public IActionResult Index(bool showCompleted = false)
    {
        // Retrieve all tasks from DB
        var tasks = _repo.GetTasks(showCompleted);
        // convert to DTO
        var taskDtos = tasks.Select(t => t.ToTaskDto());

        // Populate data into ViewModel
        var vm = new IndexViewModel();
        vm.Tasks = taskDtos.ToList();
        vm.ShowCompleted = showCompleted;

        // return view, complete with data
        return View(vm);
    }

    public IActionResult Create()
    {
        return View(new CreateTaskDto());
    }

    [HttpPost]
    public IActionResult Create(CreateTaskDto dto)
    {
        if (!ModelState.IsValid)
            return View(dto);

        _repo.AddTask(dto.ToTask());

        return RedirectToAction("Index", "Tasks");
    }

    [HttpPost]
    public IActionResult Complete(int id)
    {
        var task = _repo.CompleteTask(id);

        return RedirectToAction("Index", "Tasks");
    }
}