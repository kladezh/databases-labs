using System;
using System.Collections.Generic;
using System.Reflection;
using Dapper;
using DatabasesApp.Application.Interfaces;

namespace DatabasesApp.Data
{
    public class DbRepository<T> : IDbRepository<T>
    {
        private readonly IDbConnectionManager _manager;
        private readonly IDictionary<string, string> _queries;

        public DbRepository(IDbConnectionManager manager, IDictionary<string, string> queries)
        {
            _manager = manager;
            _queries = queries;
        }

        public IEnumerable<T> GetAll()
        {
            using var conn = _manager.GetConnection();

            return conn.Query<T>(
                _queries[MethodBase.GetCurrentMethod()!.Name]);
        }

        public T GetById(int id)
        {
            if (id <= 0) throw new ArgumentOutOfRangeException("parameter id must be > 0");

            using var conn = _manager.GetConnection();

            return conn.QueryFirst<T>(
                _queries[MethodBase.GetCurrentMethod()!.Name], new { id });
        }

        public void Add(T entity)
        {
            throw new NotImplementedException();
        }

        public void Update(T entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
