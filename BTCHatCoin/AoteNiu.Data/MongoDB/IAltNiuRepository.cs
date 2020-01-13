using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AoteNiu.Data
{
    //
    // 摘要:
    //     Generic Entity interface.
    //
    // 类型参数:
    //   TKey:
    //     The type used for the entity's Id.
    public interface IEntity<TKey>
    {
        //
        // 摘要:
        //     Gets or sets the Id of the Entity.
        [BsonId]
        TKey Id { get; set; }
    }

    public interface IAltNiuRepository<T> where T : IEntity<string>
    {
        IMongoCollection<T> Collection();

        T Add(T t);
        void Add(IEnumerable<T> tlist);

        Task AddAsync(T t);
        Task AddAsync(IEnumerable<T> t);

        long Update(T t);
        long Update(FilterDefinition<T> filter, UpdateDefinition<T> update, UpdateOptions options = null);
        void Update(IEnumerable<T> tlist);

        Task<long> UpdateAsync(T t);
        Task<long> UpdateAsync(FilterDefinition<T> filter, UpdateDefinition<T> update, UpdateOptions options = null);
        Task UpdateAsync(IEnumerable<T> tlist);

        long Delete(FilterDefinition<T> filter);
        long Delete(Expression<Func<T, bool>> filter);
        long DeleteAll();

        Task<long> DeleteAsync(Expression<Func<T, bool>> filter);
        Task<long> DeleteAsync(FilterDefinition<T> filter);
        Task<long> DeleteAllAsync();

        T GetById(string Id);
        Task<T> GetByIdAsync(string Id);

        bool Exists(Expression<Func<T, bool>> filter);

        void FindAndModify(FilterDefinition<T> filter, UpdateDefinition<T> update, FindOneAndUpdateOptions<T> options = null);

        T FirstOrDefault(Expression<Func<T, bool>> filter);
        T FirstOrDefault(FilterDefinition<T> filter);

        Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> filter);
        Task<T> FirstOrDefaultAsync(FilterDefinition<T> filter);

        List<T> Find(FilterDefinition<T> filter, SortDefinition<T> sort = null, int? limit = null, int? skip = null);
        List<T> Find(Expression<Func<T, bool>> filter, SortDefinition<T> sort = null, int? limit = null, int? skip = null);

        Task<List<T>> FindAsync(string filter, FindOptions<T> options = null);
        Task<List<T>> FindAsync(FilterDefinition<T> filter, FindOptions<T> options = null);
        Task<List<T>> FindAsync(Expression<Func<T, bool>> filter, FindOptions<T> options = null);

        /// <summary>
        /// {x: 1}
        /// </summary>
        /// <param name="field"></param>
        /// <param name="filter"></param>
        /// <returns></returns>
        Task<List<object>> Distinct(string field, string filter);
        Task<List<object>> Distinct(string field, Expression<Func<T, bool>> filter);

        long Count(FilterDefinition<T> filter);
        long Count(Expression<Func<T, bool>> filter);
    }
}
