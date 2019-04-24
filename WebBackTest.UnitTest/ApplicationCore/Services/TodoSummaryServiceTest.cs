using System;
using System.Collections.Generic;
using WebBackTest.web.ApplicationCore.Entities;
using WebBackTest.web.ApplicationCore.Services;
using Xunit;

namespace WebBackTest.UnitTest.ApplicationCore.Services
{
    public class TodoSummaryServiceTest
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
        public void TodoSummaryService_ToDoOngoing_Schould_ReturnNoOfToDoOngoing()
        {
            // Arrange 
            var sut = new TodoSummaryService();
            const int expected = 4;

            // Act
            var actual = sut.ToDoOngoing(_toDoTestDouble);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TodoSummaryService_ToDoDone_Schould_ReturnNoOfToDoDone()
        {
            // Arrange 
            var sut = new TodoSummaryService();
            const int expected = 2;

            // Act
            var actual = sut.ToDoDone(_toDoTestDouble);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}