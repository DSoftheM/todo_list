namespace TodoList.Domain;

public class Assignment
{
    public int Id { get; set; }

    public required string Title { get; set; }
    public required string Description { get; set; }
    public required DateTime Created { get; set; }
    public required AssignmentPriority Priority { get; set; }
    public required DateTime? Completed { get; set; }
}



