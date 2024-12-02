using API.Entities;

namespace API.Interfaces
{
    public interface IResidenceRepository
    {
        Task<IEnumerable<Residence?>> GetResidencesAsync();
        Task<Residence?> GetResidenceByNameAsync(string name);
        Task<Residence?> GetResidenceByIdAsync(string id);
    }
}