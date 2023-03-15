using Agro.Shared.Data.Repos.LoanApplication;
using Agro.Shared.Logic.Models;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using System;
using System.IO;
using System.Linq;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Xsl;

namespace Agro.Shared.Logic
{
    public class PrintLogic : IPrintLogic
    {
        private string utilPath;
        ILoanApplicationRepo _loanAppRepo;

        public PrintLogic(ILoanApplicationRepo loanAppRepo)
        {
            _loanAppRepo = loanAppRepo;
            utilPath = Environment.CurrentDirectory+ "/Templates/";
        }

        public byte[] Generate(PrintInDto model)
        {
            XmlDocument xmlData = new XmlDocument();
            xmlData.LoadXml(model.XmlData);
            byte[] fileBytes = GenerateWord(model.Name, xmlData);
            if (model.Format.ToLower().Equals("pdf"))
                fileBytes = GeneratePdf(fileBytes);

            return fileBytes;
        }
        public byte[] GenerateWord(string name, XmlDocument xData)
        {
            string templateXslt = utilPath + name + ".xslt";
            byte[] bytes;
            try
            {
                StringWriter stringWriter = new StringWriter();
                XmlWriter xmlWriter = XmlWriter.Create(stringWriter);

                XmlDocument xsl = new XmlDocument();
                xsl.Load(templateXslt);

                XslCompiledTransform transform = new XslCompiledTransform();
                transform.Load(xsl);
                transform.Transform(xData, xmlWriter);

                XmlDocument newWordContent = new XmlDocument();
                newWordContent.LoadXml(stringWriter.ToString());

                byte[] byteArray = File.ReadAllBytes(utilPath + name + ".docx");
                using (MemoryStream stream = new MemoryStream())
                {
                    stream.Write(byteArray, 0, (int)byteArray.Length);
                    using (WordprocessingDocument output = WordprocessingDocument.Open(stream, true))
                    {
                        Body updatedBodyContent = new Body(newWordContent.DocumentElement.InnerXml);
                        output.MainDocumentPart.Document.Body = updatedBodyContent;
                        output.MainDocumentPart.Document.Save();
                    }
                    bytes = stream.ToArray();
                }
            }
            catch (Exception e)
            {
                throw new Exception("GenerateWord: " + e.Message);
            }
            return bytes;
        }
        public byte[] GeneratePdf(byte[] wordByte)
        {
            Stream stream2 = new MemoryStream(wordByte);
            var asposeDocument = new Aspose.Words.Document(stream2);

            MemoryStream stream = new MemoryStream();
            asposeDocument.Save(stream, Aspose.Words.SaveFormat.Pdf);

            return stream.ToArray();
        }
    }
}
