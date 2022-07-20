using Flunt.Validations;
using WantApi.Domain;
using WantApi.Domain.Products;

namespace IWantApp.Domain.Orders;


public class Order : Entity
{
    public string ClientId { get; private set; }
    public List<Product> Products { get; private set; }
    public decimal Total { get; private set; }
    public string DeliveryAddress { get; private set; }

    private Order() { }

    public Order(string clientId, string clientName, List<Product> products, string deliveryAddress)
    {
        ClientId = clientId;
        Products = products;
        DeliveryAddress = deliveryAddress;
        CreateBy = clientName;
        EditeBy = clientName;
        CreateOn = DateTime.UtcNow;
        EditeOn = DateTime.UtcNow;

        Total = 0;
        foreach (var item in Products)
        {
            Total += item.Price;
        }

        Validate();
    }

    private void Validate()
    {
        var contract = new Contract<Order>()
            .IsNotNull(ClientId, "Client")
            .IsTrue(Products != null && Products.Any(), "Products")
            .IsNotNullOrEmpty(DeliveryAddress, "DeliveryAddress");
        AddNotifications(contract);
    }
}

