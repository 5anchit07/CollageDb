using MongoCrud.API.Models.Domain;
using MongoCrud.API.Models.DTO;
using MongoDB.Driver;
using TT.Mongo.Client;

namespace MongoCrud.API.Repository
{
    public class BranchRepository:IBranchRepository
    {
        private readonly IMongoDbClient<Branch> _client;
        public BranchRepository(IMongoDbClient<Branch> mongoClient) 
        {
            _client = mongoClient;
        }

        public async Task<Branch> CreateAsync(Branch branch)
        {
            await _client.CreateAsync(branch);
            return branch;

        }
        public async Task<Branch?> GetByBranchIdAsync(int branchId)
        {
            return await _client.GetAsync(x=> x.BranchId.Equals(branchId));
        }

        public async Task<Branch?> GetByIdAsync(string id)
        {
            return await _client.GetAsync(id);
        }

        public async Task<List<Branch>> GetAllAsync()
        {
            return await _client.GetManyAsync();
        }

        public async Task<Branch?> UpdateAsync(string id, UpdateBranchDto branchDto)
        {
            var existing = await _client.GetAsync(id);
            if (existing == null)
            {
                return null;
            }
            // update the data
           // existing.BranchId = branchDto.BranchId;
            existing.BranchName = branchDto.BranchName;
            existing.BranchFee = branchDto.BranchFee;

            await _client.UpdateAsync(id, existing);
            return existing;
        }

        
    }
}
