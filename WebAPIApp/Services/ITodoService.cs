using WebAPIApp.Models;

namespace WebAPIApp.Services
{
    public interface ITodoService
    {
        List<TodoItem> GetTodos();
        TodoItem GetTodoById(int id);
        bool UpdateTodoStatus(int id, string newStatus);
    }
}
