using System.Collections.Generic;
using WebAPIApp.Models;
using WebAPIApp.Exceptions;
using WebAPIApp.Models;
using WebAPIApp.Services;

namespace WebAPIApp.Services
{
    public class TodoService : ITodoService
    {
        private readonly List<TodoItem> _todos;

        public TodoService()
        {
            _todos = new List<TodoItem>
            {
                new TodoItem { Id = 1, Name = "Buy groceries", Status = "Pending" },
                new TodoItem { Id = 2, Name = "Complete homework", Status = "Completed" },
                new TodoItem { Id = 3, Name = "Walk the dog", Status = "Pending" }
            };
        }

        public List<TodoItem> GetTodos()
        {
            return _todos;
        }

        public TodoItem GetTodoById(int id)
        {
            var todo = _todos.Find(t => t.Id == id);
            if (todo == null)
            {
                throw new TodoNotFoundException(id);
            }
            return todo;
        }

        public bool UpdateTodoStatus(int id, string newStatus)
        {
            var todo = _todos.Find(t => t.Id == id);
            if (todo == null)
            {
                throw new TodoNotFoundException(id);
            }
            todo.Status = newStatus;
            return true;
        }
    }
}
