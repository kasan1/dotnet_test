using System.Xml;

namespace Agro.Integration.Logic.OutService.GBDFL.Parse
{
    public class CodeNameWithKz : ICodeNameWithKz
    {
        public CodeNameWithKz()
        {
        }

        public CodeNameWithKz(string Code)
        {
            this.Code = Code;
        }

        public CodeNameWithKz(string Code, string Name, string NameKz)
        {
            this.Code = Code;
            this.Name = Name;
            this.NameKz = NameKz;
        }

        public CodeNameWithKz(XmlNode xmlNode)
        {
            if (xmlNode != null)
            {
                if (xmlNode.SelectSingleNode("code") != null) Code = xmlNode.SelectSingleNode("code").InnerText;
                if (xmlNode.SelectSingleNode("nameRu") != null) Name = xmlNode.SelectSingleNode("nameRu").InnerText;
                if (xmlNode.SelectSingleNode("nameKz") != null) NameKz = xmlNode.SelectSingleNode("nameKz").InnerText;
            }
        }

        public string Code { get; set; }
        public string Name { get; set; }
        public string NameKz { get; set; }
    }
}