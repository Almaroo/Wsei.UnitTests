using Wsei.UnitTests.Models;
using Task = Wsei.UnitTests.Models.Task;

namespace Wsei.UnitTests.Repositories;

public class InMemoryTaskManager : ITaskManager
{
    private readonly List<Task> _items = new();
    private static int _itemId;

    public Task? GetTask(int id) => _items.FirstOrDefault(x => x.Id == id);

    public IEnumerable<Task> GetTasks() => _items.ToList();

    public int AddTask(Task item)
    {
        item.Id = _itemId++;
        _items.Add(item);
        return item.Id;
    }

    public bool RemoveTask(int id)
    {
        return _items.RemoveAll(x => x.Id == id) > 0;
    }

    public bool UpdateTask(int id, Task newTask)
    {
        var task = GetTask(id);
        if (task is null) return false;

        task.Title = newTask.Title;
        task.IsCompleted = newTask.IsCompleted;

        return true;
    }

    public bool MarkTaskAsCompleted(int id)
    {
        var task = GetTask(id);
        if (task is null) return false;

        task.IsCompleted = true;

        return true;
    }
}