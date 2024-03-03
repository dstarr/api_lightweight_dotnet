using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using TodoApi.Data;
using TodoApi.DTOs;
using TodoApi.Models;

namespace TodoApi
{
    public class TodoApiApplication
    {
        public async Task<IResult> GetAllTodos(TodoDb db)
        {
            return TypedResults.Ok(await db.Todos.Select(x => new TodoItemDto(x)).ToArrayAsync());
        }

        public async Task<IResult> GetCompleteTodos(TodoDb db)
        {
            var todoItemDtos = await db.Todos
                .Where(t => t.IsComplete)
                .Select(x => new TodoItemDto(x))
                .ToListAsync();

            return TypedResults.Ok(todoItemDtos);
        }

        public async Task<IResult> GetTodo(int id, TodoDb db)
        {
            return await db.Todos.FindAsync(id)
                is TodoModel todo
                ? TypedResults.Ok(new TodoItemDto(todo))
                : TypedResults.NotFound();
        }

        public async Task<IResult> CreateTodo(TodoItemDto todoItemDto, TodoDb db)
        {
            var todoItem = new TodoModel
            {
                IsComplete = todoItemDto.IsComplete,
                Name = todoItemDto.Name
            };

            db.Todos.Add(todoItem);
            await db.SaveChangesAsync();

            todoItemDto = new TodoItemDto(todoItem);

            return TypedResults.Created($"/{todoItem.Id}", todoItemDto);
        }

        public async Task<IResult> UpdateTodo(int id, TodoItemDto todoItemDto, TodoDb db)
        {
            var todo = await db.Todos.FindAsync(id);

            if (todo is null) return TypedResults.NotFound();

            todo.Name = todoItemDto.Name;
            todo.IsComplete = todoItemDto.IsComplete;

            await db.SaveChangesAsync();

            return TypedResults.NoContent();
        }

        public async Task<IResult> DeleteTodo(int id, TodoDb db)
        {
            if (await db.Todos.FindAsync(id) is TodoModel todo)
            {
                db.Todos.Remove(todo);
                await db.SaveChangesAsync();
                return TypedResults.NoContent();
            }

            return TypedResults.NotFound();
        }


    }
}
