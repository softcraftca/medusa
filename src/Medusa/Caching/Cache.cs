using ServiceStack.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Softcraftng.Medusa.Caching
{
    public class Cache
    {
        private IRedisClient _redisClient;

        public Cache(IRedisClient redisClient)
        {
            _redisClient = redisClient;
        } 

        //IRedisClient redis = new RedisManagerPool("gru").GetClient();
        //TODO: include TTL

        public long CacheTypedWithId<T>(T cacheObject)
        {
            var redisClientTyped = _redisClient.As<T>();

            long id = redisClientTyped.GetNextSequence();
            PermeateIdValue(cacheObject, id);

            redisClientTyped.Store(cacheObject);
            return id;
        }

        private void PermeateIdValue<T>(T cacheObject, long id)
        {
            // if Id property exist
            if (typeof(T).GetProperty("Id") != null)
            {
                // set value
                var propertyInfo = cacheObject.GetType().GetProperty("Id");
                propertyInfo.SetValue(cacheObject, Convert.ChangeType(id, propertyInfo.PropertyType), null);
            }

        }

        public void CachString(string key, string value)
        {
            _redisClient.Set(key, value);
        }

        public T Get<T>(string key)
        {
            return _redisClient.Get<T>(key);
        }

        public void Remove(string key)
        {
            _redisClient.Remove(key);
        }

        public void RemoveById<T>(int id)
        {
            var redisClientTyped = _redisClient.As<T>();

            redisClientTyped.DeleteById(id);
        }

        public T GetRemove<T>(string key)
        {
            T result = Get<T>(key);
            Remove(key);

            return result;
        }

        public T GetTypedById<T>(int id)
        {
            var redisClientTyped = _redisClient.As<T>();

            T result = redisClientTyped.GetById(id);
            return result;
        }

        public IEnumerable<T> GetAllTyped<T>()
        {
            var redisClientTyped = _redisClient.As<T>();
            var list = redisClientTyped.GetAll().ToList();

            return list;
        }

    }
}
