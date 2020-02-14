using SULS.Models;
using SULS.ViewModels;
using System;
using System.Linq;

namespace SULS.Services
{
    public class SubmisionsService : ISubmisionsService
    {
        private readonly ApplicationDbContext db;

        public SubmisionsService(ApplicationDbContext db)
        {
            this.db = db;
        }

        public void CreateSubmision(string problemId, string code, string userId)
        {
            var maxPointsForSubmision = this.db.Problems
                .Where(x => x.Id == problemId)
                .Select(x => x.Points)
                .FirstOrDefault();

            var achievedResult = new Random(0).Next(0, maxPointsForSubmision + 1);

            var submission = new Submission
            {
                Code = code,
                AchievedResult = achievedResult,
                CreatedOn = DateTime.UtcNow,
                ProblemId = problemId,
                UserId = userId
            };

            this.db.Submissions.Add(submission);
            this.db.SaveChanges();
        }

        public void DeleteSubmision(string id)
        {
            var submision = this.db.Submissions.Find(id);
            this.db.Submissions.Remove(submision);
            this.db.SaveChanges();
        }

        public Problem GetProblem(string id)
        {
            return this.db.Problems.Where(x => x.Id == id).FirstOrDefault();
        }


    }
}
