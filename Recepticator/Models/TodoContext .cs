using Microsoft.EntityFrameworkCore;

namespace Recepticator.Models
{
    public class TodoContext : DbContext
    {
        public TodoContext(DbContextOptions<TodoContext> options)
            : base(options)
        {
        }

        public DbSet<Ingredient> Ingredients { get; set; }
    }
}