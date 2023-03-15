using System;
using System.Collections.Generic;
using System.Text;
using static Agro.Shared.Data.Context.PolicyRules;

namespace Agro.Okaps.Logic.Models
{
    public class FinAnalysCliOutDto
    {
        /// <summary>
        /// Соответствие общим треболваниям
        /// </summary>
        public RejectStatuses Status { get; set; }
        public string StatusTitle { get 
            {
                return getStatus(Status);
            } 
        }

        /// <summary>
        /// Отсутствие текущий просрочки
        /// </summary>
        public RejectStatuses CreditHistory { get; set; }
        public string CreditHistoryTitle
        {
            get
            {
                return getStatus(CreditHistory);
            }
        }

        public List<string> RejectDetails { get; set; }

        public string CreditHistoryDetail { get; set; }

        public string  FinalErrorMessage { get; set; }

        private string getStatus(RejectStatuses status)
        {
            switch (status)
            {
                case RejectStatuses.ServiceUnavailable:
                    return "Сервис не доступен";
                case RejectStatuses.Correct:
                    return "Положительно";
                case RejectStatuses.Critical:
                    return "Критично";
                case RejectStatuses.Minor:
                    return "Устраняемо";
            }
            return "";
        }
    }
}

