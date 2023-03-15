using Agro.Shared.Data.Entities.Base;
using Agro.Shared.Data.Repos.Dictionary;
using System;
using System.Threading.Tasks;

namespace Agro.Shared.Logic.Dictionary
{
    public interface IDictionaryLogic
    {
        DictionaryRepo<T> DictionaryRepo<T>() where T : BaseDictionary;
        Task<T> Add<T>(T model) where T : BaseDictionary;
        Task Update<T>(T model) where T : BaseDictionary;
    }
}
