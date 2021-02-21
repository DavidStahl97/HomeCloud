﻿using HomeCloud.Maps.Application.Database.Collections;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace HomeCloud.Maps.Infrastructure.Database.Collection
{
    public abstract class CollectionBase<T> : ICollectionBase<T>
    {
        private const string _database = "homecloud-maps";
        private readonly MongoClient _client;

        public CollectionBase(MongoClient client)
        {
            _client = client;
        }

        public Task InsertAsync(T document)
        {
            return GetCollection().InsertOneAsync(document);                
        }

        public Task InsertManyAsync(IEnumerable<T> documents)
        {
            return GetCollection().InsertManyAsync(documents);
        }

        protected Task<T> FirstAsync(Expression<Func<T, bool>> expression)
        {
            return GetCollection().Find(expression).FirstAsync();
        }

        protected async Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> expression)
        {
            return await GetCollection().Find(expression).ToListAsync();
        }

        protected Task<long> CountAsync(Expression<Func<T, bool>> expression)
        {
            return GetCollection().CountDocumentsAsync(expression);
        }

        protected Task ReplaceOrInsert(Expression<Func<T, bool>> expression, T document)
        {
            return GetCollection().ReplaceOneAsync(expression, document, new ReplaceOptions
            {
                IsUpsert = true
            });
        }

        protected IMongoCollection<T> GetCollection()
            => _client.GetDatabase(_database).GetCollection<T>(typeof(T).Name);
    }
}
