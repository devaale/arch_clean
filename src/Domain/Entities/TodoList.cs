using Clean_Architecture.Domain.Common;
using Clean_Architecture.Domain.ValueObjects;
using System.Collections.Generic;

namespace Clean_Architecture.Domain.Entities
{
    public class TodoList : AuditableEntity
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public Colour Colour { get; set; } = Colour.White;

        public IList<TodoItem> Items { get; private set; } = new List<TodoItem>();
    }
}
