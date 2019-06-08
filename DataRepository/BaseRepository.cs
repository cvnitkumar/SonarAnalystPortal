using Dapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataRepository
{
    public class BaseRepository<T>
    {
        protected string Connection { get; set; }

        public BaseRepository()
        {
            Connection = ConfigurationManager.ConnectionStrings["AnalystWorkBench"].ConnectionString;            
        }

        public IList<T> GetList(string commandText, object param = null, CommandType commandType = CommandType.Text )
        {
            using (var sqlConnection = new SqlConnection(Connection))
            {
                return sqlConnection.Query<T>(commandText, param, commandType: commandType).ToList<T>();
            }
        }

        public T Get(string commandText, object param, CommandType commandType = CommandType.Text)
        {
            using (var sqlConnection = new SqlConnection(Connection))
            {
                return sqlConnection.QuerySingleOrDefault<T>(commandText, param, commandType: commandType);
            }
        }

        public int Insert(T entity, string commandText, CommandType commandType = CommandType.Text)
        {
            using (var sqlConnection = new SqlConnection(Connection))
            {
                return sqlConnection.Execute(commandText, entity, commandType: commandType);
            }
        }

        public int Update(T entity, string commandText, CommandType commandType = CommandType.Text)
        {
            using (var sqlConnection = new SqlConnection(Connection))
            {
                return sqlConnection.Execute(commandText, entity, commandType: commandType);
            }
        }

        public int Delete(string commandText, object param, CommandType commandType = CommandType.Text)
        {
            using (var sqlConnection = new SqlConnection(Connection))
            {
                return sqlConnection.Execute(commandText, param, commandType: commandType);
            }
        }

    }
}
