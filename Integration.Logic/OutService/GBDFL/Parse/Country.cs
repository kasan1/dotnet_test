using System.Xml;

namespace Agro.Integration.Logic.OutService.GBDFL.Parse
{
    public class Country : CodeNameWithKz
    {
        public Country()
        {
        }

        public Country(string Code) : base(Code)
        {
        }

        public Country(string Code, string Name, string NameKz) : base(Code, Name, NameKz)
        {
        }

        public Country(XmlNode xmlNode) : base(xmlNode)
        {
        }
    }
}