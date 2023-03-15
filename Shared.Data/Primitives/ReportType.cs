using System;
using System.Collections.Generic;
using System.Linq;

namespace Agro.Shared.Logic.Primitives
{
    public enum ReportTypes
    {
        CreditNoData = -1, // CREDIT_NO_DATA пример ИИН 720727450134
        Negative = 0, //Негативный отчет
        Identification = 1, //Идентификационный отчет
        Initial = 2, //Первичный отчет
        Standard = 3, //Стандартный отчет
        Extended = 4, //Расширенный отчет
    }

    public static class ReportType
    {
        public const string Identification = "IDENTIFICATION";
        public const string Initial = "INITIAL";
        public const string Standard = "STANDARD";
        public const string Extended = "EXTENDED";
        public const string Negative = "NEGATIVE";
        public const string CreditNoData = "CREDIT_NO_DATA";

        public static KeyValuePair<ReportTypes, string> KeyValuePair(string value)
        {
            switch (value.Trim())
            {
                case Identification:
                    return new KeyValuePair<ReportTypes, string>(ReportTypes.Identification, Identification);
                case Initial:
                    return new KeyValuePair<ReportTypes, string>(ReportTypes.Initial, Initial);
                case Standard:
                    return new KeyValuePair<ReportTypes, string>(ReportTypes.Standard, Standard);
                case Extended:
                    return new KeyValuePair<ReportTypes, string>(ReportTypes.Extended, Extended);
                case Negative:
                    return new KeyValuePair<ReportTypes, string>(ReportTypes.Negative, Negative);
                case CreditNoData:
                    return new KeyValuePair<ReportTypes, string>(ReportTypes.CreditNoData, CreditNoData);
                default:
                    throw new Exception("Тип отчета не найден.");
            }
        }

        public static string MostDetailedType(IDictionary<ReportTypes, string> reportTypes)
        {
            var reportType = reportTypes.OrderByDescending(x => x.Key).First();
            return reportType.Value.ToLower() + "Report";
        }
    }
}
