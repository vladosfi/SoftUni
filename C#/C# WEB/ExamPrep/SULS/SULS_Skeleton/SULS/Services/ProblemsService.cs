using SULS.Models;
using SULS.ViewModels;
using System.Linq;

namespace SULS.Services
{
    public class ProblemsService : IProblemsService
    {
        private readonly ApplicationDbContext db;

        public ProblemsService(ApplicationDbContext db)
        {
            this.db = db;
        }

        public void CreateProblem(string name, int points)
        {
            var problem = new Problem
            {
                Name = name,
                Points = points,
            };

            this.db.Problems.Add(problem);
            this.db.SaveChanges();
        }

        public DetailsViewModel GetProblemDetails(string id)
        {
            return this.db.Problems
                .Where(x => x.Id == id)
                .Select(p => new DetailsViewModel
                {
                    Name = p.Name,
                    Problems = p.Submissions
                            .Where(s=>s.ProblemId == id)
                            .Select(x=> new SubmisionProblemDetailsViewModel
                            {
                                AchievedResult = x.AchievedResult,
                                CreatedOn = x.CreatedOn,
                                MaxPoints = p.Points,
                                SubmissionId = x.Id,
                                Username = x.User.Username
                            })
                            .ToList()
                })
                .FirstOrDefault();
        }
    }
}
