using Domain.SeedWork;

namespace Domain.Aggregates;

public class Role : Entity
{
    public string Name { get; private set; }
    public Role(Guid id, string name)
    {
        Id = id;
        Name = name;
    }
}