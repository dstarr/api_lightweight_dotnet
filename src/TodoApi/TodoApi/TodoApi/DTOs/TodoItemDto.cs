using TodoApi.TodoApi.Models;

namespace TodoApi.TodoApi.DTOs;

public class TodoItemDto
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public bool IsComplete { get; set; }

    public TodoItemDto() { }
    public TodoItemDto(TodoModel todoModelItem) =>
        (Id, Name, IsComplete) = (todoModelItem.Id, todoModelItem.Name, todoModelItem.IsComplete);
}