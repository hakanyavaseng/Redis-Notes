using StackExchange.Redis;

ConnectionMultiplexer connection = await ConnectionMultiplexer.ConnectAsync("localhost:1903"); // Also, options parameter can be passed
ISubscriber sub = connection.GetSubscriber();

while (true)
{
    Console.Write("Message: ");
    string message = Console.ReadLine();
    await sub.PublishAsync("myChannel", message); // Second parameter takes RedisValue but we can pass string because it has implicit operator overloading
}





