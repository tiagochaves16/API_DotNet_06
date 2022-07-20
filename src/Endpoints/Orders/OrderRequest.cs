namespace WantApi.Endpoints.Orders;

public record OrderRequest(List<Guid> ProductIds, string DeliveryAddress);