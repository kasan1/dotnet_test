using System.ComponentModel.DataAnnotations;

namespace Agro.Shared.Data.Primitives
{
    public enum PledgeSecondLevel
    {
        [Display(Name = "Жилое")]
        Living = 1,
        [Display(Name = "Коммерческое")]
        Commercial = 2,
        [Display(Name = "Земельный участок")]
        Land = 3,
        [Display(Name = "Транспорт")]
        Transport = 1,
        [Display(Name = "Деньги")]
        Money = 2
    }
}
