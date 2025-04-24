using Moq;
using System.Collections.Generic;
using System.Threading.Tasks;
using TodoApp1.Core.Entities;
using TodoApp1.Application.Interfaces;
using TodoApp1.Application.Services;
using Xunit;

namespace TodoApp1.Tests
{
    public class TodoServiceTests
    {
        //Aina testing unit test
        [Fact]
        public async Task GetAllAsync_ReturnsAllTodos()
        {
            var mockRepo = new Mock<ITodoRepository1>();
            mockRepo.Setup(repo => repo.GetAllAsync())
                    .ReturnsAsync(new List<TodoItem1>
                    {
                        new TodoItem1 { Id = 1, Title = "Test 1" },
                        new TodoItem1 { Id = 2, Title = "Test 2" }
                    });

            var service = new TodoServices1(mockRepo.Object);

            var result = await service.GetAllAsync();

            Assert.NotNull(result);
            Assert.Equal(2, result.ToList().Count);
        }
    }
}
