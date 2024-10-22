using BlazorApi.Models;

namespace BlazorApi.Repository
{
    public interface IActivityRepository
    {
        public Task<Dashboard> GetDashboard();
        public Task<List<Activity>> GetActivities();
        public Task<bool> CreateActivity(CreateActivity createActivity);
    }
}
