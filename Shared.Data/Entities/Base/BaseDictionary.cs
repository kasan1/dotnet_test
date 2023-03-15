using System.Globalization;

namespace Agro.Shared.Data.Entities.Base
{
    /// <summary>
    /// Базовый класс для справочников
    /// </summary>
    public class BaseDictionary : BaseEntity
    {
        /// <summary>
        /// Сортировка
        /// </summary>
        public int Sort { get; set; } 

        /// <summary>
        /// Код
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// Наименование на русском
        /// </summary>
        public string NameRu { get; set; }

        /// <summary>
        /// Наименование на казахском
        /// </summary>
        public string NameKk { get; set; }

        public string GetName() =>
            GetType()
                .GetProperty(
                    "Name"
                    + char.ToUpper(CultureInfo.CurrentCulture.TwoLetterISOLanguageName[0])
                    + CultureInfo.CurrentCulture.TwoLetterISOLanguageName[1..]
                )
                .GetValue(this, null)
                ?.ToString();
    }

    public abstract class BaseDictionaryDerived : BaseDictionary
    {
        public BaseDictionaryDerived() { }
        public BaseDictionaryDerived(BaseDictionary parent)
        {
            Code = parent.Code;
            CreatedDate = parent.CreatedDate;
            Id = parent.Id;
            IsDeleted = parent.IsDeleted;
            ModifiedDate = parent.ModifiedDate;
            NameKk = parent.NameKk;
            NameRu = parent.NameRu;
        }
    }
}
