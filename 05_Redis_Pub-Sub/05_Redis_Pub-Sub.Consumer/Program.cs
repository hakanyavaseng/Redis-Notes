using StackExchange.Redis;

ConnectionMultiplexer connection = await ConnectionMultiplexer.ConnectAsync("localhost:1903"); // Also, options parameter can be passed
ISubscriber sub = connection.GetSubscriber();

await sub.SubscribeAsync("myChannel", (channel, message) =>
{
    Console.WriteLine($"Channel: {channel}, Value: {message}");
});

Console.Read();