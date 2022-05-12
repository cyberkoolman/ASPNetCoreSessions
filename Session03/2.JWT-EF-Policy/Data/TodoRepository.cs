public interface ITodoRepository
{
    Task<List<TodoDto>> GetAllTodosAsync();
    Task<TodoDto> GetTodoAsync(int id);
    Task UpdateTodoAsync(TodoDto todo);
    Task<TodoDto> AddTodoAsync(TodoDto dto);
    Task DeleteTodoAsync(int id);
    Task<List<UserDto>> GetAllUsersAsync();
    Task<UserDto> GetUserAsync(string userName, string password);
}

public class TodoRepository : ITodoRepository
{
    private readonly TodoDbContext _context;

    public TodoRepository(TodoDbContext context)
    {
        _context = context;
    }

    private static TodoDto TodoEntityToDto(TodoEntity todo)
    {
        return new TodoDto(todo.Id, todo.TaskTitle, todo.TaskDesc, todo.IsComplete, todo.TaskTo);
    }

    private static void TodoDtoToEntity(TodoDto dto, TodoEntity e)
    {
        e.Id = dto.Id;
        e.TaskTitle = dto.TaskTitle;
        e.TaskDesc = dto.TaskDesc;
        e.IsComplete = dto.IsComplete;
        e.TaskTo = dto.TaskTo;
    }

    public async Task<List<TodoDto>> GetAllTodosAsync()
    {
        return await _context.todos.Select(t => TodoEntityToDto(t)).ToListAsync();
    }

    public async Task<TodoDto> GetTodoAsync(int id)
    {
        var todo = await _context.todos.SingleOrDefaultAsync(t => t.Id == id);
        if (todo == null) return null;
        return TodoEntityToDto(todo);
    }

    public async Task UpdateTodoAsync(TodoDto todo)
    {
        var entity = await _context.todos.FindAsync(todo.Id);
        if (entity == null)
            throw new ArgumentException($"Error on update ToDo.");
        TodoDtoToEntity(todo, entity);
        _context.Entry(entity).State = EntityState.Modified;
        await _context.SaveChangesAsync();    
    }

    public async Task<TodoDto> AddTodoAsync(TodoDto todo)
    {
        var entity = new TodoEntity();
        TodoDtoToEntity(todo, entity);
        _context.todos.Add(entity);
        await _context.SaveChangesAsync();
        return TodoEntityToDto(entity);
    }    

    public async Task DeleteTodoAsync(int id)
    {
        var entity = await _context.todos.FindAsync(id);
        if (entity == null)
            throw new ArgumentException("Error on deleting the entity");
        _context.todos.Remove(entity);
        await _context.SaveChangesAsync();
    }

    private bool TodoItemExists(int id)
    {
        return _context.todos.Any(t => t.Id == id);
    }

    public async Task<List<UserDto>> GetAllUsersAsync()
    {
        return await _context.users.Select(t =>
            new UserDto(t.Id, t.UserName, t.FirstName, t.LastName, t.Role)).ToListAsync();
    }

    public async Task<UserDto> GetUserAsync(string userName, string password)
    {
        var user = await _context.users.SingleOrDefaultAsync(u =>
                (u.UserName == userName) && (u.Password == password));
        if (user == null) return null;
        return new UserDto(user.Id, userName, user.FirstName, user.LastName, user.Role);
    }
}