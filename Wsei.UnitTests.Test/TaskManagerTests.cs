using Wsei.UnitTests.Repositories;

namespace Wsei.UnitTests.Test;

public class TaskManagerTests
{
    private ITaskManager _taskManager;
    
    [SetUp]
    public void Setup()
    {
        _taskManager = new InMemoryTaskManager();
    }

    [Test]
    public void AddTask_ShouldIncreaseTaskCount()
    {
        // Arrange
        var task = new Models.Task("Test1");

        // Act
        _taskManager.AddTask(task);

        // Assert
        Assert.That(_taskManager.GetTasks().Count(), Is.EqualTo(1));

    }

    [Test]
    public void RemoveTask_ExistingTask_ShouldDecreaseTaskCount()
    {
        // Arrange
        var task = new Models.Task("Test1");
        
        // Act
        var taskId = _taskManager.AddTask(task);
        var success = _taskManager.RemoveTask(taskId);
        
        // Assert
        Assert.That(success);
        Assert.That(_taskManager.GetTasks().Count(), Is.EqualTo(0));
        
    }
    
    [Test]
    public void RemoveTask_NonExistingTask_ShouldNotChangeTaskCount()
    {
        // Arrange
        var task = new Models.Task("Test1");
        
        // Act
        var taskId = _taskManager.AddTask(task);
        var success = _taskManager.RemoveTask(taskId + 100);
        
        // Assert
        Assert.That(success, Is.False);
        Assert.That(_taskManager.GetTasks().Count(), Is.EqualTo(1));
    }

    [Test]
    public void MarkTaskAsCompleted_ExistingTask_ShouldMarkTaskAsCompleted()
    {
        // Arrange
        var task = new Models.Task("Test1");
        
        // Act
        var taskId = _taskManager.AddTask(task);
        var success = _taskManager.MarkTaskAsCompleted(taskId);
        var completed = _taskManager.GetTask(taskId)!;
        
        // Assert
        Assert.That(success);
        Assert.That(_taskManager.GetTasks().Count(), Is.EqualTo(1));
        Assert.That(completed.IsCompleted);
    }
    
    [Test]
    public void GetTasks_ShouldReturnAllTasks()
    {
        // Arrange
        var task1 = new Models.Task("Test1");
        var task2 = new Models.Task("Test2");
        
        // Act
        _taskManager.AddTask(task1);
        _taskManager.AddTask(task2);

        // Assert
        Assert.That(_taskManager.GetTasks().Count(), Is.EqualTo(2));
    }
}