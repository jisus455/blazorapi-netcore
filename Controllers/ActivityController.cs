using BlazorApi.Models;
using BlazorApi.Repository;
using Microsoft.AspNetCore.Mvc;

namespace BlazorApi.Controllers
{
    [Route("/api/activities")]
    [ApiController]
    public class ActivityController : ControllerBase
    {
        private readonly IActivityRepository activityRepository;

        public ActivityController(IActivityRepository activityRepository)
        {
            this.activityRepository = activityRepository;
        }

        [HttpGet("dashboard")]
        public async Task<IActionResult> GetDashboard()
        {
            return await Task.Run(() => Ok(activityRepository.GetDashboard().Result));
        }

        [HttpGet]
        public async Task<IActionResult> GetActivities()
        {
            return await Task.Run(() => Ok(activityRepository.GetActivities().Result));
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct(CreateActivity createActivity)
        {
            return await Task.Run(() => Ok(activityRepository.CreateActivity(createActivity).Result));
        }
    }
}
