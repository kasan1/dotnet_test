using Agro.Shared.Data.Attributes;

namespace Agro.Shared.Data.Enums.Identity
{
    /// <summary>
    /// Роли
    /// </summary>
    public enum RoleType
    {
        /// <summary>
        /// Администратор
        /// </summary>
        [Directory("09704848-58D2-47D4-8939-08D86FFEDB1D", "Admin")]
        Admin = 1,

        /// <summary>
        /// Кредитный менеджер
        /// </summary>
        [Directory("04239152-33AF-4071-8B84-686660C6C151", "CreditManager")]
        CreditManager = 7,

        /// <summary>
        /// Член кредитного комитет 
        /// </summary>
        [Directory("BAFC5489-4359-49ED-D251-08D8E1ECBA81", "CreditCommittee")]
        CreditCommittee = 11,
        [Directory("6B20B2F2-2FBE-4D6F-91E5-F1E5C1DB8E90", "CreditCommittee1")] // Не использовать Id(), SystemName()
        CreditCommittee1 = 11,
        [Directory("380CAD1C-20C1-44F5-AF25-606B2BE0EA48", "CreditCommittee2")] // Не использовать Id(), SystemName()
        CreditCommittee2 = 11,
        [Directory("883A571B-58BF-4B70-A324-7ADB7BB1FA81", "CreditCommittee3")] // Не использовать Id(), SystemName()
        CreditCommittee3 = 11,
        [Directory("3DEBEA62-3B35-485C-988F-421105B1BBEA", "CreditCommittee4")] // Не использовать Id(), SystemName()
        CreditCommittee4 = 11,
        [Directory("8D033B74-856F-4FA4-95C5-EA7B55C8A4CE", "CreditCommittee5")] // Не использовать Id(), SystemName()
        CreditCommittee5 = 11,

        /// <summary>
        /// Залогодатель
        /// </summary>
        [Directory("2F237466-B4F1-48B9-B14C-B6CF717ED224", "Pledger")]
        Pledger = 12,

        /// <summary>
        /// Кредитный админстратор
        /// </summary>
        [Directory("26B33317-91D0-42B8-905D-08D8E1EA76A3", "CredAdmin")]
        CredAdmin = 15,

        /// <summary>
        /// Закупщик
        /// </summary>
        [Directory("5FB9F021-E553-46B3-BEE4-E3D96F995E80", "Purchaser")]
        Purchaser = 16,

        /// <summary>
        /// Юрист
        /// </summary>
        [Directory("C6D623FC-ECC9-4C8A-8F01-0C543AAB70D9", "Jurist")]
        Jurist = 17,

        /// <summary>
        /// Менеджер по безопасности (СБ)
        /// </summary>
        [Directory("FC7A5055-4E94-4CF5-9B6F-1ED968EF425F", "SecurityManager")]
        SecurityManager = 18,

        /// <summary>
        /// Риск менеджер
        /// </summary>
        [Directory("AECF3004-49CA-4B71-B5C6-E0C69373AF28", "RiskManager")]
        RiskManager = 19,

        /// <summary>
        /// Комплеанс менеджер
        /// </summary>
        [Directory("8F7F4E3C-D607-4060-47C1-08D91F280430", "ComplianceManager")]
        ComplianceManager = 20,

        /// <summary>
        /// Председатель кредитного комитета
        /// </summary>
        [Directory("1764F9F3-F36C-473B-9204-96E4182D9405", "CreditCommitteeChairman")]
        CreditCommitteeChairman = 21,

        /// <summary>
        /// Логист
        /// </summary>
        [Directory("FE9F6CD7-BC2C-4875-AF30-6ACB6CDD9CD7", "Logist")]
        Logist = 22
    }
}
