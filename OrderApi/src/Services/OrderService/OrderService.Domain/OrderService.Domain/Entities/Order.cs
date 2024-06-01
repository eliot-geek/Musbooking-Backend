using Ardalis.GuardClauses;
using OrderService.Domain.Exceptions;
using OrderService.Domain.Extensions;
using OrderService.Domain.Primitives;
using OrderService.Domain.ValueObjects;

namespace OrderService.Domain.Entities;

public class Order : BaseEntity
{
    public string Description
    {
        get => _description;
        private set
        {
            Guard.Against.NullOrEmpty(value, nameof(value));
            _description = value;
        }
    }

    private string _description = string.Empty;

    public CreatedDate CreatedDate { get; private set; } = null!;

    public DateTime? UpdatedAt
    {
        get => _updatedAt;
        private set
        {
            Guard.Against.Default(value, nameof(value));
            _updatedAt = value;
        }
    }

    private DateTime? _updatedAt;

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
    public IReadOnlyCollection<Equipment> Equipments => _equipments.AsReadOnly();
    private readonly List<Equipment> _equipments = null!;

    public Order(Guid id, string description, DateTime createdAt) : base(id)
    {
        Description = description;
        CreatedDate = new CreatedDate(createdAt);
        _equipments = new List<Equipment>();
    }

    // ReSharper disable once UnusedMember.Local
    private Order(Guid id) : base(id)
    {
    }

    public void Update(string description, DateTime updatedAt)
    {
        Description = description;
        UpdatedAt = updatedAt;
    }

    public void AddEquipment(Guid id, string name, int amount, double price)
    {
        var equipment = _equipments.FirstOrDefault(w => w.Id == id);
        if (equipment == null)
        {
            _equipments.Add(new Equipment(id, name, amount, price));
            Price = _equipments.Sum(c => c.Price);
        }
        else
        {
            equipment.Update(name, amount, price);
        }
    }

    public void DeleteEquipment(Guid id)
    {
        var equipment = _equipments.FirstOrDefault(w => w.Id == id);
        if (equipment != null)
        {
            _equipments.Remove(equipment);
        }
        else
        {
            throw new EntityNotFoundException(string.Format(ExceptionMessages.EquipmentNotFoundException, id));
        }
    }
}