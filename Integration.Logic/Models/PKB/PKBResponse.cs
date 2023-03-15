using System;
using System.Xml.Serialization;

namespace Agro.Integration.Logic.Models.PKB
{
	[XmlRoot(ElementName = "ROOT")]
	public static class PKBResponse
    {
		// using System.Xml.Serialization;
		// XmlSerializer serializer = new XmlSerializer(typeof(ROOT));
		// using (StringReader reader = new StringReader(xml))
		// {
		//    var test = (ROOT)serializer.Deserialize(reader);
		// }

		[XmlRoot(ElementName = "DataIssue")]
		public class DataIssue
		{

			[XmlAttribute(AttributeName = "title")]
			public string Title { get; set; }

			[XmlAttribute(AttributeName = "value")]
			public string Value { get; set; }
		}

		[XmlRoot(ElementName = "IinBin")]
		public class IinBin
		{

			[XmlAttribute(AttributeName = "title")]
			public string Title { get; set; }

			[XmlAttribute(AttributeName = "value")]
			public double Value { get; set; }
		}

		[XmlRoot(ElementName = "Name")]
		public class Name
		{

			[XmlAttribute(AttributeName = "title")]
			public string Title { get; set; }

			[XmlAttribute(AttributeName = "value")]
			public string Value { get; set; }
		}

		[XmlRoot(ElementName = "BirthDate")]
		public class BirthDate
		{

			[XmlAttribute(AttributeName = "title")]
			public string Title { get; set; }

			[XmlAttribute(AttributeName = "value")]
			public string Value { get; set; }
		}

		[XmlRoot(ElementName = "Subject")]
		public class Subject
		{

			[XmlElement(ElementName = "Name")]
			public Name Name { get; set; }

			[XmlElement(ElementName = "BirthDate")]
			public BirthDate BirthDate { get; set; }
		}

		[XmlRoot(ElementName = "Header")]
		public class Header
		{

			[XmlElement(ElementName = "DataIssue")]
			public DataIssue DataIssue { get; set; }

			[XmlElement(ElementName = "IinBin")]
			public IinBin IinBin { get; set; }

			[XmlElement(ElementName = "Subject")]
			public Subject Subject { get; set; }

			[XmlAttribute(AttributeName = "title")]
			public string Title { get; set; }
		}

		[XmlRoot(ElementName = "Source")]
		public class Source
		{

			[XmlAttribute(AttributeName = "title")]
			public string Title { get; set; }

			[XmlAttribute(AttributeName = "value")]
			public string Value { get; set; }
		}

		[XmlRoot(ElementName = "ActualDate")]
		public class ActualDate
		{

			[XmlAttribute(AttributeName = "title")]
			public string Title { get; set; }

			[XmlAttribute(AttributeName = "value")]
			public string Value { get; set; }
		}

		[XmlRoot(ElementName = "RefreshDate")]
		public class RefreshDate
		{

			[XmlAttribute(AttributeName = "title")]
			public string Title { get; set; }

			[XmlAttribute(AttributeName = "value")]
			public string Value { get; set; }
		}

		[XmlRoot(ElementName = "Status")]
		public class Status
		{

			[XmlAttribute(AttributeName = "id")]
			public string Id { get; set; }

			[XmlAttribute(AttributeName = "title")]
			public string Title { get; set; }

			[XmlAttribute(AttributeName = "value")]
			public string Value { get; set; }
		}

		[XmlRoot(ElementName = "Areears")]
		public class Areears
		{

			[XmlElement(ElementName = "Source")]
			public Source Source { get; set; }

			[XmlElement(ElementName = "ActualDate")]
			public ActualDate ActualDate { get; set; }

			[XmlElement(ElementName = "RefreshDate")]
			public RefreshDate RefreshDate { get; set; }

			[XmlElement(ElementName = "Status")]
			public Status Status { get; set; }

			[XmlAttribute(AttributeName = "code")]
			public string Code { get; set; }

			[XmlAttribute(AttributeName = "title")]
			public string Title { get; set; }
		}

		[XmlRoot(ElementName = "SearchBy")]
		public class SearchBy
		{

			[XmlAttribute(AttributeName = "id")]
			public string Id { get; set; }

			[XmlAttribute(AttributeName = "title")]
			public string Title { get; set; }

			[XmlAttribute(AttributeName = "value")]
			public string Value { get; set; }
		}

		[XmlRoot(ElementName = "Companies")]
		public class Companies
		{

			[XmlAttribute(AttributeName = "title")]
			public string Title { get; set; }

			[XmlElement(ElementName = "Company")]
			public Company Company { get; set; }
		}

		[XmlRoot(ElementName = "Bankruptcy")]
		public class Bankruptcy
		{

			[XmlElement(ElementName = "Source")]
			public Source Source { get; set; }

			[XmlElement(ElementName = "ActualDate")]
			public ActualDate ActualDate { get; set; }

			[XmlElement(ElementName = "RefreshDate")]
			public RefreshDate RefreshDate { get; set; }

			[XmlElement(ElementName = "Status")]
			public Status Status { get; set; }

			[XmlElement(ElementName = "SearchBy")]
			public SearchBy SearchBy { get; set; }

			[XmlElement(ElementName = "Companies")]
			public Companies Companies { get; set; }

			[XmlAttribute(AttributeName = "code")]
			public string Code { get; set; }

			[XmlAttribute(AttributeName = "title")]
			public string Title { get; set; }
		}

		[XmlRoot(ElementName = "FalseBusi")]
		public class FalseBusi
		{

			[XmlElement(ElementName = "Source")]
			public Source Source { get; set; }

			[XmlElement(ElementName = "RefreshDate")]
			public RefreshDate RefreshDate { get; set; }

			[XmlElement(ElementName = "ActualDate")]
			public ActualDate ActualDate { get; set; }

			[XmlElement(ElementName = "Status")]
			public Status Status { get; set; }

			[XmlElement(ElementName = "SearchBy")]
			public SearchBy SearchBy { get; set; }

			[XmlElement(ElementName = "Companies")]
			public Companies Companies { get; set; }

			[XmlAttribute(AttributeName = "code")]
			public string Code { get; set; }

			[XmlAttribute(AttributeName = "title")]
			public string Title { get; set; }
		}

		[XmlRoot(ElementName = "L150o10")]
		public class L150o10
		{

			[XmlElement(ElementName = "Source")]
			public Source Source { get; set; }

			[XmlElement(ElementName = "ActualDate")]
			public ActualDate ActualDate { get; set; }

			[XmlElement(ElementName = "RefreshDate")]
			public RefreshDate RefreshDate { get; set; }

			[XmlElement(ElementName = "Status")]
			public Status Status { get; set; }

			[XmlElement(ElementName = "Companies")]
			public Companies Companies { get; set; }

			[XmlAttribute(AttributeName = "code")]
			public string Code { get; set; }

			[XmlAttribute(AttributeName = "title")]
			public string Title { get; set; }
		}

		[XmlRoot(ElementName = "TerrorList")]
		public class TerrorList
		{

			[XmlElement(ElementName = "Source")]
			public Source Source { get; set; }

			[XmlElement(ElementName = "RefreshDate")]
			public RefreshDate RefreshDate { get; set; }

			[XmlElement(ElementName = "ActualDate")]
			public ActualDate ActualDate { get; set; }

			[XmlElement(ElementName = "Status")]
			public Status Status { get; set; }

			[XmlElement(ElementName = "SearchBy")]
			public SearchBy SearchBy { get; set; }

			[XmlAttribute(AttributeName = "code")]
			public string Code { get; set; }

			[XmlAttribute(AttributeName = "title")]
			public string Title { get; set; }
		}

		[XmlRoot(ElementName = "KgdWanted")]
		public class KgdWanted
		{

			[XmlElement(ElementName = "Source")]
			public Source Source { get; set; }

			[XmlElement(ElementName = "ActualDate")]
			public ActualDate ActualDate { get; set; }

			[XmlElement(ElementName = "RefreshDate")]
			public RefreshDate RefreshDate { get; set; }

			[XmlElement(ElementName = "Status")]
			public Status Status { get; set; }

			[XmlElement(ElementName = "SearchBy")]
			public SearchBy SearchBy { get; set; }

			[XmlAttribute(AttributeName = "code")]
			public string Code { get; set; }

			[XmlAttribute(AttributeName = "title")]
			public string Title { get; set; }
		}

		[XmlRoot(ElementName = "QamqorAlimony")]
		public class QamqorAlimony
		{

			[XmlElement(ElementName = "Source")]
			public Source Source { get; set; }

			[XmlElement(ElementName = "ActualDate")]
			public ActualDate ActualDate { get; set; }

			[XmlElement(ElementName = "RefreshDate")]
			public RefreshDate RefreshDate { get; set; }

			[XmlElement(ElementName = "Status")]
			public Status Status { get; set; }

			[XmlElement(ElementName = "SearchBy")]
			public SearchBy SearchBy { get; set; }

			[XmlAttribute(AttributeName = "code")]
			public string Code { get; set; }

			[XmlAttribute(AttributeName = "title")]
			public string Title { get; set; }
		}

		[XmlRoot(ElementName = "QamqorList")]
		public class QamqorList
		{

			[XmlElement(ElementName = "Source")]
			public Source Source { get; set; }

			[XmlElement(ElementName = "ActualDate")]
			public ActualDate ActualDate { get; set; }

			[XmlElement(ElementName = "RefreshDate")]
			public RefreshDate RefreshDate { get; set; }

			[XmlElement(ElementName = "Status")]
			public Status Status { get; set; }

			[XmlElement(ElementName = "SearchBy")]
			public SearchBy SearchBy { get; set; }

			[XmlAttribute(AttributeName = "code")]
			public string Code { get; set; }

			[XmlAttribute(AttributeName = "title")]
			public string Title { get; set; }
		}

		[XmlRoot(ElementName = "Pedophile")]
		public class Pedophile
		{

			[XmlElement(ElementName = "Source")]
			public Source Source { get; set; }

			[XmlElement(ElementName = "ActualDate")]
			public ActualDate ActualDate { get; set; }

			[XmlElement(ElementName = "RefreshDate")]
			public RefreshDate RefreshDate { get; set; }

			[XmlElement(ElementName = "Status")]
			public Status Status { get; set; }

			[XmlElement(ElementName = "SearchBy")]
			public SearchBy SearchBy { get; set; }

			[XmlAttribute(AttributeName = "code")]
			public string Code { get; set; }

			[XmlAttribute(AttributeName = "title")]
			public string Title { get; set; }
		}

		[XmlRoot(ElementName = "HousingQueue")]
		public class HousingQueue
		{

			[XmlElement(ElementName = "Source")]
			public Source Source { get; set; }

			[XmlElement(ElementName = "ActualDate")]
			public ActualDate ActualDate { get; set; }

			[XmlElement(ElementName = "RefreshDate")]
			public RefreshDate RefreshDate { get; set; }

			[XmlElement(ElementName = "Status")]
			public Status Status { get; set; }

			[XmlElement(ElementName = "SearchBy")]
			public SearchBy SearchBy { get; set; }

			[XmlAttribute(AttributeName = "code")]
			public string Code { get; set; }

			[XmlAttribute(AttributeName = "title")]
			public string Title { get; set; }
		}

		[XmlRoot(ElementName = "EgovDebtors6M")]
		public class EgovDebtors6M
		{

			[XmlElement(ElementName = "Source")]
			public Source Source { get; set; }

			[XmlElement(ElementName = "ActualDate")]
			public ActualDate ActualDate { get; set; }

			[XmlElement(ElementName = "RefreshDate")]
			public RefreshDate RefreshDate { get; set; }

			[XmlElement(ElementName = "Status")]
			public Status Status { get; set; }

			[XmlElement(ElementName = "Companies")]
			public Companies Companies { get; set; }

			[XmlAttribute(AttributeName = "code")]
			public string Code { get; set; }

			[XmlAttribute(AttributeName = "title")]
			public string Title { get; set; }
		}

		[XmlRoot(ElementName = "EgovDebtors6MAgent")]
		public class EgovDebtors6MAgent
		{

			[XmlElement(ElementName = "Source")]
			public Source Source { get; set; }

			[XmlElement(ElementName = "ActualDate")]
			public ActualDate ActualDate { get; set; }

			[XmlElement(ElementName = "RefreshDate")]
			public RefreshDate RefreshDate { get; set; }

			[XmlElement(ElementName = "Status")]
			public Status Status { get; set; }

			[XmlElement(ElementName = "Companies")]
			public Companies Companies { get; set; }

			[XmlAttribute(AttributeName = "code")]
			public string Code { get; set; }

			[XmlAttribute(AttributeName = "title")]
			public string Title { get; set; }
		}

		[XmlRoot(ElementName = "EgovDeregistered5Year")]
		public class EgovDeregistered5Year
		{

			[XmlElement(ElementName = "Source")]
			public Source Source { get; set; }

			[XmlElement(ElementName = "ActualDate")]
			public ActualDate ActualDate { get; set; }

			[XmlElement(ElementName = "RefreshDate")]
			public RefreshDate RefreshDate { get; set; }

			[XmlElement(ElementName = "Status")]
			public Status Status { get; set; }

			[XmlElement(ElementName = "Companies")]
			public Companies Companies { get; set; }

			[XmlAttribute(AttributeName = "code")]
			public string Code { get; set; }

			[XmlAttribute(AttributeName = "title")]
			public string Title { get; set; }
		}

		[XmlRoot(ElementName = "TaxpayersDeRegistered")]
		public class TaxpayersDeRegistered
		{

			[XmlElement(ElementName = "Source")]
			public Source Source { get; set; }

			[XmlElement(ElementName = "ActualDate")]
			public ActualDate ActualDate { get; set; }

			[XmlElement(ElementName = "RefreshDate")]
			public RefreshDate RefreshDate { get; set; }

			[XmlElement(ElementName = "Status")]
			public Status Status { get; set; }

			[XmlElement(ElementName = "SearchBy")]
			public SearchBy SearchBy { get; set; }

			[XmlElement(ElementName = "Companies")]
			public Companies Companies { get; set; }

			[XmlAttribute(AttributeName = "code")]
			public string Code { get; set; }

			[XmlAttribute(AttributeName = "title")]
			public string Title { get; set; }
		}

		[XmlRoot(ElementName = "TaxMonitoring")]
		public class TaxMonitoring
		{

			[XmlElement(ElementName = "Source")]
			public Source Source { get; set; }

			[XmlElement(ElementName = "ActualDate")]
			public ActualDate ActualDate { get; set; }

			[XmlElement(ElementName = "RefreshDate")]
			public RefreshDate RefreshDate { get; set; }

			[XmlElement(ElementName = "Status")]
			public Status Status { get; set; }

			[XmlElement(ElementName = "SearchBy")]
			public SearchBy SearchBy { get; set; }

			[XmlElement(ElementName = "Companies")]
			public Companies Companies { get; set; }

			[XmlAttribute(AttributeName = "code")]
			public string Code { get; set; }

			[XmlAttribute(AttributeName = "title")]
			public string Title { get; set; }
		}

		[XmlRoot(ElementName = "WrongAddress")]
		public class WrongAddress
		{

			[XmlElement(ElementName = "Source")]
			public Source Source { get; set; }

			[XmlElement(ElementName = "ActualDate")]
			public ActualDate ActualDate { get; set; }

			[XmlElement(ElementName = "RefreshDate")]
			public RefreshDate RefreshDate { get; set; }

			[XmlElement(ElementName = "Status")]
			public Status Status { get; set; }

			[XmlElement(ElementName = "SearchBy")]
			public SearchBy SearchBy { get; set; }

			[XmlElement(ElementName = "Companies")]
			public Companies Companies { get; set; }

			[XmlAttribute(AttributeName = "code")]
			public string Code { get; set; }

			[XmlAttribute(AttributeName = "title")]
			public string Title { get; set; }
		}

		[XmlRoot(ElementName = "BankruptKgd")]
		public class BankruptKgd
		{

			[XmlElement(ElementName = "Source")]
			public Source Source { get; set; }

			[XmlElement(ElementName = "ActualDate")]
			public ActualDate ActualDate { get; set; }

			[XmlElement(ElementName = "RefreshDate")]
			public RefreshDate RefreshDate { get; set; }

			[XmlElement(ElementName = "Status")]
			public Status Status { get; set; }

			[XmlElement(ElementName = "SearchBy")]
			public SearchBy SearchBy { get; set; }

			[XmlElement(ElementName = "Companies")]
			public object Companies { get; set; }

			[XmlAttribute(AttributeName = "code")]
			public string Code { get; set; }

			[XmlAttribute(AttributeName = "title")]
			public string Title { get; set; }
		}

		[XmlRoot(ElementName = "InvalidRegistration")]
		public class InvalidRegistration
		{

			[XmlElement(ElementName = "Source")]
			public Source Source { get; set; }

			[XmlElement(ElementName = "ActualDate")]
			public ActualDate ActualDate { get; set; }

			[XmlElement(ElementName = "RefreshDate")]
			public RefreshDate RefreshDate { get; set; }

			[XmlElement(ElementName = "Status")]
			public Status Status { get; set; }

			[XmlElement(ElementName = "SearchBy")]
			public SearchBy SearchBy { get; set; }

			[XmlElement(ElementName = "Companies")]
			public Companies Companies { get; set; }

			[XmlAttribute(AttributeName = "code")]
			public string Code { get; set; }

			[XmlAttribute(AttributeName = "title")]
			public string Title { get; set; }
		}

		[XmlRoot(ElementName = "LegalEntity")]
		public class LegalEntity
		{

			[XmlElement(ElementName = "Source")]
			public Source Source { get; set; }

			[XmlElement(ElementName = "ActualDate")]
			public ActualDate ActualDate { get; set; }

			[XmlElement(ElementName = "RefreshDate")]
			public RefreshDate RefreshDate { get; set; }

			[XmlElement(ElementName = "Status")]
			public Status Status { get; set; }

			[XmlElement(ElementName = "SearchBy")]
			public SearchBy SearchBy { get; set; }

			[XmlElement(ElementName = "Companies")]
			public Companies Companies { get; set; }

			[XmlAttribute(AttributeName = "code")]
			public string Code { get; set; }

			[XmlAttribute(AttributeName = "title")]
			public string Title { get; set; }
		}

		[XmlRoot(ElementName = "KgdReturnedNotification")]
		public class KgdReturnedNotification
		{

			[XmlElement(ElementName = "Source")]
			public Source Source { get; set; }

			[XmlElement(ElementName = "ActualDate")]
			public ActualDate ActualDate { get; set; }

			[XmlElement(ElementName = "RefreshDate")]
			public RefreshDate RefreshDate { get; set; }

			[XmlElement(ElementName = "Status")]
			public Status Status { get; set; }

			[XmlElement(ElementName = "SearchBy")]
			public SearchBy SearchBy { get; set; }

			[XmlElement(ElementName = "Companies")]
			public Companies Companies { get; set; }

			[XmlAttribute(AttributeName = "code")]
			public string Code { get; set; }

			[XmlAttribute(AttributeName = "title")]
			public string Title { get; set; }
		}

		[XmlRoot(ElementName = "ReliableSuppliers")]
		public class ReliableSuppliers
		{

			[XmlElement(ElementName = "Source")]
			public Source Source { get; set; }

			[XmlElement(ElementName = "ActualDate")]
			public ActualDate ActualDate { get; set; }

			[XmlElement(ElementName = "RefreshDate")]
			public RefreshDate RefreshDate { get; set; }

			[XmlElement(ElementName = "Status")]
			public Status Status { get; set; }

			[XmlElement(ElementName = "SearchBy")]
			public SearchBy SearchBy { get; set; }

			[XmlElement(ElementName = "Companies")]
			public object Companies { get; set; }

			[XmlAttribute(AttributeName = "code")]
			public string Code { get; set; }

			[XmlAttribute(AttributeName = "title")]
			public string Title { get; set; }
		}

		[XmlRoot(ElementName = "UnreliableSuppliers")]
		public class UnreliableSuppliers
		{

			[XmlElement(ElementName = "Source")]
			public Source Source { get; set; }

			[XmlElement(ElementName = "ActualDate")]
			public ActualDate ActualDate { get; set; }

			[XmlElement(ElementName = "RefreshDate")]
			public RefreshDate RefreshDate { get; set; }

			[XmlElement(ElementName = "Status")]
			public Status Status { get; set; }

			[XmlElement(ElementName = "SearchBy")]
			public SearchBy SearchBy { get; set; }

			[XmlElement(ElementName = "Companies")]
			public Companies Companies { get; set; }

			[XmlAttribute(AttributeName = "code")]
			public string Code { get; set; }

			[XmlAttribute(AttributeName = "title")]
			public string Title { get; set; }
		}

		[XmlRoot(ElementName = "ViolationTaxCode")]
		public class ViolationTaxCode
		{

			[XmlElement(ElementName = "Source")]
			public Source Source { get; set; }

			[XmlElement(ElementName = "ActualDate")]
			public ActualDate ActualDate { get; set; }

			[XmlElement(ElementName = "RefreshDate")]
			public RefreshDate RefreshDate { get; set; }

			[XmlElement(ElementName = "Status")]
			public Status Status { get; set; }

			[XmlElement(ElementName = "SearchBy")]
			public SearchBy SearchBy { get; set; }

			[XmlElement(ElementName = "Companies")]
			public object Companies { get; set; }

			[XmlAttribute(AttributeName = "code")]
			public string Code { get; set; }

			[XmlAttribute(AttributeName = "title")]
			public string Title { get; set; }
		}

		[XmlRoot(ElementName = "Inactive")]
		public class Inactive
		{

			[XmlElement(ElementName = "Source")]
			public Source Source { get; set; }

			[XmlElement(ElementName = "ActualDate")]
			public ActualDate ActualDate { get; set; }

			[XmlElement(ElementName = "RefreshDate")]
			public RefreshDate RefreshDate { get; set; }

			[XmlElement(ElementName = "Status")]
			public Status Status { get; set; }

			[XmlElement(ElementName = "SearchBy")]
			public SearchBy SearchBy { get; set; }

			[XmlElement(ElementName = "Companies")]
			public object Companies { get; set; }

			[XmlAttribute(AttributeName = "code")]
			public string Code { get; set; }

			[XmlAttribute(AttributeName = "title")]
			public string Title { get; set; }
		}

		[XmlRoot(ElementName = "EOZ")]
		public class EOZ
		{

			[XmlElement(ElementName = "Source")]
			public Source Source { get; set; }

			[XmlElement(ElementName = "RefreshDate")]
			public RefreshDate RefreshDate { get; set; }

			[XmlElement(ElementName = "ActualDate")]
			public ActualDate ActualDate { get; set; }

			[XmlElement(ElementName = "Status")]
			public Status Status { get; set; }

			[XmlElement(ElementName = "SearchBy")]
			public SearchBy SearchBy { get; set; }

			[XmlElement(ElementName = "Companies")]
			public Companies Companies { get; set; }

			[XmlAttribute(AttributeName = "code")]
			public string Code { get; set; }

			[XmlAttribute(AttributeName = "title")]
			public string Title { get; set; }
		}

		[XmlRoot(ElementName = "LicenseDocument")]
		public class LicenseDocument
		{

			[XmlElement(ElementName = "Status")]
			public Status Status { get; set; }

			[XmlElement(ElementName = "ActualDate")]
			public ActualDate ActualDate { get; set; }

			[XmlElement(ElementName = "RefreshDate")]
			public RefreshDate RefreshDate { get; set; }

			[XmlElement(ElementName = "LicenseCount")]
			public object LicenseCount { get; set; }

			[XmlElement(ElementName = "Source")]
			public Source Source { get; set; }

			[XmlElement(ElementName = "SearchBy")]
			public SearchBy SearchBy { get; set; }

			[XmlElement(ElementName = "Companies")]
			public Companies Companies { get; set; }

			[XmlAttribute(AttributeName = "code")]
			public string Code { get; set; }

			[XmlAttribute(AttributeName = "title")]
			public string Title { get; set; }
		}

		[XmlRoot(ElementName = "JudicialAct")]
		public class JudicialAct
		{

			[XmlElement(ElementName = "Status")]
			public Status Status { get; set; }

			[XmlElement(ElementName = "ActualDate")]
			public ActualDate ActualDate { get; set; }

			[XmlElement(ElementName = "RefreshDate")]
			public RefreshDate RefreshDate { get; set; }

			[XmlElement(ElementName = "Source")]
			public Source Source { get; set; }

			[XmlElement(ElementName = "Rows")]
			public object Rows { get; set; }

			[XmlElement(ElementName = "SearchBy")]
			public SearchBy SearchBy { get; set; }

			[XmlAttribute(AttributeName = "code")]
			public string Code { get; set; }

			[XmlAttribute(AttributeName = "title")]
			public string Title { get; set; }
		}

		[XmlRoot(ElementName = "BinIin")]
		public class BinIin
		{

			[XmlAttribute(AttributeName = "title")]
			public string Title { get; set; }

			[XmlAttribute(AttributeName = "value")]
			public double Value { get; set; }
		}

		[XmlRoot(ElementName = "TaxPayerName")]
		public class TaxPayerName
		{

			[XmlAttribute(AttributeName = "title")]
			public string Title { get; set; }

			[XmlAttribute(AttributeName = "value")]
			public string Value { get; set; }
		}

		[XmlRoot(ElementName = "TotalDeby")]
		public class TotalDeby
		{

			[XmlAttribute(AttributeName = "title")]
			public string Title { get; set; }

			[XmlAttribute(AttributeName = "value")]
			public string Value { get; set; }
		}

		[XmlRoot(ElementName = "PensionDebt")]
		public class PensionDebt
		{

			[XmlAttribute(AttributeName = "title")]
			public string Title { get; set; }

			[XmlAttribute(AttributeName = "value")]
			public string Value { get; set; }
		}

		[XmlRoot(ElementName = "MedicalDebt")]
		public class MedicalDebt
		{

			[XmlAttribute(AttributeName = "title")]
			public string Title { get; set; }

			[XmlAttribute(AttributeName = "value")]
			public string Value { get; set; }
		}

		[XmlRoot(ElementName = "SocialDebt")]
		public class SocialDebt
		{

			[XmlAttribute(AttributeName = "title")]
			public string Title { get; set; }

			[XmlAttribute(AttributeName = "value")]
			public double Value { get; set; }
		}

		[XmlRoot(ElementName = "Company")]
		public class Company
		{

			[XmlElement(ElementName = "BinIin")]
			public BinIin BinIin { get; set; }

			[XmlElement(ElementName = "TaxPayerName")]
			public TaxPayerName TaxPayerName { get; set; }

			[XmlElement(ElementName = "TotalDeby")]
			public TotalDeby TotalDeby { get; set; }

			[XmlElement(ElementName = "PensionDebt")]
			public PensionDebt PensionDebt { get; set; }

			[XmlElement(ElementName = "MedicalDebt")]
			public MedicalDebt MedicalDebt { get; set; }

			[XmlElement(ElementName = "SocialDebt")]
			public SocialDebt SocialDebt { get; set; }

			[XmlElement(ElementName = "BIN")]
			public BIN BIN { get; set; }

			[XmlElement(ElementName = "Name")]
			public Name Name { get; set; }
		}

		[XmlRoot(ElementName = "TaxArrear")]
		public class TaxArrear
		{

			[XmlElement(ElementName = "Status")]
			public Status Status { get; set; }

			[XmlElement(ElementName = "ActualDate")]
			public ActualDate ActualDate { get; set; }

			[XmlElement(ElementName = "Source")]
			public Source Source { get; set; }

			[XmlElement(ElementName = "SearchBy")]
			public SearchBy SearchBy { get; set; }

			[XmlElement(ElementName = "RefreshDate")]
			public RefreshDate RefreshDate { get; set; }

			[XmlElement(ElementName = "Companies")]
			public Companies Companies { get; set; }

			[XmlAttribute(AttributeName = "code")]
			public string Code { get; set; }

			[XmlAttribute(AttributeName = "title")]
			public string Title { get; set; }
		}

		[XmlRoot(ElementName = "CompanyAtTheLiquidation")]
		public class CompanyAtTheLiquidation
		{

			[XmlElement(ElementName = "Status")]
			public Status Status { get; set; }

			[XmlElement(ElementName = "ActualDate")]
			public ActualDate ActualDate { get; set; }

			[XmlElement(ElementName = "RefreshDate")]
			public RefreshDate RefreshDate { get; set; }

			[XmlElement(ElementName = "Source")]
			public Source Source { get; set; }

			[XmlElement(ElementName = "SearchBy")]
			public SearchBy SearchBy { get; set; }

			[XmlElement(ElementName = "Companies")]
			public Companies Companies { get; set; }

			[XmlAttribute(AttributeName = "code")]
			public string Code { get; set; }

			[XmlAttribute(AttributeName = "title")]
			public string Title { get; set; }
		}

		[XmlRoot(ElementName = "StateEnterprise")]
		public class StateEnterprise
		{

			[XmlElement(ElementName = "Status")]
			public Status Status { get; set; }

			[XmlElement(ElementName = "ActualDate")]
			public ActualDate ActualDate { get; set; }

			[XmlElement(ElementName = "Source")]
			public Source Source { get; set; }

			[XmlElement(ElementName = "SearchBy")]
			public SearchBy SearchBy { get; set; }

			[XmlElement(ElementName = "RefreshDate")]
			public RefreshDate RefreshDate { get; set; }

			[XmlElement(ElementName = "Companies")]
			public object Companies { get; set; }

			[XmlAttribute(AttributeName = "code")]
			public string Code { get; set; }

			[XmlAttribute(AttributeName = "title")]
			public string Title { get; set; }
		}

		[XmlRoot(ElementName = "StatDoc")]
		public class StatDoc
		{

			[XmlElement(ElementName = "Status")]
			public Status Status { get; set; }

			[XmlElement(ElementName = "Source")]
			public Source Source { get; set; }

			[XmlElement(ElementName = "SearchBy")]
			public SearchBy SearchBy { get; set; }

			[XmlElement(ElementName = "RefreshDate")]
			public RefreshDate RefreshDate { get; set; }

			[XmlElement(ElementName = "ActualDate")]
			public ActualDate ActualDate { get; set; }

			[XmlAttribute(AttributeName = "code")]
			public string Code { get; set; }

			[XmlAttribute(AttributeName = "title")]
			public string Title { get; set; }
		}

		[XmlRoot(ElementName = "BIN")]
		public class BIN
		{

			[XmlAttribute(AttributeName = "title")]
			public string Title { get; set; }

			[XmlAttribute(AttributeName = "value")]
			public double Value { get; set; }
		}

		[XmlRoot(ElementName = "TaxPayment")]
		public class TaxPayment
		{

			[XmlElement(ElementName = "Status")]
			public Status Status { get; set; }

			[XmlElement(ElementName = "ActualDate")]
			public ActualDate ActualDate { get; set; }

			[XmlElement(ElementName = "Source")]
			public Source Source { get; set; }

			[XmlElement(ElementName = "SearchBy")]
			public SearchBy SearchBy { get; set; }

			[XmlElement(ElementName = "RefreshDate")]
			public RefreshDate RefreshDate { get; set; }

			[XmlElement(ElementName = "Companies")]
			public Companies Companies { get; set; }

			[XmlAttribute(AttributeName = "code")]
			public string Code { get; set; }

			[XmlAttribute(AttributeName = "title")]
			public string Title { get; set; }
		}

		[XmlRoot(ElementName = "DebtorBan")]
		public class DebtorBan
		{

			[XmlElement(ElementName = "Status")]
			public Status Status { get; set; }

			[XmlElement(ElementName = "ActualDate")]
			public ActualDate ActualDate { get; set; }

			[XmlElement(ElementName = "Source")]
			public Source Source { get; set; }

			[XmlElement(ElementName = "SearchBy")]
			public SearchBy SearchBy { get; set; }

			[XmlElement(ElementName = "RefreshDate")]
			public RefreshDate RefreshDate { get; set; }

			[XmlAttribute(AttributeName = "code")]
			public string Code { get; set; }

			[XmlAttribute(AttributeName = "title")]
			public string Title { get; set; }
		}

		[XmlRoot(ElementName = "AccrualsPayment")]
		public class AccrualsPayment
		{

			[XmlElement(ElementName = "Status")]
			public Status Status { get; set; }

			[XmlElement(ElementName = "ActualDate")]
			public ActualDate ActualDate { get; set; }

			[XmlElement(ElementName = "Source")]
			public Source Source { get; set; }

			[XmlElement(ElementName = "SearchBy")]
			public SearchBy SearchBy { get; set; }

			[XmlElement(ElementName = "RefreshDate")]
			public RefreshDate RefreshDate { get; set; }

			[XmlElement(ElementName = "Companies")]
			public Companies Companies { get; set; }

			[XmlAttribute(AttributeName = "code")]
			public string Code { get; set; }

			[XmlAttribute(AttributeName = "title")]
			public string Title { get; set; }
		}

		[XmlRoot(ElementName = "NewRow")]
		public class NewRow
		{

			[XmlAttribute(AttributeName = "title")]
			public string Title { get; set; }

			[XmlAttribute(AttributeName = "value")]
			public string Value { get; set; }
		}

		[XmlRoot(ElementName = "RNUGosZakup")]
		public class RNUGosZakup
		{

			[XmlElement(ElementName = "NewRow")]
			public NewRow NewRow { get; set; }

			[XmlElement(ElementName = "Source")]
			public Source Source { get; set; }

			[XmlElement(ElementName = "RefreshDate")]
			public RefreshDate RefreshDate { get; set; }

			[XmlElement(ElementName = "ActualDate")]
			public ActualDate ActualDate { get; set; }

			[XmlElement(ElementName = "Status")]
			public Status Status { get; set; }

			[XmlElement(ElementName = "SearchBy")]
			public SearchBy SearchBy { get; set; }

			[XmlElement(ElementName = "Companies")]
			public object Companies { get; set; }

			[XmlAttribute(AttributeName = "code")]
			public string Code { get; set; }

			[XmlAttribute(AttributeName = "title")]
			public string Title { get; set; }
		}

		[XmlRoot(ElementName = "status")]
		public class status
		{

			[XmlElement(ElementName = "text")]
			public string Text { get; set; }

			[XmlElement(ElementName = "id")]
			public string Id { get; set; }
		}

		[XmlRoot(ElementName = "Dynamic")]
		public class Dynamic
		{

			[XmlElement(ElementName = "date")]
			public string Date { get; set; }

			[XmlElement(ElementName = "code")]
			public string Code { get; set; }

			[XmlElement(ElementName = "type")]
			public string Type { get; set; }

			[XmlElement(ElementName = "title")]
			public string Title { get; set; }

			[XmlElement(ElementName = "url")]
			public string Url { get; set; }

			[XmlElement(ElementName = "status")]
			public status Status { get; set; }
		}

		[XmlRoot(ElementName = "Dynamics")]
		public class Dynamics
		{

			[XmlElement(ElementName = "Dynamic")]
			public Dynamic Dynamic { get; set; }
		}

		[XmlRoot(ElementName = "ROOT")]
		public class ROOT
		{

			[XmlElement(ElementName = "Header")]
			public Header Header { get; set; }

			[XmlElement(ElementName = "Areears")]
			public Areears Areears { get; set; }

			[XmlElement(ElementName = "Bankruptcy")]
			public Bankruptcy Bankruptcy { get; set; }

			[XmlElement(ElementName = "FalseBusi")]
			public FalseBusi FalseBusi { get; set; }

			[XmlElement(ElementName = "L150o10")]
			public L150o10 L150o10 { get; set; }

			[XmlElement(ElementName = "TerrorList")]
			public TerrorList TerrorList { get; set; }

			[XmlElement(ElementName = "KgdWanted")]
			public KgdWanted KgdWanted { get; set; }

			[XmlElement(ElementName = "QamqorAlimony")]
			public QamqorAlimony QamqorAlimony { get; set; }

			[XmlElement(ElementName = "QamqorList")]
			public QamqorList QamqorList { get; set; }

			[XmlElement(ElementName = "Pedophile")]
			public Pedophile Pedophile { get; set; }

			[XmlElement(ElementName = "HousingQueue")]
			public HousingQueue HousingQueue { get; set; }

			[XmlElement(ElementName = "EgovDebtors6M")]
			public EgovDebtors6M EgovDebtors6M { get; set; }

			[XmlElement(ElementName = "EgovDebtors6MAgent")]
			public EgovDebtors6MAgent EgovDebtors6MAgent { get; set; }

			[XmlElement(ElementName = "EgovDeregistered5Year")]
			public EgovDeregistered5Year EgovDeregistered5Year { get; set; }

			[XmlElement(ElementName = "TaxpayersDeRegistered")]
			public TaxpayersDeRegistered TaxpayersDeRegistered { get; set; }

			[XmlElement(ElementName = "TaxMonitoring")]
			public TaxMonitoring TaxMonitoring { get; set; }

			[XmlElement(ElementName = "WrongAddress")]
			public WrongAddress WrongAddress { get; set; }

			[XmlElement(ElementName = "BankruptKgd")]
			public BankruptKgd BankruptKgd { get; set; }

			[XmlElement(ElementName = "InvalidRegistration")]
			public InvalidRegistration InvalidRegistration { get; set; }

			[XmlElement(ElementName = "LegalEntity")]
			public LegalEntity LegalEntity { get; set; }

			[XmlElement(ElementName = "KgdReturnedNotification")]
			public KgdReturnedNotification KgdReturnedNotification { get; set; }

			[XmlElement(ElementName = "ReliableSuppliers")]
			public ReliableSuppliers ReliableSuppliers { get; set; }

			[XmlElement(ElementName = "UnreliableSuppliers")]
			public UnreliableSuppliers UnreliableSuppliers { get; set; }

			[XmlElement(ElementName = "ViolationTaxCode")]
			public ViolationTaxCode ViolationTaxCode { get; set; }

			[XmlElement(ElementName = "Inactive")]
			public Inactive Inactive { get; set; }

			[XmlElement(ElementName = "EOZ")]
			public EOZ EOZ { get; set; }

			[XmlElement(ElementName = "LicenseDocument")]
			public LicenseDocument LicenseDocument { get; set; }

			[XmlElement(ElementName = "JudicialAct")]
			public JudicialAct JudicialAct { get; set; }

			[XmlElement(ElementName = "TaxArrear")]
			public TaxArrear TaxArrear { get; set; }

			[XmlElement(ElementName = "CompanyAtTheLiquidation")]
			public CompanyAtTheLiquidation CompanyAtTheLiquidation { get; set; }

			[XmlElement(ElementName = "StateEnterprise")]
			public StateEnterprise StateEnterprise { get; set; }

			[XmlElement(ElementName = "StatDoc")]
			public StatDoc StatDoc { get; set; }

			[XmlElement(ElementName = "TaxPayment")]
			public TaxPayment TaxPayment { get; set; }

			[XmlElement(ElementName = "DebtorBan")]
			public DebtorBan DebtorBan { get; set; }

			[XmlElement(ElementName = "AccrualsPayment")]
			public AccrualsPayment AccrualsPayment { get; set; }

			[XmlElement(ElementName = "RNUGosZakup")]
			public RNUGosZakup RNUGosZakup { get; set; }

			[XmlElement(ElementName = "Dynamics")]
			public Dynamics Dynamics { get; set; }
		}
	}
}
