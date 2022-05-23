using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;
namespace NewProject.Model
{using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;
    public class TodoIteamContext : DbContext 
    {
        public TodoIteamContext(DbContextOptions<TodoIteamContext> options) : base(options)
        {

        }
        public DbSet<TodoItem> TodoItems { get; set; } = null!;
    }
}
