using practice.Dto;

namespace practice.Services
{
    public interface IProductService
    {
        Task<IEnumerable<Productdto>> GetAllAsync();

        Task<Productdto?> GetByIdAsync(int id);

        Task<Productdto> AddAsync(Productdto productDto);

        Task<Productdto?> UpdateAsync(int id, Productdto productDto);

        Task<bool> DeleteAsync(int id);
    }
}


//using practice.Models;

//namespace practice.Services
//{
//    public interface IProductService
//    {
//        public Task<IEnumerable<Product>> GetAllAsync();

//        public Task<Product> GetByIdAsync(int id);

//        public Task<Product> AddAsync(Product product);
//        public Task<Product?> UpdateAsync(int id, Product product);

//        public Task<bool> DeleteAsync(int id);

//    }
//}
