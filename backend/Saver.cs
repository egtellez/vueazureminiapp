[FunctionName("Saver")]
public static async Task<IActionResult> Run(
    [HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = null)]
    HttpRequest req, ILogger log)
{
    string customerAsString = await new StreamReader(req.Body).ReadToEndAsync();	
	QueueOperator.InsertMessageToQueue("CustomerQueue", customerAsString)

    return customerAsString != null
        ? (ActionResult) new OkObjectResult($"Customer was saved successfully")
        : new BadRequestObjectResult("Customer needs to have a value");
}