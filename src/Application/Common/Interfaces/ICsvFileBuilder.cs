using Clean_Architecture.Application.TodoLists.Queries.ExportTodos;
using System.Collections.Generic;

namespace Clean_Architecture.Application.Common.Interfaces
{
    public interface ICsvFileBuilder
    {
        byte[] BuildTodoItemsFile(IEnumerable<TodoItemRecord> records);
    }
}
