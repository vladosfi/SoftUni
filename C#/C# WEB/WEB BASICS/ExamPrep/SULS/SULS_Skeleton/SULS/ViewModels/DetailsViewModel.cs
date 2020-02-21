using System;
using System.Collections.Generic;

namespace SULS.ViewModels
{
    public class DetailsViewModel
    {
        public string Name { get; set; }

        public IEnumerable<SubmisionProblemDetailsViewModel> Problems { get; set; }

    }

    public class SubmisionProblemDetailsViewModel
    {
        public string SubmissionId { get; set; }

        public string Username { get; set; }

        public int AchievedResult { get; set; }

        public DateTime CreatedOn { get; set; }

        public int MaxPoints { get; set; }
    }
}
