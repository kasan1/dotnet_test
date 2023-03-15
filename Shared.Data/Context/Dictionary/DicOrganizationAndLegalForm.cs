using Agro.Shared.Data.Entities.Base;
using Agro.Shared.Data.Primitives;

namespace Agro.Shared.Data.Context.Dictionary
{
    /// <summary>
    /// Организационно-правовая форма
    /// </summary>
    public class DicOrganizationAndLegalForm : BaseDictionary
    {
        public OrganizationAndLegalFormEnum Value { get; set; } = OrganizationAndLegalFormEnum.Default;
    }
}
