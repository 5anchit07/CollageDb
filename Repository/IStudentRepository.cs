using MongoCrud.API.Models.Domain;
using MongoCrud.API.Models.DTO;
using MongoDB.Bson;

namespace MongoCrud.API.Repository
{
    public interface IStudentRepository
    {
        Task<Student> CreateAsync(Student student);
        Task<List<Student>> GetAllAsync();
        Task<IEnumerable<StudentWithBranchDto>> GetAllWithBranchAsync();
        Task<Student?> GetByIdAsync(string id);

        Task<Student?> UpdateAsync(string id, Student student);
        Task<Student?> DeleteAsync(string id);  
    }
}
