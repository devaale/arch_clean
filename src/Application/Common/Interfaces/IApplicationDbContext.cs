using Clean_Architecture.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace Clean_Architecture.Application.Common.Interfaces
{
    public interface IApplicationDbContext
    {
        DbSet<TodoList> TodoLists { get; set; }
        DbSet<TodoItem> TodoItems { get; set; }
        DbSet<Plc> Plcs { get; set; }
        DbSet<PlcBlock> PlcBlocks { get; set; }
        DbSet<Record> Records { get; set; }
        DbSet<Event> Events { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
