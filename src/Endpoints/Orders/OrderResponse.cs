namespace WantApi.Endpoints.Orders;

public record OrderResponse(Guid Id, string ClientEmail, IEnumerable<OrderProduct> Products, string DeliveryAdress);

public record OrderProduct(Guid Id, string Name);
