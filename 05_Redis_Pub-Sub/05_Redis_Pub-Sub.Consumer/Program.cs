using StackExchange.Redis;

ConnectionMultiplexer connection = await ConnectionMultiplexer.ConnectAsync("localhost:1903"); // Also, options parameter can be passed
ISubscriber sub = connection.GetSubscriber();

// If we use myChannel.* as channel name, we can subscribe to all channels that start with myChannel
await sub.SubscribeAsync("myChannel.*", (channel, message) => 
{
    Console.WriteLine($"Channel: {channel}, Value: {message}");
});

Console.Read();