using System.Collections.Generic;

namespace Agro.Bpm.Logic.Models.Common
{
    public class TableData
    {
        public List<TableHeader> Header { get; set; } = new List<TableHeader>();
        public List<Dictionary<string, object>> Body { get; set; } = new List<Dictionary<string, object>>();
    }

    public class TableHeader
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public bool IsOrderBy { get; set; }
        public string OrderByDirection { get; set; }
    }
}
