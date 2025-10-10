using AutoMapper;
using practice.Dto;
using practice.Models;
using practice.Repositories;

namespace practice.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _repository;
        private readonly IMapper _mapper;

        public CustomerService(ICustomerRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<Customerdto>> GetAllAsync()
        {
            var customers = await _repository.GetAllAsync();
            return _mapper.Map<IEnumerable<Customerdto>>(customers);
        }

        public async Task<Customerdto?> GetByIdAsync(int id)
        {
            var customer = await _repository.GetByIdAsync(id);
            return customer == null ? null : _mapper.Map<Customerdto>(customer);
        }

        public async Task<Customerdto> AddAsync(Customerdto dto)
        {
            var customer = _mapper.Map<Customer>(dto);
            await _repository.AddAsync(customer);
            return _mapper.Map<Customerdto>(customer);
        }

        public async Task<Customerdto?> UpdateAsync(int id, Customerdto dto)
        {
            var existing = await _repository.GetByIdAsync(id);
            if (existing == null)
                return null;

            _mapper.Map(dto, existing);
            await _repository.UpdateAsync(existing);
            return _mapper.Map<Customerdto>(existing);
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
