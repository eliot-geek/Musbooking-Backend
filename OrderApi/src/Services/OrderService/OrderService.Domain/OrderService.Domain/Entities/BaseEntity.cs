using Ardalis.GuardClauses;
using OrderService.Domain.Extensions;

namespace OrderService.Domain.Entities;

public abstract class BaseEntity : IEquatable<BaseEntity>
{
    public Guid Id
    {
        get => _id;
        private init
        {
            Guard.Against.IsGuidEmpty(value, nameof(value));
            _id = value;
        }
    }

    private readonly Guid _id;

    protected BaseEntity(Guid id)
    {
        Id = id;
    }

    public bool Equals(BaseEntity? other)
    {
        return Id == other?.Id;
    }

    public override bool Equals(object? obj)
    {
        if (obj is not BaseEntity entity)
        {
            return false;
        }

        return Id == entity.Id;
    }

    public override int GetHashCode()
    {
        return Id.GetHashCode();
    }
}