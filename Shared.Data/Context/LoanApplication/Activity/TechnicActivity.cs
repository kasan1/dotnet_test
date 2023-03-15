using System;

namespace Agro.Shared.Data.Context.LoanApplications.Activity
{
    public class TechnicActivity : BaseActivity
    {
        public string Fullname { get; set; }

        public DateTime DateIssue { get; set; }

        public int Count { get; set; }

        /// <summary>
        /// В исправном состоянии
        /// </summary>
        public int CountOfCorrect { get; set; }

        /// <summary>
        /// обременение
        /// </summary>
        public bool IsPledged { get; set; }

        /// <summary>
        /// Кому и за что заложено
        /// </summary>
        public string PledgeDescription { get; set; }
    }
}
