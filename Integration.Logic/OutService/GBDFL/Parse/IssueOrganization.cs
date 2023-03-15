using System.Xml;

namespace Agro.Integration.Logic.OutService.GBDFL.Parse
{
    /// <summary>
    ///     Организация выдавший документ
    /// </summary>
    public class IssueOrganization : CodeNameWithKz
    {
        public IssueOrganization()
        {
        }

        public IssueOrganization(string Code) : base(Code)
        {
        }

        public IssueOrganization(string Code, string Name, string NameKz) : base(Code, Name, NameKz)
        {
        }

        public IssueOrganization(XmlNode xmlNode) : base(xmlNode)
        {
        }
    }
}