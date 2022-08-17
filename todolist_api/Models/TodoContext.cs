using Microsoft.EntityFrameworkCore;

namespace todolist_api.Models
{
    public class TodoContext : DbContext
    {
        private string connectionString;
        public TodoContext(String connString)
        {
            this.connectionString = connString;
        }

        public DbSet<TodoItem> TodoItems { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL(connectionString);
        }

    }
}
