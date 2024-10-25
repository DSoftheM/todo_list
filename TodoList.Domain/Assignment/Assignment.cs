namespace TodoList.Domain;

public class Assignment(
    int id,
    string title,
    string description,
    DateTime created,
    DateTime? completed,
    AssignmentPriority priority)
{
    public int Id { get; set; } = id;
    public string Title { get; set; } = title;
    public string Description { get; set; } = description;
    public DateTime Created { get; set; } = created;
    public DateTime? Completed { get; set; } = completed;
    public AssignmentPriority Priority { get; set; } = priority;
}

public class AssignmentSiteDTO(
    string title,
    string description,
    DateTime created,
    DateTime? completed,
    AssignmentPriority priority)
{
    public string Title { get; set; } = title;
    public string Description { get; set; } = description;
    public DateTime Created { get; set; } = created;
    public DateTime? Completed { get; set; } = completed;
    public AssignmentPriority Priority { get; set; } = priority;
}

public static class AssignmentConverterExtension
{
    public static Assignment ToSiteDTO(this Assignment assignment)
    {
        return new Assignment(
            assignment.Id, assignment.Title, assignment.Description, assignment.Created,
            assignment.Completed, assignment.Priority);
    }
}