using System.Xml;

namespace Agro.Integration.Logic.OutService.GBDFL.Parse
{
    /// <summary>
    ///     Национальность
    /// </summary>
    public class Nationality : CodeNameWithKz
    {
        public Nationality()
        {
        }

        public Nationality(string Code) : base(Code)
        {
        }

        public Nationality(string Code, string Name, string NameKz) : base(Code, Name, NameKz)
        {
        }

        public Nationality(XmlNode xmlNode) : base(xmlNode)
        {
        }
    }
}