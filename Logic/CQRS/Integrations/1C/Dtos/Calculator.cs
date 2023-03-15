namespace Agro.Bpm.Logic.CQRS.Integrations._1C.DTOs
{
    public class Calculator
    {
        /// <summary>
        /// Ставка вознаграждения
        /// </summary>
        public decimal Rate { get; set; }

        /// <summary>
        /// софинансирование в %
        /// </summary>
        public decimal CoFinancing { get; set; }

        /// <summary>
        /// софинансирование в денежном выражении
        /// </summary>
        public decimal CoFinancingValue { get; set; }  
    }
}
