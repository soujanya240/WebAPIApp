using Microsoft.AspNetCore.Mvc;
using WebAPIApp.Exceptions;
using WebAPIApp.Services;

namespace WebAPIApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoController : ControllerBase
    {
        private readonly ITodoService _todoService;

        public TodoController(ITodoService todoService)
        {
            _todoService = todoService;
        }
        /// <summary>
        /// Retrieves all to-do items.
        /// </summary>
        /// <returns>List of to-do items.</returns>
        // GET: api/todo
        
        [HttpGet]
        public IActionResult GetTodos()
        {
            try
            {
                var todos = _todoService.GetTodos();
                return Ok(todos);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message }); // Internal Server Error
            }
        }

        // GET: api/todo/5
        [HttpGet("{id}")]
        public IActionResult GetTodoById(int id)
        {
            try
            {
                var todo = _todoService.GetTodoById(id);
                return Ok(todo);
            }
            catch (TodoNotFoundException ex)
            {
                return NotFound(new { message = ex.Message }); // 404 Not Found
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message }); // Internal Server Error
            }
        }

        // PUT: api/todo/5
        [HttpPut("{id}")]
        public IActionResult UpdateTodoStatus(int id, [FromBody] string status)
        {
            try
            {
                var isUpdated = _todoService.UpdateTodoStatus(id, status);
                if (!isUpdated)
                {
                    return NotFound(new { message = $"Todo item with ID {id} was not found." });
                }
                return NoContent(); // Status 204 for successful update
            }
            catch (TodoNotFoundException ex)
            {
                return NotFound(new { message = ex.Message }); // 404 Not Found
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message }); // Internal Server Error
            }
        }
    }
}
