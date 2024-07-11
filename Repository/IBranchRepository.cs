using MongoCrud.API.Models.Domain;
using MongoCrud.API.Models.DTO;

namespace MongoCrud.API.Repository
{
    public interface IBranchRepository
    {
        Task<Branch> CreateAsync(Branch branch);
        Task<Branch?> GetByBranchIdAsync(int branchId);
        Task<Branch?> GetByIdAsync(string  id);
        Task<List<Branch>> GetAllAsync();
        Task<Branch?> UpdateAsync(string id, UpdateBranchDto branchDto); 
    }
}
