<h3>04 - In Memory & Distributed Caching</h3>

<h4>Absolute Time:</h4>
<p>The clear lifespan of data in the cache is specified with Absolute Time. Once the specified lifespan expires, the cache is directly cleared.</p>

<h4>Sliding Time:</h4>
<p>Sliding Time indicates the retention of cached data in memory for a specified period. Access to the cache within the specified time period will extend the lifespan of the data. Otherwise, if there is no access within the specified timeframe, the cache will be cleared.</p>

<h4>Order of Operations in Distributed Caching</h4>

<ul>
    <li>The StackExchangeRedis library is loaded.</li>
    <li>The AddStackExchangeRedisCache service is added to the application.</li>
    <li>The IDistributedCache reference is injected.</li>
    <li>Data can be cached to the Redis server either textually with the SetString method or binary with the Set method. (GetString & Get)</li>
    <li>Cached data can be removed using the Remove method.</li>
</ul>

<hr>

<h3>05 - Redis Pub/Sub - MessageBroker </h3>

<p>Although Redis is primarily used in caching processes, it also functions as a message broker capable of performing pub/sub operations.</p>
<p>To achieve pub/sub operations in Redis, there are several methods:</p>

<ul>
    <li>Redis CLI</li>
    <li>Redis API</li>
    <li>Redis Insight</li>
</ul>

<h4>Redis CLI</h4>

<ul>
    <li>Open the Redis CLI in your terminal by typing `redis-cli`.</li>
    <li>To subscribe to a channel, use the `subscribe` command followed by the channel name. For example: `subscribe myChannel`.</li>
    <li>In another Redis CLI instance, you can publish a message to the channel using the `publish` command followed by the channel name and the message. For example: `publish myChannel "Hello, World!"`.</li>
    <li>The first Redis CLI instance will receive the message published to the channel.</li>
</ul>

<img src="https://github.com/hakanyavaseng/Redis-Notes/blob/main/Screenshots/Redis_CLI.png?raw=true"/>

<h4>Redis Insight</h4>

<img src="https://github.com/hakanyavaseng/Redis-Notes/blob/main/Screenshots/Redis_Insight_Pub-Sub.png?raw=true"/>

<h4>Redis API</h4>

<ul>
    <li>Get StackExchange.Redis from NuGet.</li>
    <li>Create a `ConnectionMultiplexer` instance.</li>
    <li>Subscribe to a channel with `GetSubscriber().Subscribe()`.</li>
    <li>Send messages with `GetSubscriber().Publish()`.</li>
    <li>Handle incoming messages in your callback function.</li>
</ul>

<h4>Redis Pattern-Matching Subscription with .NET</h4>

<ul>
    <li>Install the StackExchange.Redis NuGet package to your .NET project.</li>
    <li>Create a `ConnectionMultiplexer` instance to connect to your Redis server.</li>
    <li>Get a subscriber from the `ConnectionMultiplexer` instance using the `GetSubscriber()` method.</li>
    <li>Subscribe to a pattern using the `Subscribe` method on the subscriber, passing in the pattern and a callback function. The pattern can include wildcard characters like `*`.</li>
    <li>In the callback function, handle incoming messages that match the pattern. The function will be called whenever a message is published on a channel that matches the pattern.</li>
    <li>To publish messages, use the `Publish` method on the subscriber, passing in the channel and the message.</li>
</ul>

<hr>

<h3>06 - Redis Replication</h3>

<p>In Redis operations, ensuring the security of data on the server and keeping a copy may be necessary. Redis Replication behavior establishes a resilient infrastructure against situations like data loss.</p>

<p>In the Replication behavior, the server to be modeled/replicated is called the "master." The server(s) receiving the replication are called "slaves."</p>

<p>Slaves are read-only servers, so data can be read only, but not be written directly.</p>

<h4>Setting up Redis Master-Slave with Docker</h4>

<ol>
    <li>Create master: docker run -p 1453:6379 --name redis-master -d redis</li> 
    <li>Create slave: docker run -p 1453:6379 --name redis-slave -d redis</li>
    <li>Get redis-master's IP: docker inspect -f "{{.NetworkSettings.IpAddress }}" redis-master</li>
    <li>Execute command in redis-slave: docker exec -it redis-slave redis-cli slaveof [IP OF MASTER] 6379 (Default port is given)</li>  
    <li>To get the replication information of a server => info replication (can be written inside server cli) </li>
</ol>






