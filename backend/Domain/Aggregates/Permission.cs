using Domain.SeedWork;

namespace Domain.Aggregates;

public class Permission : Entity
{
    public string Name { get; private set; }
    public Permission(Guid id, string name)
    {
        Id = id;
        Name = name;
    }
}