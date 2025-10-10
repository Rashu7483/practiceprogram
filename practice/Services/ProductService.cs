using AutoMapper;
using practice.Dto;
using practice.Models;
using practice.Repositories;

namespace practice.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _repository;
        private readonly IMapper _mapper;

        public ProductService(IProductRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<Productdto>> GetAllAsync()
        {
            var products = await _repository.GetAllAsync();
            return _mapper.Map<IEnumerable<Productdto>>(products);
        }

        public async Task<Productdto?> GetByIdAsync(int id)
        {
            if (id <= 0)
                throw new ArgumentOutOfRangeException(nameof(id), "Id must be greater than zero.");

            var product = await _repository.GetByIdAsync(id);
            return product == null ? null : _mapper.Map<Productdto>(product);
        }

        public async Task<Productdto> AddAsync(Productdto dto)
        {
            var product = _mapper.Map<Product>(dto);// DTO → Entity //coverting productdto to entity because DB understands only entity product.
            await _repository.AddAsync(product);//You pass the Product entity to your repository, which adds it to the database using Entity Framework.
            return _mapper.Map<Productdto>(product); // Entity → DTO //After saving, you don’t want to return the full Product,So you map the saved Product back into a Productdto.
        }

        public async Task<Productdto?> UpdateAsync(int id, Productdto dto)
        {
            var existing = await _repository.GetByIdAsync(id);
            if (existing == null)
                return null;

            // Map updated values to the existing entity
            _mapper.Map(dto, existing); // DTO → Entity (updates existing)

            await _repository.UpdateAsync(existing);
            return _mapper.Map<Productdto>(existing); // Entity → DTO
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var existing = await _repository.GetByIdAsync(id);
            if (existing == null)
                return false;

            await _repository.DeleteAsync(id);
            return true;
        }
    }
}


//using practice.Models;
//using practice.Repositories;

//namespace practice.Services
//{
//    public class ProductService : IProductService
//    {
//        private readonly IProductRepository _repository;
//        public ProductService(IProductRepository repository)
//        {
//            _repository = repository;
//        }
//        public async Task<IEnumerable<Product>> GetAllAsync()=> await _repository.GetAllAsync();

//        public async Task<Product?> GetByIdAsync(int id)
//        {
//            if (id <= 0)
//                throw new ArgumentOutOfRangeException(nameof(id), "Id must be greater than zero.");

//            return await _repository.GetByIdAsync(id);
//        }
//        public async Task<Product> AddAsync(Product product)
//        {
//            await _repository.AddAsync(product);
//            return product;
//        }
//        public async Task<Product?> UpdateAsync(int id, Product product)
//        {
//            var existing = await _repository.GetByIdAsync(id);
//            if (existing == null)
//                return null;

//            // Update only the necessary fields
//            existing.Name = product.Name;
//            existing.Price = product.Price;

//            await _repository.UpdateAsync(existing);
//            return existing;
//        }

//        public async Task<bool> DeleteAsync(int id)
//        {
//            var existing = await _repository.GetByIdAsync(id);
//            if (existing == null)
//                return false;

//            await _repository.DeleteAsync(id);
//            return true;
//        }
//    }
//}
