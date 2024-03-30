<h3>04 - In Memory & Distributed Caching</h3>

<h4>Absolute Time:</h4>
<p>The clear lifespan of data in the cache is specified with Absolute Time. Once the specified lifespan expires, the cache is directly cleared.</p>

<h4>Sliding Time:</h4>
<p>Sliding Time indicates the retention of cached data in memory for a specified period. Access to the cache within the specified time period will extend the lifespan of the data. Otherwise, if there is no access within the specified timeframe, the cache will be cleared.</p>

<h4>Distributed Caching İşlem Sırası</h4>

<ul>
    <li>StackExchangeRedis kütüphanesi yüklenir.</li>
    <li>AddStackExchangeRedisCache servisi uygulama eklenir.</li>
    <li>IDistributedCache referansı inject edilir.</li>
    <li>SetString metodu ile metinsel, Set metodu ile de binary olarak veriler Redis server'a cachlenebilir. (GetString & Get)</li>
    <li>Remove metodu ile cachelenmiş veri silinebilir.</li>
</ul>


