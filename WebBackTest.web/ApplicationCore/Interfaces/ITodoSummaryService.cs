using System.Collections.Generic;
using WebBackTest.web.ApplicationCore.Entities;

namespace WebBackTest.web.ApplicationCore.Interfaces
{
    public interface ITodoSummaryService
    {
        int ToDoOngoing(IReadOnlyList<Todo> todos);
        int ToDoDone(IReadOnlyList<Todo> todos);
    }    
}