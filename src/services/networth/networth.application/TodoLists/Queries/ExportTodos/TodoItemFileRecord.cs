using NetworthApplication.Common.Mappings;
using NetworthDomain.Entities;

namespace NetworthApplication.TodoLists.Queries.ExportTodos
{
    public class TodoItemRecord : IMapFrom<TodoItem>
    {
        public string Title { get; set; }

        public bool Done { get; set; }
    }
}
