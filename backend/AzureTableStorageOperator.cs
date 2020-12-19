public class AzureTableStorageOperator
{
	public static async Task<CustomerEntity> InsertOrMergeEntityAsync(CloudTable table, CustomerEntity entity, ILogger logger)
	{
		if (entity == null)
		{
			throw new ArgumentNullException("customerEntity");
		}

		try
		{
			// Create the InsertOrReplace table operation
			TableOperation insertOrMergeOperation = TableOperation.InsertOrMerge(entity);

			// Execute the operation.
			TableResult result = await table.ExecuteAsync(insertOrMergeOperation);
			CustomerEntity insertedCustomer = result.Result as CustomerEntity;
			return insertedCustomer;
		}
		catch (StorageException e)
		{
			logger.Error(e.Message);
			throw;
		}
	}
}