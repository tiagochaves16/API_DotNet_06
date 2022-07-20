using Flunt.Validations;

namespace WantApi.Domain.Products;

public class Category : Entity
{
    public string Name { get; private set; }
    public bool Active { get; private set; }

    public Category(string name, string createBy, string editeBy)
    {
        Name = name;
        Active = true;
        CreateBy = createBy;
        EditeBy = editeBy;
        CreateOn = DateTime.Now;
        EditeOn = DateTime.Now;

        Validate();
    }

    private void Validate()
    {
        var contract = new Contract<Category>()
            .IsNotNullOrEmpty(Name, "Name")
            .IsGreaterOrEqualsThan(Name, 3, "Name")
            .IsNotNullOrEmpty(CreateBy, "CreateBy")
            .IsNotNullOrEmpty(EditeBy, "EditeBy");
        AddNotifications(contract);
    }

    public void EditInfo(string name, bool active, string editeBy)
    {
        Active = active;
        Name = name;
        EditeBy = editeBy;
        EditeOn = DateTime.Now;

        Validate();
    }

}
