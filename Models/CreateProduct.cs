namespace BlazorApi.Models
{
    public class CreateProduct
    {
        public string? Name { get; set; }
        public string? Category { get; set; }
        public int? Price { get; set; }
        public int? Amount { get; set; }
        public string? Image { get; set; }
    }
}
