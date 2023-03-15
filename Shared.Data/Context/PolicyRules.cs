using System;
using System.Collections.Generic;
using System.Text;

namespace Agro.Shared.Data.Context
{
    public class PolicyRules
    {
        public class PolicyResult
        {
            public bool isReject { get; set; }
            public string PolicyRejectReason { get; set; }
            public int ErrorCode { get; set; }
            public string ErrorMsg { get; set; }
            public RejectStatuses CheckStatus { get; set; }
            public PolicyVars vars { get; set; }

        }


        /// <summary>
        /// 0- сервис не доступен,  1- проверка пройдена, 3 - устраняемые 4 - не устраняемые 
        /// </summary>
        public enum RejectStatuses
        {
            ServiceUnavailable = 0,
            Correct = 1,
            Minor = 2,
            Critical = 3
        }

        public class PolicyVars
        {
            /// <summary>
            /// ГКБ: текущиt  обязательства из кредитного отчета
            /// </summary>
            public double AnnualPay { get; set; }

            /// <summary>
            /// ГКБ: наличие текущей просрочки по запросу ГКБ
            /// </summary>
            public bool ExistenceOfAmountDPD { get; set; }

            /// <summary>
            /// ГКБ:наличие текущей просрочки за последние 2 года
            /// </summary>
            public bool ExistenceDPDPastInToYears { get; set; }


            /// <summary>
            ////количество дней просрочки по текущим кредитам
            /// </summary>
            public double CountOverdueAmount { get; set; }

            /// <summary>
            /// количество дней просрочек за последние 2 года
            /// </summary>
            public double CountDPDPastInToYears { get; set; }

            /// <summary>
            /// признак аффилированности
            /// </summary>
            public RejectStatuses IsAffil { get; set; }
            /// <summary>
            /// PKB: Перечень налогоплательщиков, осуществивших лжепредпринимательскую деятельность. KGD02
            /// </summary>
            public RejectStatuses FalseBusi { get; set; }

            /// <summary>
            /// PKB: Списки несостоятельных должников/Список банкротов.  KGD03
            /// </summary>
            public RejectStatuses Bankruptcy { get; set; }

            /// <summary>
            /// PKB: Розыск Комитетом государственных доходов Министерства Финансов РК KGD05
            /// </summary>
            public RejectStatuses KgdWanted { get; set; }

            /// <summary>
            /// PKB: Список налогоплательщиков, признанных банкротами  KGD12
            /// </summary>
            public RejectStatuses BankruptKgd { get; set; }

            /// <summary>
            /// PKB: Розыск преступников, должников, без вести пропавших лиц Комитетом по правовой статистике и специальным учетам ГП РК KPS01
            /// </summary>
            public RejectStatuses QamqorList { get; set; }

            /// <summary>
            /// PKB:Сведения о лицах, привлеченные к уголовной отвественности за совершение уголовных правонарушений против половой неприкосновенности несовершеннолетних EGV01
            /// </summary>
            public RejectStatuses Pedophile { get; set; }

            /// <summary>
            /// PKB:Перечень организаций и лиц, связанных с финансированием терроризма и экстремизма
            /// </summary>
            public RejectStatuses TerrorList { get; set; }



            /// <summary>
            /// ?: Список налогоплательщиков, признанных бездействующими
            /// </summary>
            public RejectStatuses Inactive { get; set; }

            /// <summary>
            /// ?: Сведения об отсутствии (наличии) задолженности, учет по которым ведется в органах государственных доходов
            /// </summary>
            public RejectStatuses TaxArrear { get; set; }

            /// <summary>
            /// ?: Розыск алиментщиков Комитетом по правовой статистике и специальным учетам ГП РК
            /// </summary>
            public RejectStatuses QamqorAlimony { get; set; }


    

        

        }

        public class MonthlyPay
        {
            public double Payments { get; set; }
            public string Currency { get; set; }
            public string FinInstitut { get; set; }
            public double PeriodPayments { get; set; }
            public string PeriodPaymentsName { get; set; }
        }

        public class PolicyContractVars 
        {
            PolicyResult policyResult { get; set; }
            public int FinAnalysisId { get; set; }
            #region Parse
            /// <summary>
            /// Кредитор, банк
            /// </summary>
            public string FinancialInstitution { get; set; }

            /// <summary>
            /// Код валюты KZT
            /// </summary>
            public string CurrencyCode { get; set; }

            /// <summary>
            /// Общая сумма кредита
            /// </summary>
            public double TotalAmount { get; set; }

            /// <summary>
            /// Минимальный платеж
            /// </summary>
            public double MonthlyInstalmentAmount { get; set; }

            /// <summary>
            /// Дата фактической выдачи
            /// </summary>
            public DateTime? ActualDate { get; set; }

            /// <summary>
            /// Максимальное количество дней просрочки с начала действия договора
            /// </summary>
            public int NumberOfOverdueInstalmentsMax { get; set; }

            /// <summary>
            /// Дата актуальности информации по просрочке
            /// </summary>
            public DateTime? NumberOfOverdueInstalmentsMaxDate { get; set; }

            /// <summary>
            /// Сумма по просрочке
            /// </summary>
            public double NumberOfOverdueInstalmentsMaxAmount { get; set; }

            /// <summary>
            /// Максимальная сумма просроченных взносов с начала действия договора
            /// </summary>
            public double OverdueAmountMax { get; set; }

            /// <summary>
            /// Актуальность информации
            /// </summary>
            public DateTime LastUpdate { get; set; }

            /// <summary>
            /// Использованная сумма, подлежащая погашению (Остаток основного долга)
            /// </summary>
            public double ResidualAmount { get; set; }

            /// <summary>
            /// Кол-во дней просрочки
            /// </summary>
            public int NumberOfOverdueInstalments { get; set; }

            /// <summary>
            /// Сумма просроченных взносов
            /// </summary>
            public double OverdueAmount { get; set; }

            /// <summary>
            /// Роль, заемщик
            /// </summary>
            public string SubjectRole { get; set; }

            #endregion

            public bool IsArchive { get; set; }
            public DateTime CreateDateTime { get; set; }
        }
    }
}
