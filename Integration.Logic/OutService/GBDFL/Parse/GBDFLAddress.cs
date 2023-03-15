using System;
using System.Data;
using System.Data.SqlClient;
using System.Xml;

namespace Agro.Integration.Logic.OutService.GBDFL.Parse
{
    /// <summary>
    ///     Адрес
    /// </summary>
    public class GBDFLAddress
    {
        public GBDFLAddress()
        {
            Country = new Country();
            District = new District();
            Region = new Region();
        }

        public GBDFLAddress(XmlNode xmlNode)
        {
            if (xmlNode != null)
            {
                if (xmlNode.SelectSingleNode("country") != null)
                    Country = new Country(xmlNode.SelectSingleNode("country"));
                if (xmlNode.SelectSingleNode("district") != null)
                    District = new District(xmlNode.SelectSingleNode("district"));
                if (xmlNode.SelectSingleNode("region") != null) Region = new Region(xmlNode.SelectSingleNode("region"));
                if (xmlNode.SelectSingleNode("city") != null) City = xmlNode.SelectSingleNode("city").InnerText;
                if (xmlNode.SelectSingleNode("street") != null) Street = xmlNode.SelectSingleNode("street").InnerText;
                if (xmlNode.SelectSingleNode("building") != null)
                    Building = xmlNode.SelectSingleNode("building").InnerText;
                if (xmlNode.SelectSingleNode("flat") != null) Flat = xmlNode.SelectSingleNode("flat").InnerText;
                if (xmlNode.SelectSingleNode("arCode") != null) ArCode = xmlNode.SelectSingleNode("arCode").InnerText;
            }
        }

        /// <summary>
        ///     Страна
        /// </summary>
        public Country Country { get; set; }

        /// <summary>
        ///     Район
        /// </summary>
        public District District { get; set; }

        /// <summary>
        ///     Область
        /// </summary>
        public Region Region { get; set; }

        /// <summary>
        ///     Город
        /// </summary>
        public string City { get; set; }

        /// <summary>
        ///     Улица
        /// </summary>
        public string Street { get; set; }

        /// <summary>
        ///     Здание
        /// </summary>
        public string Building { get; set; }

        /// <summary>
        ///     Квартира
        /// </summary>
        public string Flat { get; set; }

        /// <summary>
        ///     ArCode
        /// </summary>
        public string ArCode { get; set; }

        public string GetAddressTxt
        {
            get
            {
                var addressTxt = Country.Name;
                if (!string.IsNullOrEmpty(addressTxt) && !string.IsNullOrEmpty(District.Name) && District.Name != "-")
                    addressTxt += ", " + District.Name;
                if (!string.IsNullOrEmpty(addressTxt) && !string.IsNullOrEmpty(Region.Name) && Region.Name != "-")
                    addressTxt += ", " + Region.Name;
                if (!string.IsNullOrEmpty(addressTxt) && !string.IsNullOrEmpty(City) && City != "-")
                    addressTxt += ", " + City;
                if (!string.IsNullOrEmpty(addressTxt) && !string.IsNullOrEmpty(Street) && Street != "-")
                    addressTxt += ", " + Street;
                if (!string.IsNullOrEmpty(addressTxt) && !string.IsNullOrEmpty(Building) && Building != "-")
                    addressTxt += ", " + Building;
                if (!string.IsNullOrEmpty(addressTxt) && !string.IsNullOrEmpty(Flat) && Flat != "-")
                    addressTxt += ", " + Flat;
                return addressTxt;
            }
        }

        public string GetAddressTxtKZ
        {
            get
            {
                var addressTxtKz = Country.NameKz;
                if (!string.IsNullOrEmpty(addressTxtKz) && !string.IsNullOrEmpty(District.NameKz) &&
                    District.NameKz != "-") addressTxtKz += ", " + District.NameKz;
                if (!string.IsNullOrEmpty(addressTxtKz) && !string.IsNullOrEmpty(Region.NameKz) && Region.NameKz != "-")
                    addressTxtKz += ", " + Region.NameKz;
                if (!string.IsNullOrEmpty(addressTxtKz) && !string.IsNullOrEmpty(City) && City != "-")
                    addressTxtKz += ", " + City;
                if (!string.IsNullOrEmpty(addressTxtKz) && !string.IsNullOrEmpty(Street) && Street != "-")
                    addressTxtKz += ", " + Street;
                if (!string.IsNullOrEmpty(addressTxtKz) && !string.IsNullOrEmpty(Building) && Building != "-")
                    addressTxtKz += ", " + Building;
                if (!string.IsNullOrEmpty(addressTxtKz) && !string.IsNullOrEmpty(Flat) && Flat != "-")
                    addressTxtKz += ", " + Flat;
                return addressTxtKz;
            }
        }
    }

    public class DistrictAndRegion
    {
        public District District { get; set; }
        public Region Region { get; set; }
    }
}