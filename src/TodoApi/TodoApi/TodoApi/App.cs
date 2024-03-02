using Microsoft.EntityFrameworkCore;
using TodoApi.TodoApi.Data;
using TodoApi.TodoApi.DTOs;
using TodoApi.TodoApi.Models;

namespace TodoApi.TodoApi
{
    public class App
    {
        public App(RouteGroupBuilder routeGroupBuilder)
        {
            if (routeGroupBuilder == null) throw new ArgumentNullException(nameof(routeGroupBuilder));

            routeGroupBuilder.MapGet("/", GetAllTodos);
            routeGroupBuilder.MapGet("/complete", GetCompleteTodos);
            routeGroupBuilder.MapGet("/{id}", GetTodo);
            routeGroupBuilder.MapPost("/", CreateTodo);
            routeGroupBuilder.MapPut("/{id}", UpdateTodo);
            routeGroupBuilder.MapDelete("/{id}", DeleteTodo);
        }

        public async Task<IResult> GetAllTodos(TodoDb db)
        {
            return TypedResults.Ok(await db.Todos.Select(x => new TodoItemDto(x)).ToArrayAsync());
        }

        public async Task<IResult> GetCompleteTodos(TodoDb db)
        {
            return TypedResults.Ok(await db.Todos.Where(t => t.IsComplete).Select(x => new TodoItemDto(x)).ToListAsync());
        }

        public async Task<IResult> GetTodo(int id, TodoDb db)
        {
            return await db.Todos.FindAsync(id)
                is TodoModel todo
                ? TypedResults.Ok(new TodoItemDto(todo))
                : TypedResults.NotFound();
        }

        public async Task<IResult> CreateTodo(TodoItemDto todoItemDTO, TodoDb db)
        {
            var todoItem = new TodoModel
            {
                IsComplete = todoItemDTO.IsComplete,
                Name = todoItemDTO.Name
            };

            db.Todos.Add(todoItem);
            await db.SaveChangesAsync();

            todoItemDTO = new TodoItemDto(todoItem);

            return TypedResults.Created($"/todoitems/{todoItem.Id}", todoItemDTO);
        }

        public async Task<IResult> UpdateTodo(int id, TodoItemDto todoItemDTO, TodoDb db)
        {
            var todo = await db.Todos.FindAsync(id);

            if (todo is null) return TypedResults.NotFound();

            todo.Name = todoItemDTO.Name;
            todo.IsComplete = todoItemDTO.IsComplete;

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
