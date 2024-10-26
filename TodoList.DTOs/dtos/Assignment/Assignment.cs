using TodoList.Domain;

namespace TodoList.DTOs.dtos;

public class AssignmentSiteDTO
{
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime Created { get; set; }
    public DateTime? Completed { get; set; }

    public AssignmentPriority Priority { get; set; } = AssignmentPriority.Medium;
    // Добавить состояние задачи   
}