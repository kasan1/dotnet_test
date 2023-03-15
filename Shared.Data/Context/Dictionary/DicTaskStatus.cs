using Agro.Shared.Data.Entities.Base;
using System.Collections.Generic;

namespace Agro.Shared.Data.Context.Dictionary
{
    public class DicTaskStatus : BaseDictionary
    {

        public Dictionary<string, object> GetLogicVariables(string role)
        {
            var result = new Dictionary<string, object>();

            switch (Code)
            {
                case "InWork":
                    result.Add("delegateBy" + role, "0");
                    break;
                case "Completed":
                    result.Add("delegateBy" + role, "1");
                    break;
                case "Rejected":
                    result.Add("delegateBy" + role, "-1");
                    break;
                default:
                    break;
            }

            return result;
        }
    }
}
