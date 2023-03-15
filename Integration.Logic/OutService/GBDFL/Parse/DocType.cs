using System.Xml;

namespace Agro.Integration.Logic.OutService.GBDFL.Parse
{
    /// <summary>
    ///     Тип документа
    /// </summary>
    public class DocType : CodeNameWithKz
    {
        public DocType()
        {
        }

        public DocType(string Code) : base(Code)
        {
        }

        public DocType(string Code, string Name, string NameKz) : base(Code, Name, NameKz)
        {
        }

        public DocType(XmlNode xmlNode) : base(xmlNode)
        {
        }
    }
}