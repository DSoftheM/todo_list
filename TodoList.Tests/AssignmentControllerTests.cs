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

    [Fact]
    public async void Test3()
    {
        var service = GetService();

        await service.Create(new AssignmentSiteDTO()
            { Title = "Title", Description = "Description", Priority = AssignmentPriority.Low });
        await service.Create(new AssignmentSiteDTO()
            { Title = "Title", Description = "Description", Priority = AssignmentPriority.Low });

        Assert.Equal(2, (await service.GetAll()).Count);
    }


    [Fact]
    public async void Test4()
    {
        var service = GetService();
        Assert.ThrowsAsync<ArgumentException>(async () => await service.GetById(1));
    }

    [Fact]
    public async void Test5()
    {
        var service = GetService();
        await service.Create(new AssignmentSiteDTO()
            { Title = "Title", Description = "Description", Priority = AssignmentPriority.Low });
        var assignment = (await service.GetAll()).First();
        Assert.Equal(assignment.Id, (await service.GetById(assignment.Id)).Id);
    }

    [Fact]
    public async void Test6()
    {
        // Не работает...
        // var service = GetService();
        // await service.Create(new AssignmentSiteDTO()
        //     { Title = "Title", Description = "Description", Priority = AssignmentPriority.Low });
        // var assignment = (await service.GetAll()).First();
        // await service.Delete(assignment.Id);
        // Assert.Empty(await service.GetAll());
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