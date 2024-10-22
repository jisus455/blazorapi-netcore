namespace BlazorApi.Models
{
    public class ModifyProduct
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Category { get; set; }
        public int? Price { get; set; }
        public int? Amount { get; set; }
        public string? Image { get; set; }
    }
}
