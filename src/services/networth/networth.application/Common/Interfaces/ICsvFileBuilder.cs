using System.Collections.Generic;
using NetworthApplication.TodoLists.Queries.ExportTodos;

namespace NetworthApplication.Common.Interfaces
{
    public interface ICsvFileBuilder
    {
        byte[] BuildTodoItemsFile(IEnumerable<TodoItemRecord> records);
    }
}
