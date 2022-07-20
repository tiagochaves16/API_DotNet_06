using Flunt.Validations;
using IWantApp.Domain.Orders;

namespace WantApi.Domain.Products;

public class Product : Entity
{
    public string Name { get; private set; }
    public Guid CategoryId { get; private set; }
    public Category Category { get; private set; }
    public string Description { get; private set; }
    public bool HasStock { get; private set; }
    public bool Active { get; private set; } = true;
    public decimal Price { get; private set; }
    public ICollection<Order> Orders { get; internal set; }

    //public ICollection<Order> Orders { get; private set; }

    private Product() { }

    public Product(string name, Category category, string description, bool hasStock, decimal price, string createdBy)
    {
        Name = name;
        Category = category;
        Description = description;
        HasStock = hasStock;
        Price = price;

        CreateBy = createdBy;
        EditeBy = createdBy;
        CreateOn = DateTime.Now;
        EditeOn = DateTime.Now;

        Validate();
    }
    private void Validate()
    {
        var contract = new Contract<Product>()
            .IsNotNullOrEmpty(Name, "Name")
            .IsGreaterOrEqualsThan(Name, 3, "Name")
            .IsNotNull(Category, "Category", "Category not found")
            .IsNotNullOrEmpty(Description, "Description")
            .IsGreaterOrEqualsThan(Description, 3, "Description")
            .IsGreaterOrEqualsThan(Price, 1, "Price")
            .IsNotNullOrEmpty(CreateBy, "CreateBy")
            .IsNotNullOrEmpty(EditeBy, "EditeBy");
        AddNotifications(contract);
    }
}