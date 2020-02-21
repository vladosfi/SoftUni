using SULS.ViewModels;
using System.Collections.Generic;

namespace SULS.Services
{
    public interface IHomeService
    {
        IEnumerable<ProblemsModel> GetAllProblems();
    }
}
