using SULS.ViewModels;

namespace SULS.Services
{
    public interface IProblemsService
    {
        void CreateProblem(string name, int points);

        DetailsViewModel GetProblemDetails(string id);
    }
}
