[FunctionName("Extractor")]
public static async Task<IActionResult> Run(
    [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = null)]
    HttpRequest req, ILogger log)
{
    
	string message = QueueOperator.DequeueMessage("CustomerQueue");
	CustomerEntity entity = await AzureTableStorageOperator.InsertOrMergeEntityAsync(message);

    return entity != null
        ? (ActionResult) new OkObjectResult($"Customer was saved successfully")
        : new BadRequestObjectResult("There was a problem while saving message: {message}. Recommend to re-enqueue");
}