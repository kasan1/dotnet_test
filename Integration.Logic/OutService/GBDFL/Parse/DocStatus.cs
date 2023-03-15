using System.Xml;

namespace Agro.Integration.Logic.OutService.GBDFL.Parse
{
    /// <summary>
    ///     Статус документа
    /// </summary>
    public class DocStatus : CodeNameWithKz
    {
        public DocStatus()
        {
        }

        public DocStatus(string Code) : base(Code)
        {
        }

        public DocStatus(string Code, string Name, string NameKz) : base(Code, Name, NameKz)
        {
        }

        public DocStatus(XmlNode xmlNode) : base(xmlNode)
        {
        }
    }
}