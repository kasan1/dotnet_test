using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Agro.Shared.Data.Primitives
{
    public enum PledgeFirstLevel
    {
        [Display(Name = "Недвижимое имущество")]
        Nonmovable = 1,
        [Display(Name = "Движимое имущество")]
        Movable = 2,
        [Display(Name = "Гарантия")]
        Guarantee = 3
    }
}
