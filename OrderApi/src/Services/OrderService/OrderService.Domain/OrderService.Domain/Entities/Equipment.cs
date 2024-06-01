using Ardalis.GuardClauses;
using OrderService.Domain.Extensions;

namespace OrderService.Domain.Entities;

public class Equipment : BaseEntity
{
    public string Name
    {
        get => _name;
        private set
        {
            Guard.Against.NullOrEmpty(value, nameof(value));
            _name = value;
        }
    }

    private string _name = string.Empty;

    public int Amount
    {
        get => _amount;
        private set
        {
            Guard.Against.LessByZero(value, nameof(value));
            _amount = value;
        }
    }

    private int _amount;

    public double Price
    {
        get => _price;
        private set
        {
            Guard.Against.LessByZero(value, nameof(value));
            _price = value;
        }
    }

    private double _price;

    public Equipment(Guid id, string name, int amount, double price) : base(id)
    {
        Name = name;
        Amount = amount;
        Price = price;
    }

    // ReSharper disable once UnusedMember.Local
    private Equipment(Guid id) : base(id)
    {
    }

    public void Update(string name, int amount, double price)
    {
        Name = name;
        Amount = amount;
        Price = price;
    }
}