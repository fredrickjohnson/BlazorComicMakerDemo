﻿using System;
using System.Collections.Generic;
using System.Text;
using ComicMaker.Common.Services.Interfaces;
using Microsoft.Azure.Cosmos.Table;

namespace ComicMaker.Common.Data
{
    public abstract class RepositoryBase
    {
        protected CloudTable Table;

        protected RepositoryBase(IConnectionString connectionString, string tableName)
        {
            var storageAccount = CloudStorageAccount.Parse(connectionString.Get());
            var tableClient = storageAccount.CreateCloudTableClient();
            Table = tableClient.GetTableReference(tableName);
        }
    }

    public abstract class RepositoryBase<T> : RepositoryBase where T : TableEntity, new()
    {
        public IEnumerable<T> GetAll()
        {
            var query = new TableQuery<T>();

            var entities = Table.ExecuteQuery(query);

            return entities;
        }

        public T GetById(string id, string partitionKey)
        {
            var operation = TableOperation.Retrieve<T>(id, partitionKey);
            var result = Table.Execute(operation);
            return result.Result as T;
        }

        public void Insert(T model)
        {
            Table.Execute(TableOperation.Insert(model));
        }

        public void Update(T model)
        {
            Table.Execute(TableOperation.Replace(model));
        }

        public void Delete(T model)
        {
            Table.Execute(TableOperation.Delete(model));
        }

        protected RepositoryBase(IConnectionString connectionString, string tableName) : base(connectionString, tableName)
        {
        }
    }
}