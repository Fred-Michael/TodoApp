using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TodoApp.TodoApp.Application.Services;
using TodoApp.TodoApp.Domain;

namespace TodoApp.TodoApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoController : ControllerBase
    {
        private readonly TodoService _todoService;
        public TodoController(TodoService todoService)
        {
            _todoService = todoService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TodoItem>>> GetTodos()
        {
            var todos = await _todoService.GetAllTodoItemsAsync();
            return Ok(todos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TodoItem>> GetTodo(int id)
        {
            var todo = await _todoService.GetTodoItemAsync(id);
            if (todo == null)
                return NotFound("There were no todo items found");

            return Ok(todo);
        }

        [HttpPost]
        public async Task<ActionResult<TodoItem>> CreateTodo(TodoItem item)
        {
            var todoItem = await _todoService.AddTodoItemAsync(item);
            return CreatedAtAction(nameof(CreateTodo), new { id = todoItem?.Id }, todoItem);
        }
    }
}
