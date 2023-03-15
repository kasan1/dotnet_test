namespace Agro.Integration.Logic.Models.C1
{
    public class Dic1cJsonDto<T> where T: Dic1cBaseEntityDto
    {
        public T[] value { get; set; }
    }
}