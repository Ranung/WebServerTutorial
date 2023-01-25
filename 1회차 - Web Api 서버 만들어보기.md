## 궁금한 부분
#### null!
```C#
public class TodoContext : DbContext
{
    public TodoContext(DbContextOptions<TodoContext> options) : base(options)
    {
    }

    public DbSet<TodoItem> TodoItems { get; set; } = null!;
}
```
**TodoItems { get; set; } = null!;** 에서 null!를 하는 이유?