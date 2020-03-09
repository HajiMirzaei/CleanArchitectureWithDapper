using Dapper;
using Microsoft.Extensions.Configuration;
using SampleProject.Core.Contracts;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace SampleProject.Infrastructure.Data
{
    public abstract class RepositoryBase<T> : IAsyncGenericRepository<T> where T : EntityBase
    {
        private readonly string _tableName;
        protected IDbConnection _connection;

        public RepositoryBase(IConfiguration configuration)
        {
            _connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection"));
            _connection.Open();
            _tableName = typeof(T).Name;
        }

        public async Task<int> AddAsync(T entity)
        {
            var columns = GetColumns();
            var stringOfColumns = string.Join(", ", columns);
            var stringOfParameters = string.Join(", ", columns.Select(e => "@" + e));
            var query = $"insert into {_tableName} ({stringOfColumns}) values ({stringOfParameters})";

            var result = await _connection.ExecuteAsync(query, entity);
            return result;
        }
        public async Task DeleteAsync(int id)
        {
            await _connection.ExecuteAsync($"DELETE FROM {_tableName} WHERE [Id] = @Id", new { Id = id });
        }
        public async Task<IEnumerable<T>> GetAllAsync()
        {
            var data = await _connection.QueryAsync<T>($"SELECT * FROM {_tableName}");
            return data;
        }
        public async Task<T> GetByIdAsync(int id)
        {
            var data = await _connection.QueryAsync<T>($"SELECT * FROM {_tableName} WHERE Id = @Id", new { Id = id });
            return data.FirstOrDefault();
        }
        public async Task UpdateAsync(T entity)
        {
            var columns = GetColumns();
            var stringOfColumns = string.Join(", ", columns.Select(e => $"{e} = @{e}"));
            var query = $"update {_tableName} set {stringOfColumns} where Id = @Id";

            await _connection.ExecuteAsync(query, entity);
        }
        public async Task<IEnumerable<T>> Query(string where = null)
        {
            var query = $"select * from {_tableName} ";

            if (!string.IsNullOrWhiteSpace(where))
                query += where;

            var data = await _connection.QueryAsync<T>(query);
            return data;
        }
        private IEnumerable<string> GetColumns()
        {
            return typeof(T)
                    .GetProperties()
                    .Where(e => e.Name != "Id" && !e.PropertyType.GetTypeInfo().IsGenericType)
                    .Select(e => e.Name);
        }
    }
}