using Agro.Shared.Data.Context;
using Agro.Shared.Data.Entities.Base;
using Agro.Shared.Data.Repos.Dictionary;
using System.Threading.Tasks;

namespace Agro.Shared.Logic.Dictionary
{
    public class DictionaryLogic : IDictionaryLogic
    {
        private readonly DataContext _context = null;
        public DictionaryLogic(DataContext context)
        {
            _context = context;
        }

        public Task<T> Add<T>(T model) where T : BaseDictionary
        {
            var repo = new DictionaryRepo<T>(_context);
            return repo.Add(model);
        }

        public DictionaryRepo<T> DictionaryRepo<T>() where T : BaseDictionary
        {
            return new DictionaryRepo<T>(_context);
        }

        public Task Update<T>(T model) where T : BaseDictionary
        {
            var repo = new DictionaryRepo<T>(_context);
            return repo.Update(model);
        }
    }
}
