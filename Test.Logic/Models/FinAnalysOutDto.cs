using System;
using System.Collections.Generic;
using System.Text;
using static Agro.Shared.Data.Context.PolicyRules;

namespace Agro.Okaps.Logic.Models
{
    public class FinAnalysOutDto
    {
        /// <summary>
        /// Соответствие общим треболваниям
        /// </summary>
        public RejectStatuses Status { get; set; }

        /// <summary>
        /// Отсутствие текущий просрочки
        /// </summary>
        public RejectStatuses CreditHistory { get; set; }
        public string CreditHistoryDetail { get; set; } = "Количество дней непрерывной просрочки ";


        /*/// <summary>
        /// ГКБ: наличие текущей просрочки по запросу ГКБ
        /// </summary>
        public bool ExistenceOfAmountDPD { get; set; }

        /// <summary>
        ////количество дней просрочки по текущим кредитам
        /// </summary>
        public double SumOverdueAmount { get; set; }

        /// <summary>
        /// отсутствие просрочек за последние 2 года
        /// </summary>
        public bool ExistDPDPastInToYears { get; set; }

        /// <summary>
        /// количество дней просрочек за последние 2 года
        /// </summary>
        public double CountDPDPastInToYears { get; set; }*/


        /// <summary>
        /// Кредитный обязательства за 12 месяцев, пока отключаем
        /// </summary>
        public double AnnualPay { get; set; }

        ///// <summary>
        ///// Проходи ли по кредитным обязательствам,  пока отключаем
        ///// </summary>
        //public bool AnnualPaySuccess { get; set; }
        //public string AnnualPaySuccessDetail { get; set; } = "Кредитование невозможно, так как текущие кредитные обязательства превышают максимальный порог, по которому Вы можете получить кредит в АО «Фонд финансовой поддержки сельского хозяйства».";

        /// <summary>
        /// Многодетная семья
        /// </summary>
        public bool IsManyChildren { get; set; }

        public bool? IsAsa { get; set; }

        #region
        /// <summary>
        /// Перечень налогоплательщиков, осуществивших лжепредпринимательскую деятельность
        /// </summary>
        public RejectStatuses FalseBusiness { get; set; }
        public string FalseBusinessDetail { get; set; } = "Лжепредпринимательская деятельность";


        /// <summary>
        /// PKB: Списки несостоятельных должников/Список банкротов
        /// </summary>
        public RejectStatuses Bankrupt { get; set; }
        public string BankruptDetail { get; set; } = "Списки несостоятельных должников/Список банкротов";

        /// <summary>
        /// PKB: Розыск Комитетом государственных доходов Министерства Финансов РК
        /// </summary>
        public RejectStatuses WantedIncome { get; set; }
        public string WantedIncomeDetail { get; set; } = "Розыск комитетом государтсвенных доходов Министерства Финансов РК";

        /// <summary>
        /// Список налогоплательщиков, признанных бездействующими
        /// </summary>
        public RejectStatuses Inactive { get; set; }
        public string InactiveDetail { get; set; } = "Список налогоплательщиков признанных бездействующими";

        /// <summary>
        /// Список налогоплательщиков, признанных банкротами
        /// </summary>
        public RejectStatuses TaxesBankrupt { get; set; }
        public string TaxesBankruptDetail { get; set; } = "Список налогоплательщиков, признанных банкротами";

        /// <summary>
        /// Сведения об отсутствии (наличии) задолженности, учет по которым ведется в органах государственных доходов
        /// </summary>
        public RejectStatuses TaxArrear { get; set; }
        public string TaxArrearDetail { get; set; } = "Сведения об отсутствии (наличии) задолженности, учет по которым ведется в органах государственных доходов";


        /// <summary>
        /// PKB: Связь с финансированием терроризма
        /// </summary>
        public RejectStatuses TerrorList { get; set; }
        public string TerrorListDetail { get; set; } = "Связь с финансированием терроризма";

        /// <summary>
        /// PKB: Розыск алиментщиков Комитетом по правовой статистике и специальным учетам ГП РК
        /// </summary>
        public RejectStatuses Aliment { get; set; }
        public string AlimentDetail { get; set; } = "Розыск алиментщиков Комитетом по правовой статистике и специальным учетам ГП РК";


        /// <summary>
        /// Сведения о лицах, привлеченные к уголовной отвественности за совершение уголовных правонарушений против половой неприкосновенности несовершеннолетних
        /// </summary>
        public RejectStatuses Pedophily { get; set; }
        public string PedophilyDetail { get; set; } = "Сведения о лицах, привлеченных к уголовной ответственности за совершение уголовных правонарушений против половой неприкосновенности несовершеннолетних";

        /// <summary>
        /// PKB: Розыск преступников, должников, без вести пропавших лиц Комитетом по правовой статистике и специальным учетам ГП РК
        /// </summary>
        public RejectStatuses LostPeople { get; set; }
        public string LostPeopleDetail { get; set; } = "Розыск преступников, должников без вести пропавших лиц Комитетом по правовой статистике и специальным учетам ГП РК";


        #endregion

        /// <summary>
        /// Аффилирован или нет
        /// </summary>
        public RejectStatuses IsAffiliation { get; set; }
        public string AffiliationDetail { get; set; } = "Необходимо обратиться в Филиал (признак аффилированности/ЛСОО)";

        public Guid? CreditReportId { get; set; }
    }
}
