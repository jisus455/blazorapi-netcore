using Dapper;
using Newtonsoft.Json;
using System.Data;
using System.Data.SQLite;
using System.Transactions;
using Formatting = Newtonsoft.Json.Formatting;

namespace BlazorApi.Service.Handler
{
    public class SQLiteHandler
    {
        public static string ConnectionString = string.Empty;

        public static string GetJson(string query, object param)
        {
            SQLiteConnection cnn = new SQLiteConnection(ConnectionString);
            cnn.Open();
            var result = cnn.Query(query, param).ToList();
            var response = JsonConvert.SerializeObject(result, Formatting.Indented);
            cnn.Close();
            return response;
        }

        public static DataTable GetDt(string query, object param)
        {
            SQLiteConnection cnn = new SQLiteConnection(ConnectionString);
            cnn.Open();
            DataTable dataTable = new DataTable();
            var result = cnn.ExecuteReader(query, param);
            dataTable.Load(result);
            cnn.Close();
            return dataTable;
        }

        public static string GetScalar(string query, object param)
        {
            SQLiteConnection cnn = new SQLiteConnection(ConnectionString);
            cnn.Open();
            var scalarResult = cnn.ExecuteScalar(query, param).ToString();
            cnn.Close();
            return scalarResult;
        }

        public static bool Exec(string query, object param)
        {
            SQLiteConnection cnn = new SQLiteConnection(ConnectionString);
            int result;
            cnn.Open();
            using (var tran = new TransactionScope())
            {
                result = cnn.Execute(query, param);
                tran.Complete();
            }
            cnn.Close();
            return result > 0;
        }

    }
}

