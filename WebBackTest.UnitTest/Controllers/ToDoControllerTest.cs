﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Moq;
using WebBackTest.web.ApplicationCore.Entities;
using WebBackTest.web.Controllers;
using WebBackTest.web.Infrastructure.Data;
using WebBackTest.web.ViewModels.Todo;
using Xunit;

namespace WebBackTest.UnitTest.Controllers
{
    public class ToDoControllerTest
    {
        private readonly IReadOnlyList<Todo> _toDoTestDouble = new List<Todo>
        {
            new Todo {Id = 1, Name = "ToDo 1", Description = "ToDo 1 description", CreatedDateTime = new DateTime(), IsDone = false},
            new Todo {Id = 2, Name = "ToDo 2", Description = "ToDo 2 description", CreatedDateTime = new DateTime(), IsDone = false},
            new Todo {Id = 3, Name = "ToDo 3", Description = "ToDo 3 description", CreatedDateTime = new DateTime(), IsDone = false},
            new Todo {Id = 4, Name = "ToDo 4", Description = "ToDo 4 description", CreatedDateTime = new DateTime(), IsDone = true},
            new Todo {Id = 5, Name = "ToDo 5", Description = "ToDo 5 description", CreatedDateTime = new DateTime(), IsDone = false},
            new Todo {Id = 6, Name = "ToDo 6", Description = "ToDo 6 description", CreatedDateTime = new DateTime(), IsDone = true}
        };


        [Fact]
        public async Task TodoController_Index_ReturnsAViewResult_WithAListOfTodos()
        {
            // Arrange
            var mockRepo = new Mock<ITodoRepository>();
            mockRepo.Setup(repo => repo.GetAllAsync()).ReturnsAsync(_toDoTestDouble);
            var controller = new TodoController(mockRepo.Object);

            // Act
            var result = await controller.Index();

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<IEnumerable<TodoViewModel>>(viewResult.Model);
            Assert.Equal(6, model.Count());
        }
    }
}