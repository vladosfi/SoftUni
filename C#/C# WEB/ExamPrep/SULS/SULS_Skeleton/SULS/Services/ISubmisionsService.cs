using SULS.Models;

namespace SULS.Services
{
    public interface ISubmisionsService
    {
        Problem GetProblem(string id);

        void CreateSubmision(string problemId, string code, string userId);

        void DeleteSubmision(string id);
    }
}
