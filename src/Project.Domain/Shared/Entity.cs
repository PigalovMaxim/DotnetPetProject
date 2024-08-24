namespace Project.Domain.Shared;

public class Entity<T> where T : notnull
{
    public Entity() {}

    protected Entity(T id) => Id = id;

    public T Id { get; private set; }
}
