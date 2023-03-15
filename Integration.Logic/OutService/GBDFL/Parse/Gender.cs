using System.Xml;

namespace Agro.Integration.Logic.OutService.GBDFL.Parse
{
    /// <summary>
    ///     Пол человека
    /// </summary>
    public class Gender : CodeNameWithKz
    {
        public Gender()
        {
        }

        public Gender(string Code) : base(Code)
        {
        }

        public Gender(string Code, string Name, string NameKz) : base(Code, Name, NameKz)
        {
        }

        public Gender(XmlNode xmlNode) : base(xmlNode)
        {
        }
    }
}