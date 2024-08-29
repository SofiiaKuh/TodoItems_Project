using Microsoft.EntityFrameworkCore;
using TodoApi.Data;
using TodoApi.Models;
using TodoApi.Interfaces;

namespace TodoApi.Services
{
	public class TodoItemService(TodoContext context) : ITodoItemService
	{
		private readonly TodoContext _context = context;

		public async Task<IEnumerable<TodoItem>> GetAllTodoItemsAsync()
		{
			return await _context.TodoItems.ToListAsync();
		}

		public async Task<TodoItem?> GetTodoItemByIdAsync(int id)
		{
			return await _context.TodoItems.FindAsync(id);
		}

		public async Task<TodoItem> CreateTodoItemAsync(TodoItem todoItem)
		{
			_context.TodoItems.Add(todoItem);
			await _context.SaveChangesAsync();
			return todoItem;
		}

		public async Task<bool> UpdateTodoItemAsync(TodoItem todoItem)
		{
			_context.Entry(todoItem).State = EntityState.Modified;
			try
			{
				await _context.SaveChangesAsync();
				return true;
			}
			catch (DbUpdateConcurrencyException)
			{
				if (!await TodoItemExists(todoItem.Id))
				{
					return false;
				}
				throw;
			}
		}

		public async Task<bool> DeleteTodoItemAsync(int id)
		{
			var todoItem = await _context.TodoItems.FindAsync(id);
			if (todoItem == null) return false;

			_context.TodoItems.Remove(todoItem);
			await _context.SaveChangesAsync();
			return true;
		}

		private async Task<bool> TodoItemExists(int id)
		{
			return await _context.TodoItems.AnyAsync(e => e.Id == id);
		}
	}
}
