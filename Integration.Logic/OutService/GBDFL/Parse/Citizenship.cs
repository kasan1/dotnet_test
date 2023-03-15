using System.Xml;

namespace Agro.Integration.Logic.OutService.GBDFL.Parse
{
    /// <summary>
    ///     Гражданство
    /// </summary>
    public class Citizenship : CodeNameWithKz
    {
        public Citizenship()
        {
        }

        public Citizenship(string Code) : base(Code)
        {
        }

        public Citizenship(string Code, string Name, string NameKz) : base(Code, Name, NameKz)
        {
        }

        public Citizenship(XmlNode xmlNode) : base(xmlNode)
        {
        }
    }
}