using System.Collections.Generic;

namespace Agro.Bpm.Logic.CQRS.ReportDocuments.DTOs
{
    public class CreditCommitteeMeetingDto
    {
        /// <summary>
        /// Область (регион)
        /// </summary>
        public string Region { get; set; }

        /// <summary>
        /// Номер протокола
        /// </summary>
        public string ProtocolNumber { get; set; }

        /// <summary>
        /// Город
        /// </summary>
        public string City { get; set; }

        /// <summary>
        /// Дата последнего голосования
        /// </summary>
        public string LastVotedDate { get; set; }

        /// <summary>
        /// Председательствовавший человек (ФИО, должность)
        /// </summary>
        public MemberDto Presided { get; set; } = new MemberDto();

        /// <summary>
        /// Представители кредитного комитета (ФИО, должность)
        /// </summary>
        public List<MemberDto> CreditCommitteeMembers { get; set; } = new List<MemberDto>();

        /// <summary>
        /// Имя заявителя
        /// </summary>
        public string ApplicantName { get; set; }

        /// <summary>
        /// Адрес регистрации заявителя
        /// </summary>
        public string ApplicantAddress { get; set; }

        /// <summary>
        /// Докладчик (ФИО, должность)
        /// </summary>
        public MemberDto Reporter { get; set; } = new MemberDto();

        /// <summary>
        /// Запрашиваемые условия
        /// </summary>
        public ConditionDto RequestedConditions { get; set; } = new ConditionDto();

        /// <summary>
        /// Заключение департамента риск-менеджмента
        /// </summary>
        public bool RiskManagementDepartmentConclusion { get; set; }

        /// <summary>
        /// Заключение департамента безопасности
        /// </summary>
        public bool SecurityDepartmentConclusion { get; set; }

        /// <summary>
        /// Заключение правового департамента
        /// </summary>
        public bool LegalDepartmentConclusion { get; set; }

        /// <summary>
        /// Представляемые условия
        /// </summary>
        public ConditionDto ProvidedConditions { get; set; } = new ConditionDto();
    }

    public class MemberDto
    {
        /// <summary>
        /// Должность
        /// </summary>
        public string Position { get; set; }

        /// <summary>
        /// ФИО
        /// </summary>
        public string Fullname { get; set; }

        /// <summary>
        /// Решение
        /// </summary>
        public bool Decision { get; set; }

        /// <summary>
        /// Примечание
        /// </summary>
        public string Comment { get; set; }
    }

    public class ConditionDto
    {
        /// <summary>
        /// Кредитный продукт
        /// </summary>
        public string CreditProduct { get; set; }

        /// <summary>
        /// Предмет лизинга
        /// </summary>
        public List<string> LizingSubject { get; set; }

        /// <summary>
        /// Поставщик
        /// </summary>
        public List<string> Supplier { get; set; }

        /// <summary>
        /// Источник финансирования
        /// </summary>
        public string FinanceSource { get; set; }

        /// <summary>
        /// Стоимость предмета лизинга
        /// </summary>
        public decimal Sum { get; set; }

        /// <summary>
        /// Авансовый платеж
        /// </summary>
        public List<string> CoFinancing { get; set; }

        /// <summary>
        /// Срок финансирования
        /// </summary>
        public List<string> Period { get; set; }

        /// <summary>
        /// Ставка вознаграждения
        /// </summary>
        public string Rate { get; set; }

        /// <summary>
        /// Индексация
        /// </summary>
        public string Indexing { get; set; }

        /// <summary>
        /// Порядок погашения основного долга
        /// </summary>
        public string PrincipalDebtRepaymentProcedure { get; set; }

        /// <summary>
        /// Порядок погашения вознаграждения
        /// </summary>
        public string RewardsRepaymentProcedure { get; set; }

        /// <summary>
        /// Комиссия за рассмотрение проекта
        /// </summary>
        public string ProjectReviewCommission { get; set; }

        /// <summary>
        /// Центр поставки
        /// </summary>
        public string DeliveryPoint { get; set; }

        /// <summary>
        /// Пункт прибыли
        /// </summary>
        public string ProfitCenter { get; set; }

        /// <summary>
        /// Периодичность мониторинга
        /// </summary>
        public string MonitoringFrequency { get; set; }

        /// <summary>
        /// Страхование
        /// </summary>
        public string Insurance { get; set; }

        /// <summary>
        /// Особое условие
        /// </summary>
        public string SpecialCondition { get; set; }
    }
}
