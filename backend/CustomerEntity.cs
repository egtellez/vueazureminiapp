using Microsoft.Azure.Cosmos.Table;

public class CustomerEntity : TableEntity
{
	public CustomerEntity()
	{
	}

	public CustomerEntity(string name)
	{
		PartitionKey = name;
	}

	public string Email { get; set; }

	public string PhoneNumber { get; set; }
	
	public string Address { get; set; }
	
	public int Age { get; set; }
}
