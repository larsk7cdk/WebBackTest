using System.Collections.Generic;
using System.Linq;
using WebBackTest.web.ApplicationCore.Entities;
using WebBackTest.web.ApplicationCore.Interfaces;

namespace WebBackTest.web.ApplicationCore.Services
{
    public class TodoSummaryService : ITodoSummaryService
    {
        public int ToDoOngoing(IReadOnlyList<Todo> todos) => todos.Count(x => !x.IsDone);

        public int ToDoDone(IReadOnlyList<Todo> todos) => todos.Count(x => x.IsDone);
    }
}
