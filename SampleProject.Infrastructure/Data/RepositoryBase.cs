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
        protected string _connectionString;

        public RepositoryBase(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
            _tableName = typeof(T).Name;
        }

        public async Task<int> AddAsync(T entity)
        {
            var columns = GetColumns();
            var stringOfColumns = string.Join(", ", columns);
            var stringOfParameters = string.Join(", ", columns.Select(e => "@" + e));
            var query = $"insert into {_tableName} ({stringOfColumns}) values ({stringOfParameters})";
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                var result = await conn.ExecuteAsync(query, entity);
                return result;
            }
        }
        public async Task DeleteAsync(int id)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                await conn.ExecuteAsync($"DELETE FROM {_tableName} WHERE [Id] = @Id", new { Id = id });
            }
        }
        public async Task<IEnumerable<T>> GetAllAsync()
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                var data = await conn.QueryAsync<T>($"SELECT * FROM {_tableName}");
                return data;
            }
        }
        public async Task<T> GetByIdAsync(int id)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                var data = await conn.QueryAsync<T>($"SELECT * FROM {_tableName} WHERE Id = @Id", new { Id = id });
                return data.FirstOrDefault();
            }
            
        }
        public async Task UpdateAsync(T entity)
        {
            var columns = GetColumns();
            var stringOfColumns = string.Join(", ", columns.Select(e => $"{e} = @{e}"));
            var query = $"update {_tableName} set {stringOfColumns} where Id = @Id";

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                await conn.ExecuteAsync(query, entity);
            }
        }
        public async Task<IEnumerable<T>> Query(string where = null)
        {
            var query = $"select * from {_tableName} ";

            if (!string.IsNullOrWhiteSpace(where))
                query += where;

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                var data = await conn.QueryAsync<T>(query);
                return data;
            }
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