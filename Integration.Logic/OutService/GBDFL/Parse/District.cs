using System.Xml;

namespace Agro.Integration.Logic.OutService.GBDFL.Parse
{
    public class District : CodeNameWithKz
    {
        public District()
        {
        }

        public District(string Code) : base(Code)
        {
        }

        public District(string Code, string Name, string NameKz) : base(Code, Name, NameKz)
        {
        }

        public District(XmlNode xmlNode) : base(xmlNode)
        {
        }
    }
}