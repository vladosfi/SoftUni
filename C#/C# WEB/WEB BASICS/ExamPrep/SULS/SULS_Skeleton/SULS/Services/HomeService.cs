using SULS.ViewModels;
using System.Collections.Generic;
using System.Linq;

namespace SULS.Services
{
    public class HomeService : IHomeService
    {
        private readonly ApplicationDbContext db;

        public HomeService(ApplicationDbContext db)
        {
            this.db = db;
        }

        public IEnumerable<ProblemsModel> GetAllProblems()
        {
            var problems = this.db.Problems
                .Select(x => new ProblemsModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    Count = x.Submissions.Count()
                })
                .ToList();

            return problems;
        }
    }
}
