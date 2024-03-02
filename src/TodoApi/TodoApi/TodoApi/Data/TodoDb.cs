using TodoApi.TodoApi.Models;

namespace TodoApi.TodoApi.Data
{
    using Microsoft.EntityFrameworkCore;
    
    public class TodoDb : DbContext
    {
        public TodoDb(DbContextOptions<TodoDb> options)
            : base(options) { }

        public DbSet<TodoModel> Todos => Set<TodoModel>();
    }
}
