using Dapper;
using Microsoft.Data.SqlClient;
using WantApi.Endpoints.Categories;

namespace WantApi.Infra;

public class QueryAllUsersWithClaimName
{
    private readonly IConfiguration configuration;
    public QueryAllUsersWithClaimName(IConfiguration configuration)
    {
        this.configuration = configuration;
    }

    public async Task<IEnumerable<EmployeeResponse>> Execute(int page, int rows)
    {
        var db = new SqlConnection(configuration["ConnectionString:WantDb"]);
        var query = @"
            select Email, ClaimValue as Name
            from AspNetUsers u INNER
            join AspNetUserClaims c
            on u.Id = c.UserId and ClaimType = 'Name'
            order by name
            OFFSET (@page -1 ) * @rows ROWS FETCH NEXT @rows ROWS ONLY";

        return await db.QueryAsync<EmployeeResponse>(
            query,

            new { page, rows }
            );
    }

}
