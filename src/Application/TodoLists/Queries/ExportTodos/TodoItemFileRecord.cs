using Clean_Architecture.Application.Common.Mappings;
using Clean_Architecture.Domain.Entities;

namespace Clean_Architecture.Application.TodoLists.Queries.ExportTodos
{
    public class TodoItemRecord : IMapFrom<TodoItem>
    {
        public string Title { get; set; }

        public bool Done { get; set; }
    }
}
