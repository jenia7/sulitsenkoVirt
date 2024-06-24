using System.Text.Json.Serialization;

namespace Virtable.Core.SharedKernel;

public abstract class BaseEntity
{
    private readonly List<IDomainEvent> _domainEvents = [];
    public long Id { get; set; }

    public void RegisterDomainEvent(IDomainEvent domainEvent)
    {
        _domainEvents.Add(domainEvent);
    }

    [JsonIgnore]
    public IReadOnlyList<IDomainEvent> DomainEvents => _domainEvents.AsReadOnly();
    public void ClearDomainEvents()
    {
        _domainEvents.Clear();
    }
}
