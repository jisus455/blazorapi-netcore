using BlazorApi.Models;
using BlazorApi.Repository;
using BlazorApi.Service.Handler;
using Newtonsoft.Json;

namespace BlazorApi.Service
{
    public class ActivityService : IActivityRepository
    {
        public Task<Dashboard> GetDashboard()
        {
            Dashboard dashboard = new Dashboard();
            string query = $"SELECT COUNT(*) FROM activity";
            dashboard.TotalActivity = Int16.Parse(SQLiteHandler.GetScalar(query, null));

            query = $"SELECT COUNT(*) FROM activity WHERE operation = 'AGREGADO'";
            dashboard.TotalInsert = Int16.Parse(SQLiteHandler.GetScalar(query, null));

            query = $"SELECT COUNT(*) FROM activity WHERE operation = 'MODIFICADO'";
            dashboard.TotalUpdate = Int16.Parse(SQLiteHandler.GetScalar(query, null));

            query = $"SELECT COUNT(*) FROM activity WHERE operation = 'ELIMINADO'";
            dashboard.TotalDelete = Int16.Parse(SQLiteHandler.GetScalar(query, null));
            return Task.Run(() => dashboard);
        }

        public async Task<List<Activity>> GetActivities()
        {
            string query = $"SELECT * FROM activity";
            string result = SQLiteHandler.GetJson(query, null);
            var activities = JsonConvert.DeserializeObject<List<Activity>>(result);
            return await Task.Run(() => activities);
        }

        public async Task<bool> CreateActivity(CreateActivity activity)
        {
            string query = $"INSERT INTO activity VALUES(null, @name, @amount, @operation, DATETIME())";
            var param = new { @name = activity.Name, @amount = activity.Amount, @operation = activity.Operation };
            bool result = SQLiteHandler.Exec(query, param);
            return await Task.Run(() => result);
        }

    }
}
