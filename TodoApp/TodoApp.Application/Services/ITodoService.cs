using TodoApp.TodoApp.Domain;

namespace TodoApp.TodoApp.Application.Services
{
    public interface ITodoService
    {
        Task<IEnumerable<TodoItem>> GetAllTodoItemsAsync();
        Task<TodoItem?> GetTodoItemAsync(int id);
        Task<TodoItem?> AddTodoItemAsync(TodoItem itemToAdd);
        Task<bool> UpdateTodoItemAsync(int id, TodoItem itemToUpdate);
        Task<bool> MarkToDoItemAsCompleteAsync(int id);
        Task<bool> MarkTodoItemAsIncompleteAsync(int id);
        Task<bool> DeleteTodoItemAsync(int id);
    }
}
