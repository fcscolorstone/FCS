using log4net;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AoteNiu.Data
{
    public class DefaultMongoRepository<T>: IAltNiuRepository<T> where T : IEntity<string>
    {
        private readonly ILog _log;

        private readonly IMongoDatabase _db;
        protected IMongoCollection<T> _collection;

        public DefaultMongoRepository(IOptions<DBSettings> options, IMongoClient client)
        {
            this._log = LogManager.GetLogger(typeof(T));

            _db = client.GetDatabase(options.Value.Database);
            this._collection = _db.GetCollection<T>(typeof(T).Name);
        }

        public IMongoCollection<T> Collection()
        {
            return _collection; 
        }

        public T Add(T t)
        {
            // 插入后会自动写入ID，待验证
            _collection.InsertOne(t);

            if (string.IsNullOrWhiteSpace(t.Id))
            {
                _log.Error($"Find colletcion insert failed: {typeof(T)}...{t}");
                return default(T);  // null
            }

            return t;
        }
        public void Add(IEnumerable<T> tlist)
        {
            _collection.InsertMany(tlist);
        }

        public async Task AddAsync(T t)
        {
            await _collection.InsertOneAsync(t);
        }

        public async Task<T> AddAndReturnAsync(T t, Expression<Func<T, bool>> filter)
        {
            await _collection.InsertOneAsync(t);
            return t;
        }

        public async Task AddAsync(IEnumerable<T> tlist)
        {
            await _collection.InsertManyAsync(tlist);
        }

        public long Update(T t)
        {
            if (t.Id == null)
            {
                _collection.InsertOne(t);
                return 1;
            }

            var updateResult = _collection.ReplaceOne(filter: g => g.Id == t.Id, replacement: t);
            if (updateResult.IsAcknowledged && updateResult.ModifiedCount > 0)
            {
                return updateResult.ModifiedCount;
            }

            return 0;
        }

        public long Update(FilterDefinition<T> filter, UpdateDefinition<T> update, UpdateOptions options = null)
        {
            var x = _collection.UpdateOne(filter, update, options);
            if (x.IsAcknowledged)
            {
                return x.ModifiedCount;
            }

            return 0;
        }

        public void Update(IEnumerable<T> tlist)
        {
            for (int i = 0; i < tlist.Count(); i++)
            {
               Update(tlist.ElementAt(i));
            }
        }

        public async Task<long> UpdateAsync(T t)
        {
            var updateResult = await _collection.ReplaceOneAsync(filter: g => g.Id == t.Id, replacement: t);
            if (updateResult.IsAcknowledged && updateResult.ModifiedCount > 0)
            {
                return updateResult.ModifiedCount;
            }

            return 0;
        }

        public async Task<long> UpdateAsync(FilterDefinition<T> filter, UpdateDefinition<T> update, UpdateOptions options = null)
        {
            var x = await _collection.UpdateOneAsync(filter, update, options);
            if (x.IsAcknowledged)
            {
                return x.ModifiedCount;
            }

            return 0;
        }

        public async Task UpdateAsync(IEnumerable<T> tlist)
        {
            for (int i = 0; i < tlist.Count(); i++)
            {
               await  UpdateAsync(tlist.ElementAt(i));
            }
        }

        public long Delete(Expression<Func<T, bool>> filter)
        {
            var x = _collection.DeleteMany(filter);
            return x.IsAcknowledged ? x.DeletedCount : 0;
        }
        public long Delete(FilterDefinition<T> filter)
        {
            var x = _collection.DeleteMany(filter);
            return x.IsAcknowledged ? x.DeletedCount : 0;
        }
        public long DeleteAll()
        {
            var ret = _collection.DeleteMany(x => x.Id != null);
            return ret.DeletedCount;
        }

        public async Task<long> DeleteAsync(Expression<Func<T, bool>> filter)
        {
            var x = await _collection.DeleteManyAsync(filter);
            return x.IsAcknowledged ? x.DeletedCount : 0;
        }
        public async Task<long> DeleteAsync(FilterDefinition<T> filter)
        {
            var x = await _collection.DeleteManyAsync(filter);
            return x.IsAcknowledged ? x.DeletedCount : 0;
        }

        public async Task<long> DeleteAllAsync()
        {
            var x = await _collection.DeleteManyAsync(Builders<T>.Filter.Empty);
            return x.IsAcknowledged ? x.DeletedCount : 0;
        }

        /// <summary>
        /// 返回字段集合
        /// </summary>
        /// <param name="field"></param>
        /// <param name="filter"></param>
        /// <returns></returns>
        public async Task<List<object>> Distinct(string field, Expression<Func<T, bool>> filter)
        {
            var sets = new List<object>();

            using (IAsyncCursor<object> cursor = await _collection.DistinctAsync<object>(field, filter))
            {
                while (await cursor.MoveNextAsync())
                {
                    sets.AddRange(cursor.Current);
                }
            }

            return sets;
        }

        public async Task<List<object>> Distinct(string field, string filter)
        {
            var sets = new List<object>();

            using (IAsyncCursor<object> cursor = await _collection.DistinctAsync<object>(field, filter))
            {
                while (await cursor.MoveNextAsync())
                {
                    sets.AddRange(cursor.Current);
                }
            }

            return sets;
        }

        public long Count(FilterDefinition<T> filter)
        {
            return _collection.Count(filter);
        }

        public long Count(Expression<Func<T, bool>> filter)
        {
            return _collection.Count(filter);
        }

        public T GetById(string Id)
        {
            return Find(x => x.Id == Id).FirstOrDefault();
        }

        public async Task<T> GetByIdAsync(string Id)
        {
            return await FirstOrDefaultAsync(x => x.Id == Id);
        }

        public bool Exists(Expression<Func<T, bool>> filter)
        {
            return FirstOrDefault(filter) != null;
        }

        public void FindAndModify(FilterDefinition<T> filter, UpdateDefinition<T> update, FindOneAndUpdateOptions<T> options=null)
        {
            _collection.FindOneAndUpdate(filter, update, options);
        }

        public T FirstOrDefault(Expression<Func<T, bool>> filter)
        {
            return _collection.Find(filter).FirstOrDefault();
        }
        public T FirstOrDefault(FilterDefinition<T> filter)
        {
            return _collection.Find(filter).FirstOrDefault();
        }

        public async Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> filter)
        {
            var x = await _collection.FindAsync(filter);

            return await x.FirstOrDefaultAsync();
        }

        public async Task<T> FirstOrDefaultAsync(FilterDefinition<T> filter)
        {
            var x = await _collection.FindAsync(filter);

            return await x.FirstOrDefaultAsync();
        }

        public List<T> Find(FilterDefinition<T> filter, SortDefinition<T> sort = null, int? limit = null, int? skip=null)
        {
            return _collection.Find(filter).Sort(sort).Skip(skip).Limit(limit).ToList();
        }

        public List<T> Find(Expression<Func<T, bool>> filter, SortDefinition<T> sort = null, int? limit = null, int? skip = null)
        {
            return _collection.Find(filter).Sort(sort).Skip(skip).Limit(limit).ToList();
        }

        public async Task<List<T>> FindAsync(string filter, FindOptions<T> options = null)
        {
            var finds = new List<T>();

            using (IAsyncCursor<T> cursor = await _collection.FindAsync(filter, options))
            {
                while (await cursor.MoveNextAsync())
                {
                    finds.AddRange(cursor.Current);
                }
            }

            return finds;
        }

        public async Task<List<T>> FindAsync(FilterDefinition<T> filter, FindOptions<T> options = null)
        {
            var finds = new List<T>();

            using (IAsyncCursor<T> cursor = await _collection.FindAsync(filter, options))
            {
                while (await cursor.MoveNextAsync())
                {
                    finds.AddRange(cursor.Current);
                }
            }

            return finds;
        }

        public async Task<List<T>> FindAsync(Expression<Func<T, bool>> filter, FindOptions<T> options = null)
        {
            var finds = new List<T>();

            using (IAsyncCursor<T> cursor = await _collection.FindAsync(filter, options))
            {
                while (await cursor.MoveNextAsync())
                {
                    finds.AddRange(cursor.Current);
                }
            }

            return finds;
        }
    }
}
