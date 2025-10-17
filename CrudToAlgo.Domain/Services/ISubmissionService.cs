
namespace CrudToAlgo.Domain.Services
{
    public interface ISubmissionService
    {
        Task<int> CreateAndRunAsync(CreateSubmissionDto dto);
        Task<string> GetStatusAsync(int id);
    }
}