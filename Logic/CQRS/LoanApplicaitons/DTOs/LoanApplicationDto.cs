using System;

namespace Agro.Bpm.Logic.CQRS.LoanApplicaitons.DTOs
{
    public class LoanApplicationDto
    {
        public Guid LoanApplicationId { get; set; }
        public Guid LoanApplicationTaskId { get; set; }

        /// <summary>
        /// Регистрационный номер заявки
        /// </summary>
        public string RegisterNumber { get; set; }

        /// <summary>
        /// ИИН заявителя
        /// </summary>
        public string Iin { get; set; }

        /// <summary>
        /// ФИО заявителя
        /// </summary>
        public string Fullname { get; set; }

        /// <summary>
        /// Роль пользователя относительно задачи
        /// </summary>
        public string UserRole { get; set; }

        /// <summary>
        ///  Дата назначения пользователю
        /// </summary>
        public DateTime? AppointmentDate { get; set; }

        /// <summary>
        ///  Дата планового завершения
        /// </summary>
        public DateTime? PlanEndDate { get; set; }

        /// <summary>
        ///  Дата фактического завершения
        /// </summary>
        public DateTime? FactEndDate { get; set; }

        /// <summary>
        ///  Результат решения
        /// </summary>
        public string Decision { get; set; }

        /// <summary>
        /// Комментарии
        /// </summary>
        public string Comment { get; set; }

        /// <summary>
        /// Процессный статус
        /// </summary>
        public string LoanStatus { get; set; }

        /// <summary>
        /// Тип лизинга
        /// </summary>
        public string LoanType { get; set; }

        /// <summary>
        /// Целевой продукт займа
        /// </summary>
        public string LoanProduct { get; set; }

        public DateTime CreatedDate { get; set; }

        public LoanApplicationDto Generate()
        {
            LoanApplicationId = Guid.NewGuid();
            Iin = "123456789123";
            Fullname = "Асанулы Усен";
            LoanType = "Экспресс лизинг";
            LoanProduct = "Трактор К-700";
            AppointmentDate = DateTime.Now.AddHours(-3);
            PlanEndDate = AppointmentDate?.AddDays(2);
            LoanStatus = "На рассмотрении";
            Comment = "Здесь будет комментарий";
            return this;
        }
    }
}
