using System.Linq;
using DocumentFormat.OpenXml.Wordprocessing;

namespace Agro.Shared.Logic.Extensions
{
    public static class TextExtensions
    {
        public static void CheckAndReplaceText(this Text text, string oldValue, string newValue)
        {
            if (text != null && text.Text.Trim().Contains(oldValue))
            {
                text.Text = text.Text.Trim().Replace(oldValue, newValue ?? "");
            }
        }
    }
}
