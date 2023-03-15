using System.Xml;

namespace Agro.Integration.Logic.OutService.GBDFL.Parse
{
    public class Region : CodeNameWithKz
    {
        public Region()
        {
        }

        public Region(string Code) : base(Code)
        {
        }

        public Region(string Code, string Name, string NameKz) : base(Code, Name, NameKz)
        {
        }

        public Region(XmlNode xmlNode) : base(xmlNode)
        {
        }
    }
}