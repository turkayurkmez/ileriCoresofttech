using Microsoft.Extensions.Caching.Memory;

namespace BookStore.API.Controllers
{
    public class PostEvictionCallbackHandler
    {
        private object onEviction;

        public PostEvictionCallbackHandler(object onEviction)
        {
            this.onEviction = onEviction;
        }

        public void PostEvictionCallback(string key, object value, EvictionReason reason, object state)
        {
            Console.WriteLine($"{key}, cache'den çıkarıldı {reason}");
        }

    }
}