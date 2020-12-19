public class QueueOperator
{
	//-------------------------------------------------
	// Insert a message into a queue
	//-------------------------------------------------
	public static string InsertMessageToQueue(string queueName, string message)
	{
		// Get the connection string from app settings
		string connectionString = ConfigurationManager.AppSettings["StorageConnectionString"];

		// Instantiate a QueueClient which will be used to create and manipulate the queue
		QueueClient queueClient = new QueueClient(connectionString, queueName);

		// Create the queue if it doesn't already exist
		queueClient.CreateIfNotExists();

		if (queueClient.Exists())
		{
			// Send a message to the queue
			queueClient.SendMessage(message);
		}

		return $"Inserted: {message}";
	}

	//-------------------------------------------------
	// Process and remove a message from the queue
	//-------------------------------------------------
	public static string DequeueMessage(string queueName)
	{
		// Get the connection string from app settings
		string connectionString = ConfigurationManager.AppSettings["StorageConnectionString"];

		// Instantiate a QueueClient which will be used to manipulate the queue
		QueueClient queueClient = new QueueClient(connectionString, queueName);

		if (queueClient.Exists())
		{
			// Get the next message
			QueueMessage[] retrievedMessage = queueClient.ReceiveMessages();

		
			// Delete the message
			queueClient.DeleteMessage(retrievedMessage[0].MessageId, retrievedMessage[0].PopReceipt);
			
			//return the retrieved message
			return retrievedMessage[0].MessageText;
		}
		
	}
}