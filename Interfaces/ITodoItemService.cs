namespace TodoApi.Interfaces
{
	using TodoApi.Models;
	using System.Collections.Generic;
	using System.Threading.Tasks;

	public interface ITodoItemService
	{
		Task<IEnumerable<TodoItem>> GetAllTodoItemsAsync();
		Task<TodoItem?> GetTodoItemByIdAsync(int id);
		Task<TodoItem> CreateTodoItemAsync(TodoItem todoItem);
		Task<bool> UpdateTodoItemAsync(TodoItem todoItem);
		Task<bool> DeleteTodoItemAsync(int id);
	}
}
