using Wsei.UnitTests.Models;
using Task = Wsei.UnitTests.Models.Task;

namespace Wsei.UnitTests.Repositories;

public interface ITaskManager
{
    public Task? GetTask(int id);
    public IEnumerable<Task> GetTasks();
    public int AddTask(Task item);
    public bool RemoveTask(int id);
    public bool UpdateTask(int id, Task newTask);
    public bool MarkTaskAsCompleted(int id);
}