using Microsoft.EntityFrameworkCore;
using TodoApp.TodoApp.Domain;
using TodoApp.TodoApp.Infrastructure.DataContext;

namespace TodoApp.TodoApp.Application.Services
{
    public class TodoService : ITodoService
    {
        private readonly TodoContext _context;
        public TodoService(TodoContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<TodoItem>> GetAllTodoItemsAsync()
        {
            return await _context.Todos.ToListAsync();
        }

        public async Task<TodoItem?> GetTodoItemAsync(int id)
        {
            return await _context.Todos.FindAsync(id);
        }

        public async Task<TodoItem?> AddTodoItemAsync(TodoItem itemToAdd)
        {
            _context.Todos.Add(itemToAdd);
            await _context.SaveChangesAsync();
            return itemToAdd;
        }

        public async Task<bool> UpdateTodoItemAsync(int id, TodoItem itemToUpdate)
        {
            if (id != itemToUpdate.Id)
            {
                return false;
            }
            _context.Entry(itemToUpdate).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteTodoItemAsync(int id)
        {
            var todo = await _context.Todos.FindAsync(id);
            if (todo == null)
            {
                return false;
            }
            _context.Todos.Remove(todo);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> MarkToDoItemAsCompleteAsync(int id)
        {
            var todo = await _context.Todos.FindAsync(id);
            if (todo == null)
            {
                return false;
            }
            todo.IsCompleted = true;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> MarkTodoItemAsIncompleteAsync(int id)
        {
            var todo = await _context.Todos.FindAsync(id);
            if (todo == null)
            {
                return false;
            }
            todo.IsCompleted = false;
            await _context.SaveChangesAsync();
            return true;
        }

    }
}
