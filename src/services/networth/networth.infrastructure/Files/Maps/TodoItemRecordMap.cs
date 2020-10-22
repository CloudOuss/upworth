using System.Globalization;
using CsvHelper.Configuration;
using NetworthApplication.TodoLists.Queries.ExportTodos;

namespace NetworthInfrastructure.Files.Maps
{
    public class TodoItemRecordMap : ClassMap<TodoItemRecord>
    {
        public TodoItemRecordMap()
        {
            AutoMap(CultureInfo.InvariantCulture);
            Map(m => m.Done).ConvertUsing(c => c.Done ? "Yes" : "No");
        }
    }
}
