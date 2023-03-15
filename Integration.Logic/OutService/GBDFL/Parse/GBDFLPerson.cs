using Agro.Integration.Logic.OutService.GBDFL.Parse;
using System;
using System.Collections.Generic;
using System.Xml;

namespace Agro.Integration.Logic.OutService.GBDFL.Parse
{
    /// <summary>
    ///     Информация о физ. лице от ГБДФЛ
    /// </summary>
    public class GBDFLPerson : BasePerson
    {
        public GBDFLPerson()
        {
            Gender = new Gender();
            Nationality = new Nationality();
            Citizenship = new Citizenship();
            LifeStatus = new LifeStatus();
            BirthPlace = new GBDFLAddress();
            RegAddress = new GBDFLAddress();
            Documents = new List<GBDFLIdDocument>();
        }

        public GBDFLPerson(XmlDocument xmlDocument)
        {
            if (xmlDocument != null && xmlDocument.SelectSingleNode("//responseData/data/persons/person") != null &&
                xmlDocument.SelectSingleNode("//responseData/data/persons/person").HasChildNodes)
            {
                var personNode = xmlDocument.SelectSingleNode("//responseData/data/persons/person");
                if (personNode.SelectSingleNode("iin") != null) 
                    Iin = personNode.SelectSingleNode("iin").InnerText;
                if (personNode.SelectSingleNode("surname") != null)
                    SName = personNode.SelectSingleNode("surname").InnerText;
                if (personNode.SelectSingleNode("name") != null) Name = personNode.SelectSingleNode("name").InnerText;
                if (personNode.SelectSingleNode("patronymic") != null)
                    FName = personNode.SelectSingleNode("patronymic").InnerText;
                if (personNode.SelectSingleNode("birthDate") != null)
                    BirthDate = DateTime.Parse(personNode.SelectSingleNode("birthDate").InnerText);
                if (personNode.SelectSingleNode("gender") != null)
                    Gender = new Gender(personNode.SelectSingleNode("gender"));
                if (personNode.SelectSingleNode("nationality") != null)
                    Nationality = new Nationality(personNode.SelectSingleNode("nationality"));
                if (personNode.SelectSingleNode("citizenship") != null)
                    Citizenship = new Citizenship(personNode.SelectSingleNode("citizenship"));
                if (personNode.SelectSingleNode("lifeStatus") != null)
                    LifeStatus = new LifeStatus(personNode.SelectSingleNode("lifeStatus"));
                if (personNode.SelectSingleNode("birthPlace") != null)
                    BirthPlace = new GBDFLAddress(personNode.SelectSingleNode("birthPlace"));
                if (personNode.SelectSingleNode("regAddress") != null)
                    RegAddress = new GBDFLAddress(personNode.SelectSingleNode("regAddress"));
                if (personNode.SelectSingleNode("documents") != null &&
                    personNode.SelectSingleNode("documents/document") != null &&
                    personNode.SelectNodes("documents/document").Count > 0)
                {
                    Documents = new List<GBDFLIdDocument>();
                    foreach (XmlNode node in personNode.SelectNodes("documents/document"))
                    {
                        var idDoc = new GBDFLIdDocument(node);
                        Documents.Add(idDoc);
                    }
                }

                if (personNode.SelectSingleNode("removed") != null)
                    Removed = bool.Parse(personNode.SelectSingleNode("removed").InnerText);
            }
        }

        /// <summary>Пол</summary>
        public Gender Gender { get; set; }

        /// <summary>Национальность</summary>
        public Nationality Nationality { get; set; }

        /// <summary>Гражданство</summary>
        public Citizenship Citizenship { get; set; }

        /// <summary>Жизненный статус</summary>
        public LifeStatus LifeStatus { get; set; }

        /// <summary>Место рождения</summary>
        public GBDFLAddress BirthPlace { get; set; }

        /// <summary>Адрес прописки</summary>
        public GBDFLAddress RegAddress { get; set; }

        /// <summary>Документы удостоверяющий личность</summary>
        public List<GBDFLIdDocument> Documents { get; set; }

        /// <summary>Признак удаленности</summary>
        public bool Removed { get; set; }
    }
}