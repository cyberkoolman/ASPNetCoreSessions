public class TodoEntity
{
    public int Id { get; set; }
    public string TaskTitle { get; set; }
    public string TaskDesc { get; set; }
    public bool IsComplete { get; set; }
    public string TaskTo { get; set; }
    public string Rating { get; set; }
    public bool ToPublish { get; set; }
}