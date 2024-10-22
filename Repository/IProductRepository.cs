using BlazorApi.Models;

namespace BlazorApi.Repository
{
    public interface IProductRepository
    {
        public Task<List<Product>> GetProducts();
        public Task<bool> CreateProduct(CreateProduct createProduct);
        public Task<bool> ModifyProduct(ModifyProduct modifyProduct);
        public Task<bool> DeleteProduct(int id);

    }
}
