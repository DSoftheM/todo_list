namespace TodoList.Domain;

public class Assignment
{
    public int Id { get; set; }

    public required string Title { get; set; }
    public required string Description { get; set; }
    public required DateTime Created { get; set; }
    public required AssignmentPriority Priority { get; set; }

    public DateTime? Completed { get; set; }
}

public class AssignmentSiteDTO
{
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime Created { get; set; }
    public DateTime? Completed { get; set; }
    public AssignmentPriority Priority { get; set; }
}

public static class AssignmentConverterExtension
{
    public static Assignment ToSiteDTO(this Assignment assignment)
    {
        return new Assignment()
        {
            Id = assignment.Id,
            Title = assignment.Title,
            Description = assignment.Description,
            Created = assignment.Created,
            Completed = assignment.Completed,
            Priority = assignment.Priority
        };
    }
}