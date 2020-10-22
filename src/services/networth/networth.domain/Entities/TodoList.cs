using System.Collections.Generic;
using NetworthDomain.Common;

namespace NetworthDomain.Entities
{
    public class TodoList : AuditableEntity
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Color { get; set; }

        public IList<TodoItem> Items { get; private set; } = new List<TodoItem>();
    }
}
