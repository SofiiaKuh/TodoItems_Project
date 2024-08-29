using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using TodoApi.Models;
using TodoApi.Interfaces;

namespace TodoApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class TodoItemsController(ITodoItemService todoItemService) : ControllerBase
	{
		private readonly ITodoItemService _todoItemService = todoItemService;

		[HttpGet]
		public async Task<ActionResult<IEnumerable<TodoItem>>> GetTodoItems()
		{
			var items = await _todoItemService.GetAllTodoItemsAsync();
			return Ok(items);
		}

		[HttpGet("{id}")]
		public async Task<ActionResult<TodoItem>> GetTodoItem(int id)
		{
			var item = await _todoItemService.GetTodoItemByIdAsync(id);
			if (item == null) return NotFound();
			return Ok(item);
		}

		[HttpPost]
		public async Task<ActionResult<TodoItem>> PostTodoItem(TodoItem todoItem)
		{
			var item = await _todoItemService.CreateTodoItemAsync(todoItem);
			return CreatedAtAction(nameof(GetTodoItem), new { id = item.Id }, item);
		}

		[HttpPut("{id}")]
		public async Task<IActionResult> PutTodoItem(int id, TodoItem todoItem)
		{
			if (id != todoItem.Id) return BadRequest();

			var updated = await _todoItemService.UpdateTodoItemAsync(todoItem);
			if (!updated) return NotFound();

			return NoContent();
		}

		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteTodoItem(int id)
		{
			var deleted = await _todoItemService.DeleteTodoItemAsync(id);
			if (!deleted) return NotFound();

			return NoContent();
		}
	}
}
