using System.Collections.Generic;

namespace Agro.Shared.Logic.Models.Common
{
    public class ListResponse<T>
    {
        public List<T> List { get; set; }
        public int Count { get; set; }
    }
}
