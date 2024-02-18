using Microsoft.EntityFrameworkCore;
using KanbanBlazorServer.Models;

namespace KanbanBlazorServer.Data
{
	public class ApplicationDbContext : DbContext
	{
		public DbSet<TaskData> Data { get; set; }

		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
		: base(options)
		{
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<TaskData>().HasData(
				new TaskData { Id = 1, Name = "Make dinner", Status = "To Do" },
				new TaskData { Id = 2, Name = "Clean kitchen", Status = "To Do" },
				new TaskData { Id = 3, Name = "Clean dishes and load dishwasher", Status = "To Do" },
				new TaskData { Id = 4, Name = "Exercise", Status = "In Process" },
				new TaskData { Id = 5, Name = "Make a journal entry", Status = "In Process" },
				new TaskData { Id = 6, Name = "Check morning email", Status = "In Process" },
				new TaskData { Id = 7, Name = "Make morning coffee", Status = "Done" }
			);
		}

	}
}
