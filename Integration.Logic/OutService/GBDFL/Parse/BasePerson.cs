using System;
using System.Xml;

namespace Agro.Integration.Logic.OutService.GBDFL.Parse
{
    /// <summary>
    ///     Информация о человеке
    /// </summary>
    public class BasePerson
    {
        public BasePerson()
        {
        }

        public BasePerson(string SName, string Name, string FName)
        {
            this.SName = SName;
            this.Name = Name;
            this.FName = FName;
        }

        public BasePerson(string SName, string Name, string FName, string Iin)
        {
            this.SName = SName;
            this.Name = Name;
            this.FName = FName;
            this.Iin = Iin;
        }

        public BasePerson(string SName, string Name, string FName, string Iin, DateTime BirthDate)
        {
            this.SName = SName;
            this.Name = Name;
            this.FName = FName;
            this.Iin = Iin;
            this.BirthDate = BirthDate;
        }

        public BasePerson(XmlNode xmlNode, bool isOrg = false)
        {
            if (xmlNode != null)
            {
                if (isOrg)
                {
                    if (xmlNode.SelectSingleNode("IIN") != null) Iin = xmlNode.SelectSingleNode("IIN").InnerText;
                    if (xmlNode.SelectSingleNode("SurName") != null)
                        SName = xmlNode.SelectSingleNode("SurName").InnerText;
                    if (xmlNode.SelectSingleNode("Name") != null) Name = xmlNode.SelectSingleNode("Name").InnerText;
                    if (xmlNode.SelectSingleNode("MiddleName") != null)
                        FName = xmlNode.SelectSingleNode("MiddleName").InnerText;
                    if (!string.IsNullOrEmpty(Iin))
                        BirthDate = Convert.ToDateTime(Iin.Substring(4, 2) + "-" + Iin.Substring(2, 2) + "-" +
                                                       Iin.Substring(0, 2));
                }
                else
                {
                    if (xmlNode.SelectSingleNode("iin") != null) Iin = xmlNode.SelectSingleNode("iin").InnerText;
                    if (xmlNode.SelectSingleNode("surname") != null)
                        SName = xmlNode.SelectSingleNode("surname").InnerText;
                    if (xmlNode.SelectSingleNode("name") != null) Name = xmlNode.SelectSingleNode("name").InnerText;
                    if (xmlNode.SelectSingleNode("patronymic") != null)
                        FName = xmlNode.SelectSingleNode("patronymic").InnerText;
                    if (xmlNode.SelectSingleNode("birthDate") != null)
                        BirthDate = DateTime.Parse(xmlNode.SelectSingleNode("birthDate").InnerText);
                }
            }
        }

        /// <summary>
        ///     Фамилия
        /// </summary>
        public string SName { get; set; }

        /// <summary>
        ///     Имя
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        ///     Отчество
        /// </summary>
        public string FName { get; set; }

        /// <summary>
        ///     ИИН
        /// </summary>
        public string Iin { get; set; }

        /// <summary>
        ///     Дата рождения
        /// </summary>
        public DateTime BirthDate { get; set; }
    }
}