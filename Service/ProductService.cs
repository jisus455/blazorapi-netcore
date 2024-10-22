using BlazorApi.Models;
using BlazorApi.Repository;
using BlazorApi.Service.Handler;
using Newtonsoft.Json;

namespace BlazorApi.Service
{
    public class ProductService : IProductRepository
    {
        public async Task<List<Product>> GetProducts()
        {
            string query = $"SELECT * FROM product";
            string result = SQLiteHandler.GetJson(query, null);
            var products = JsonConvert.DeserializeObject<List<Product>>(result);
            return await Task.Run(() => products);
        }

        public async Task<bool> CreateProduct(CreateProduct product)
        {
            string query = $"INSERT INTO product VALUES(null, @name, @category, @price, @amount, @image)";
            var param = new { @name = product.Name, @category = product.Category, @price = product.Price, @amount = product.Amount, @image = product.Image };
            bool result = SQLiteHandler.Exec(query, param);
            return await Task.Run(() => result);
        }

        public async Task<bool> ModifyProduct(ModifyProduct product)
        {
            string query = $"UPDATE product SET name = @name, category = @category, price = @price, amount = @amount, image = @image WHERE id = @id";
            var param = new { @name = product.Name, @category = product.Category, @price = product.Price, @amount = product.Amount, @image = product.Image, @id = product.Id };
            bool result = SQLiteHandler.Exec(query, param);
            return await Task.Run(() => result);
        }

        public async Task<bool> DeleteProduct(int id)
        {
            string query = $"DELETE FROM product WHERE id = @id";
            var param = new { @id = id };
            bool result = SQLiteHandler.Exec(query, param);
            return await Task.Run(() => result);
        }


    }
}
