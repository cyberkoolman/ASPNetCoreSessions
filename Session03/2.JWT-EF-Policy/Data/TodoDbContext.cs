public class TodoDbContext : DbContext
{
    public TodoDbContext(DbContextOptions<TodoDbContext> o) : base(o) {}
    public DbSet<TodoEntity> todos => Set<TodoEntity>();
    public DbSet<UserEntity> users => Set<UserEntity>();

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var folder = Environment.SpecialFolder.LocalApplicationData;
        var path = Environment.GetFolderPath(folder);
        optionsBuilder.UseSqlite($"Data Source={Path.Join(path, "todo.db")}");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        SeedData.Seed(modelBuilder);
    }
}