using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Moq;
using TravelTracker.Api.Controllers;
using TravelTracker.Domain;
using TravelTracker.Infrastructure;

namespace TravelTracker.Api.Tests;

public class VisitsControllerTests
{
    private class TestAsyncEnumerator<T> : IAsyncEnumerator<T>
    {
        private readonly IEnumerator<T> _enumerator;

        public TestAsyncEnumerator(IEnumerator<T> enumerator)
        {
            _enumerator = enumerator;
        }
        
        public T Current => _enumerator.Current;

        public ValueTask<bool> MoveNextAsync()
        {
            return new ValueTask<bool>(_enumerator.MoveNext());
        }

        public ValueTask DisposeAsync()
        {
            _enumerator.Dispose();
            return new ValueTask();
        }
    }
    private static Mock<DbSet<T>> CreateMockDbSet<T>(IQueryable<T> data) where T : class
    {
        var mockSet = new Mock<DbSet<T>>();
        mockSet.As<IQueryable<T>>().Setup(m => m.Provider).Returns(data.Provider);
        mockSet.As<IQueryable<T>>().Setup(m => m.Expression).Returns(data.Expression);
        mockSet.As<IQueryable<T>>().Setup(m => m.ElementType).Returns(data.ElementType);
        mockSet.As<IQueryable<T>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());
        mockSet.As<IAsyncEnumerable<T>>()
            .Setup(m => m.GetAsyncEnumerator(It.IsAny<CancellationToken>()))
            .Returns(new TestAsyncEnumerator<T>(data.GetEnumerator()));
        
        return mockSet;
    }
    
    [Fact]
    public async Task GetVisits_ReturnsAllVisits()
    {
        var visits = new List<Visit>
        {
            new Visit { Id = 1, Country = "Test Country 1", City = "Test City 1", YearVisited = 2020 },
            new Visit { Id = 2, Country = "Test Country 2", City = "Test City 2", YearVisited = 2021 }
        }.AsQueryable();
        
        var mockDbSet = CreateMockDbSet(visits);
        
        var mockContext = new Mock<DataContext>(new DbContextOptions<DataContext>());
        mockContext.Setup(c => c.Visits).Returns(mockDbSet.Object);

        var controller = new VisitsController(mockContext.Object);
        
        var result = await controller.GetVisits();

        var actionResult = Assert.IsType<ActionResult<IEnumerable<Visit>>>(result);
        var okObjectResult = Assert.IsType<OkObjectResult>(actionResult.Result);
        var model = Assert.IsAssignableFrom<IEnumerable<Visit>>(okObjectResult.Value);
        Assert.Equal(2, model.Count());
    }
}
