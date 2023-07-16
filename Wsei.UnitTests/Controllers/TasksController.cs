using Microsoft.AspNetCore.Mvc;
using Wsei.UnitTests.Models;
using Wsei.UnitTests.Repositories;

namespace Wsei.UnitTests.Controllers;

[ApiController]
[Route("[controller]")]
public class TasksController : ControllerBase
{
    private readonly ITaskManager _taskManager;

    public TasksController(ITaskManager taskManager)
    {
        _taskManager = taskManager;
    }

    [HttpGet]
    public IActionResult GetAll() => Ok(_taskManager.GetTasks());

    [HttpGet]
    [Route("{id:int}")]
    public IActionResult Get(int id)
    {
        var result = _taskManager.GetTask(id);

        return result is not null ? Ok(result) : NotFound();
    }

    [HttpPost]
    public IActionResult Create([FromBody] CreateTaskDto dto)
    {
        var id = _taskManager.AddTask(new Models.Task(dto.Title));
        return Created("", id);
    }

    [HttpPut]
    public IActionResult Update([FromBody] UpdateTaskDto dto)
    {
        var success = _taskManager.UpdateTask(dto.Id, new Models.Task(dto.Title) {IsCompleted = dto.IsCompleted});

        return success ? NoContent() : NotFound();
    }
    
    [HttpDelete]
    [Route("{id:int}")]
    public IActionResult Delete(int id)
    {
        var success = _taskManager.RemoveTask(id);

        return success ? NoContent() : NotFound();
    }
}