using Agro.Shared.Data.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace Agro.Shared.Data.Repos.Jurist
{
    public class JuristResultRepo : BaseRepo<JuristResult>,IJuristResultRepo
    {
        public JuristResultRepo(DataContext context) : base(context) { 
        
        }
    }
}

