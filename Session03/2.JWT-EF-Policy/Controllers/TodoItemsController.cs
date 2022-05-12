namespace TodoApi.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class TodoItemsController : ControllerBase
    {
        private readonly ITodoRepository _repo;

        public TodoItemsController(ITodoRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TodoDto>>> GetTodoItemsAsync()
        {
            return await _repo.GetAllTodosAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TodoDto>> GetTodoItem(int id)
        {
            return await _repo.GetTodoAsync(id);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutTodoItem([FromBody] TodoDto todoItem)
        {
            await _repo.UpdateTodoAsync(todoItem);
            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<TodoDto>> PostTodoItem([FromBody] TodoDto todoItem)
        {
            var newItem = await _repo.AddTodoAsync(todoItem);
            return CreatedAtAction("GetTodoItem", new { id = newItem.Id }, newItem);
        }

        [HttpDelete("{id}")]
        [Authorize(Policy = "Approver")]
        public async Task<IActionResult> DeleteTodoItem(int id)
        {
            await _repo.DeleteTodoAsync(id);
            return NoContent();
        }
   }
}