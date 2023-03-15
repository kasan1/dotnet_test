using System.Collections.Generic;
using System.Linq;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Wordprocessing;

namespace Agro.Shared.Logic.Extensions
{
    public static class OpenXmlCompositeElementExtensions
    {
        public static void FindParagraphAndReplaceText(this OpenXmlCompositeElement element, string oldValue, string newValue, RunProperties runProperties = null)
        {
            var children = element.Descendants<Paragraph>().Where(x => x.InnerText.Contains(oldValue));

            foreach (var child in children)
            {
                var textContent = child.InnerText.Replace(oldValue, newValue);
                child.RemoveAllChildren();

                var props = runProperties != null 
                    ? (RunProperties)runProperties.Clone() 
                    : new RunProperties() { FontSize = new FontSize() { Val = "20" } };

                child.Append(new Run(props, new Text(textContent)));
            }
        }

        public static void FindParagraphAndReplaceText(this OpenXmlCompositeElement element, string oldValue, IEnumerable<string> newValue)
        {
            var children = element.Descendants<Paragraph>().Where(x => x.InnerText.Contains(oldValue));
            foreach (var child in children)
            {
                var initialText = child.InnerText;
                child.RemoveAllChildren();

                foreach (var (index, value) in newValue.Select((v, index) => (index, v)))
                {
                    var runProperties = new RunProperties() { FontSize = new FontSize() { Val = "20" } };

                    child.Append(new Run(runProperties, new Text(initialText.Replace(oldValue, value))));
                    
                    if (index != newValue.Count() - 1) 
                        child.Append(new Break());
                }
            }
        }
    }
}
