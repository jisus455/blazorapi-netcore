namespace BlazorApi.Models
{
    public class Activity
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Amount { get; set; }
        public string? Operation { get; set; }
        public DateTime Timedate { get; set; }
    }
}
