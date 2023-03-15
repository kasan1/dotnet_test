using System.Xml;

namespace Agro.Integration.Logic.OutService.GBDFL.Parse
{
    /// <summary>
    ///     Жизненный статус физического лица
    /// </summary>
    public class LifeStatus : CodeNameWithKz
    {
        public LifeStatus()
        {
        }

        public LifeStatus(string Code) : base(Code)
        {
        }

        public LifeStatus(string Code, string Name, string NameKz) : base(Code, Name, NameKz)
        {
        }

        public LifeStatus(XmlNode xmlNode) : base(xmlNode)
        {
        }
    }
}