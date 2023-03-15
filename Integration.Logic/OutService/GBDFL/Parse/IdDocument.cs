using System;

namespace Agro.Integration.Logic.OutService.GBDFL.Parse
{
    /// <summary>
    ///     Документ удостоверяющий личность
    /// </summary>
    public class IdDocument
    {
        /// <summary>
        ///     Тип документа
        /// </summary>
        public DocType Type { get; set; }

        /// <summary>
        ///     Кем выдано
        /// </summary>
        public IssueOrganization IssueOrganization { get; set; }

        /// <summary>
        ///     Статус
        /// </summary>
        public DocStatus Status { get; set; }

        /// <summary>
        ///     Номер документа
        /// </summary>
        public string Number { get; set; }

        /// <summary>
        ///     Дата выдачи
        /// </summary>
        public DateTime BeginDate { get; set; }

        /// <summary>
        ///     Дата окончания
        /// </summary>
        public DateTime EndDate { get; set; }
    }
}