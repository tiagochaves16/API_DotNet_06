using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using WantApi.Infra;
using WantApi.Infra.Data;

namespace WantApi.Endpoints.Products;

public class ProductSoldGet
{
    public static string Template => "/products/sold";
    public static string[] Methods => new string[] { HttpMethod.Get.ToString() };
    public static Delegate Handle => Action;

    [Authorize(Policy = "EmployeePolicy")]
    public static async Task<IResult> Action(QueryAllProductsSold query)
    {
        var result = await query.Execute();

        return Results.Ok(result);
    }
}

