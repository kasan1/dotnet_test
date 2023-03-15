﻿using System;
using System.Collections.Generic;
using System.Text;
using Agro.Shared.Data.Entities.Base;

namespace Agro.Shared.Data.Context.Dictionary
{
    public class DicAccessories : BaseDictionary
    {
        public Guid? DicTechTypeId { get; set; }
        public DicTechType DicTechType { get; set; }
    }
}
