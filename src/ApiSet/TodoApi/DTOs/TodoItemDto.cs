using TodoApi.Models;

namespace TodoApi.DTOs;

public class TodoItemDto
{
    public TodoItemDto(TodoModel todoModelItem)
    {
        (Id, Name, IsComplete) = (todoModelItem.Id, todoModelItem.Name, todoModelItem.IsComplete);
    }

    public int Id { get; set; }

    public string? Name { get; set; }

    public bool IsComplete { get; set; }

    public TodoItemDto() { }
}