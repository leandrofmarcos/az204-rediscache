using StackExchange.Redis;
using System.Threading.Tasks;

public class Program {
    static string CONNECTION_STRING = "REDIS_CONNECTION_STRING";

    static async Task Main(string[] args)
    {
        // The connection to the Azure Cache for Redis is managed by the ConnectionMultiplexer class.
        using (var cache = ConnectionMultiplexer.Connect(CONNECTION_STRING))
        {
            IDatabase db = cache.GetDatabase();

            var result = await db.ExecuteAsync("ping");
            Console.WriteLine($"PING = {result.Type} : {result}");

            bool setValue = await db.StringSetAsync("test:key", "100");
            Console.WriteLine($"SET: {setValue}");

            string getValue = await db.StringGetAsync("test:key");
            Console.WriteLine($"GET: {getValue}");

        }
    }

}