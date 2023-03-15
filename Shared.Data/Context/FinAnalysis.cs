using Agro.Shared.Data.Context.Dictionary;
using Agro.Shared.Data.Entities.Base;
using Microsoft.EntityFrameworkCore.Query.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using static Agro.Shared.Data.Context.PolicyRules;

namespace Agro.Shared.Data.Context
{
    /// <summary>
    /// Результаты финанализа
    /// </summary>
    public class FinAnalysis : BaseEntity
    {

        /// <summary>
        /// Заявление
        /// </summary>
        public Guid LoanApplicationId { get; set; }
        [ForeignKey(nameof(LoanApplicationId))]
        public LoanApplication LoanApplication { get; set; }

        #region Common requirements/Соответствие общим требованиям

        /// <summary>
        /// PKB: Лжепредпринимательская деятельность
        /// </summary>
        public RejectStatuses FalseBusiness { get; set; } = RejectStatuses.ServiceUnavailable;

        /// <summary>
        /// PKB: Списки несостоятельных должников/Список банкротов
        /// </summary>
        public RejectStatuses Bankrupt { get; set; } = RejectStatuses.ServiceUnavailable;

        /// <summary>
        /// PKB: Розыск Комитетом государственных доходов Министерства Финансов РК
        /// </summary>
        public RejectStatuses WantedIncome { get; set; } = RejectStatuses.ServiceUnavailable;

        /// <summary>
        /// Список налогоплательщиков, признанных бездействующими
        /// </summary>
        public RejectStatuses Inactive { get; set; } = RejectStatuses.ServiceUnavailable;

        /// <summary>
        /// Список налогоплательщиков, признанных банкротами
        /// </summary>
        public RejectStatuses TaxesBankrupt { get; set; } = RejectStatuses.ServiceUnavailable;

        /// <summary>
        /// Сведения об отсутствии (наличии) задолженности, учет по которым ведется в органах государственных доходов
        /// </summary>
        public RejectStatuses TaxArrear { get; set; } = RejectStatuses.ServiceUnavailable;

        /// <summary>
        /// PKB: Связь с финансированием терроризма
        /// </summary>
        public RejectStatuses TerrorList { get; set; } = RejectStatuses.ServiceUnavailable;

        /// <summary>
        /// PKB: Розыск алиментщиков Комитетом по правовой статистике и специальным учетам ГП РК
        /// </summary>
        public RejectStatuses Aliment { get; set; } = RejectStatuses.ServiceUnavailable;

        /// <summary>
        /// Сведения о лицах, привлеченные к уголовной отвественности за совершение уголовных правонарушений против половой неприкосновенности несовершеннолетних
        /// </summary>
        public RejectStatuses Pedophily { get; set; } = RejectStatuses.ServiceUnavailable;

        /// <summary>
        /// PKB: Розыск преступников, должников, без вести пропавших лиц Комитетом по правовой статистике и специальным учетам ГП РК
        /// </summary>
        public RejectStatuses LostPeople { get; set; } = RejectStatuses.ServiceUnavailable;

        #endregion

        /// <summary>
        /// Аффилирован или нет
        /// </summary>
        public RejectStatuses Affiliation { get; set; } = RejectStatuses.ServiceUnavailable;
                
        public bool IsAffiliated { get; set; }

        /// <summary>
        /// Особые отношения
        /// </summary>
        public bool HasSpecialRelations { get; set; }

        /// <summary>
        /// Общий статус
        /// </summary>
        public RejectStatuses Status { get; set; }

        /// <summary>
        /// Получатель АСП
        /// </summary>
        public bool? IsASA { get; set; }

        /// <summary>
        /// Многодетная семья
        /// </summary>
        public bool? IsManyChildren { get; set; }


        #region

        /// <summary>
        /// Кредитный обязательства за 12 месяцев
        /// </summary>
        public double AnnualPay { get; set; }

        /// <summary>
        /// Проходи ли по кредитным обязательствам
        /// </summary>
        public bool AnnualPaySuccess { get; set; } = true;

        /// <summary>
        /// Отсутствие текущий просрочки
        /// </summary>
        public bool ExistenceOfAmountDPD { get; set; }

        /// <summary>
        /// количество дней просрочки по текущим кредитам
        /// </summary>
        public double SumOverdueAmount { get; set; }

        /// <summary>
        /// отсутствие просрочек за последние 2 года
        /// </summary>
        public bool ExistDPDPastInToYears { get; set; }

        /// <summary>
        /// количество дней просрочек за последние 2 года
        /// </summary>
        public double  CountDPDPastInToYears { get; set; }
        ///// <summary>
        ///// Отсутствие критичных просрочек
        ///// </summary>
        //public bool CriticalDelays { get; set; }

        ///// <summary>
        ///// Отсутствие мероприятий по взысканию задолженности
        ///// </summary>
        //public bool DebtCollection { get; set; }

        ///// <summary>
        ///// Отсутствие списаний задолженностей
        ///// </summary>
        //public bool WrittenOffDebts { get; set; }

        /// <summary>
        /// Если негативный кредитный отчет из ГКБ
        /// </summary>
        public RejectStatuses GKBReuslt { get; set; }

        /// <summary>
        /// GKB: Кредитный отчет
        /// </summary>
        public Guid? CreditReportId { get; set; }


        #endregion

        public ICollection<FinAnalysisIncome> FinAnalysisIncomes { get; set; }
        public ICollection<FinAnalysisLoanPayment> FinAnalysisLoanPayments { get; set; }
    }
}
