using CrudToAlgo.Domain.Services;

namespace CrudToAlgo.Application.Services
{
    public class SubmissionService : ISubmissionService
    {

        public Task<int> CreateAndRunAsync(CreateSubmissionDto dto)
        {
            throw new NotImplementedException();
        }

        public Task<string> GetStatusAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
