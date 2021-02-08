using Clean_Architecture.Domain.Common;
using System.Threading.Tasks;

namespace Clean_Architecture.Application.Common.Interfaces
{
    public interface IDomainEventService
    {
        Task Publish(DomainEvent domainEvent);
    }
}
