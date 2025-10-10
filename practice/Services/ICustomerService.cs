using practice.Dto;

namespace practice.Services
{
    public interface ICustomerService
    {
        Task<IEnumerable<Customerdto>> GetAllAsync();
        Task<Customerdto?> GetByIdAsync(int id);
        Task<Customerdto> AddAsync(Customerdto customerDto);
        Task<Customerdto?> UpdateAsync(int id, Customerdto customerDto);
        Task<bool> DeleteAsync(int id);
    }
}
