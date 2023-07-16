namespace Wsei.UnitTests.Models;

public class Task
{
    public int Id { get; set; }
    public string Title { get; set; }
    public bool IsCompleted { get; set; }

    public Task(string title)
    {
        Title = title;
        IsCompleted = false;
    }
}