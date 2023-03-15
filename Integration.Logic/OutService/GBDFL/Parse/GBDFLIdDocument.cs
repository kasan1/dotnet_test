using System;
using System.Xml;

namespace Agro.Integration.Logic.OutService.GBDFL.Parse
{
    /// <summary>
    ///     Документ удостоверяющий личность для ГБДФЛ
    /// </summary>
    public class GBDFLIdDocument : IdDocument
    {
        public GBDFLIdDocument()
        {
        }

        public GBDFLIdDocument(XmlNode xmlNode)
        {
            if (xmlNode != null)
            {
                if (xmlNode.SelectSingleNode("type") != null) Type = new DocType(xmlNode.SelectSingleNode("type"));
                if (xmlNode.SelectSingleNode("issueOrganization") != null)
                    IssueOrganization = new IssueOrganization(xmlNode.SelectSingleNode("issueOrganization"));
                if (xmlNode.SelectSingleNode("status") != null)
                    Status = new DocStatus(xmlNode.SelectSingleNode("status"));
                if (xmlNode.SelectSingleNode("number") != null)
                    Number = xmlNode.SelectSingleNode("number").InnerText;
                if (xmlNode.SelectSingleNode("beginDate") != null)
                    BeginDate = DateTime.Parse(xmlNode.SelectSingleNode("beginDate").InnerText);
                if (xmlNode.SelectSingleNode("endDate") != null)
                    EndDate = DateTime.Parse(xmlNode.SelectSingleNode("endDate").InnerText);
                if (xmlNode.SelectSingleNode("surname") != null) SName = xmlNode.SelectSingleNode("surname").InnerText;
                if (xmlNode.SelectSingleNode("name") != null) Name = xmlNode.SelectSingleNode("name").InnerText;
                if (xmlNode.SelectSingleNode("patronymic") != null)
                    FName = xmlNode.SelectSingleNode("patronymic").InnerText;
                if (xmlNode.SelectSingleNode("birthDate") != null)
                    BirthDate = DateTime.Parse(xmlNode.SelectSingleNode("birthDate").InnerText);
            }
        }

        /// <summary>Фамилия</summary>
        public string SName { get; set; }

        /// <summary>Имя</summary>
        public string Name { get; set; }

        /// <summary>Отчество</summary>
        public string FName { get; set; }

        /// <summary>Дата рождения</summary>
        public DateTime BirthDate { get; set; }
    }
}