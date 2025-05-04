using Microsoft.AspNetCore.Mvc;
using TodoApp.TodoApp.Application.Services;
using TodoApp.TodoApp.Domain;

namespace TodoApp.TodoApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodosController : ControllerBase
    {
        private readonly ITodoService _todoService;
        public TodosController(ITodoService todoService)
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
            {
                return NotFound();
            }

            return Ok(todo);
        }

        [HttpPost]
        public async Task<ActionResult<TodoItem>> CreateTodo([FromBody] TodoItem item)
        {
            var todoItem = await _todoService.AddTodoItemAsync(item);
            return CreatedAtAction(nameof(CreateTodo), new { id = todoItem?.Id }, todoItem);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<TodoItem>> UpdateTodo(int id, [FromBody] TodoItem item)
        {
            var todoItemToUpdate = await _todoService.UpdateTodoItemAsync(id, item);
            return todoItemToUpdate ? NoContent() : BadRequest();
        }

        [HttpPatch("{id}/complete")]
        public async Task<ActionResult<TodoItem>> CompleteTodo(int id)
        {
            var completeTodoItem = await _todoService.MarkToDoItemAsCompleteAsync(id);
            return completeTodoItem ? NoContent() : NotFound();
        }

        [HttpPatch("{id}/incomplete")]
        public async Task<ActionResult<TodoItem>> IncompleteTodo(int id)
        {
            var incompleteTodoItem = await _todoService.MarkTodoItemAsIncompleteAsync(id);
            return incompleteTodoItem ? NoContent() : NotFound();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteTodo(int id)
        {
            var deletedTodoItem = await _todoService.DeleteTodoItemAsync(id);
            return deletedTodoItem ? NoContent() : NotFound();
        }
    }
}
