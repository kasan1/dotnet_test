using System.Collections.Generic;

namespace Agro.Shared.Logic.Models.Email
{
    public class EmailMessage
    {
        /// <summary>
        /// Subject
        /// </summary>
        public string Subject { get; set; }

        /// <summary>
        /// Message content
        /// </summary>
        public string Content { get; set; }

        /// <summary>
        /// Recipients
        /// </summary>
        public List<string> To { get; set; } = new List<string>();

        /// <summary>
        /// Carbon copy recipients
        /// </summary>
        public List<string> CC { get; set; } = new List<string>();
    }
}
