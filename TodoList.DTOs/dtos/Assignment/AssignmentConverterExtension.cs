using TodoList.Domain;

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