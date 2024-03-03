namespace TodoApi.Data
{
    using Microsoft.EntityFrameworkCore;
    using TodoApi.Models;

    public class TodoDb : DbContext
    {
        public TodoDb(DbContextOptions<TodoDb> options)
            : base(options) { }

        public DbSet<TodoModel> Todos => Set<TodoModel>();
    }
}
