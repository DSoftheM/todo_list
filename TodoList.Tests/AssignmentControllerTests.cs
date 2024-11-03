using Microsoft.EntityFrameworkCore;
using Moq;
using TodoList.Controllers;
using TodoList.DAL;
using TodoList.Domain;
using TodoList.DTOs.dtos;
using TodoList.Services;

namespace TodoList.Tests;

public class AssignmentControllerTests() : IDisposable
{
    private readonly List<Assignment> _users = new()
    {
        new Assignment()
        {
            Id = 1,
            Completed = null,
            Created = DateTime.Now,
            Description = "Description",
            Priority = AssignmentPriority.Low,
            Title = "Title",
        },

        new Assignment()
        {
            Id = 2,
            Completed = null,
            Created = DateTime.Now,
            Description = "Description",
            Priority = AssignmentPriority.Low,
            Title = "Title",
        },
    };

    [Fact]
    public async void Test1()
    {
        var service = GetService();
        Assert.Empty(await service.GetAll());
    }

    [Fact]
    public async void Test2()
    {
        var service = GetService();

        await service.Create(new AssignmentSiteDTO()
            { Title = "Title", Description = "Description", Priority = AssignmentPriority.Low });

        Assert.Single(await service.GetAll());
    }

    private static AssignmentService GetService()
    {
        var context = ContextGenerator.GetContext();
        return new AssignmentService(context);
    }

    public void Dispose()
    {
    }
}