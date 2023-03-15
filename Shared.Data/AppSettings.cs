namespace Agro.Shared.Data
{
    public class AppSettings
    {
        public BpmOptions Bpm { get; set; }
        public AuthOption AuthOptions { get; set; }
        public KalkanConfig KalkanConfig { get; set; }
        public CamundaOptions Camunda { get; set; }
        public Integrations Integrations { get; set; }
        public C1IntegrationOption C1IntegrationOptions { get; set; }

        public EmailOptions Emails { get; set; }
    }

    public class KalkanConfig
    {
        public string CertificatePath { get; set; }
        public string CertificatePass { get; set; }
    }

    public class AuthOption
    {
        public string Issuer { get; set; }
        public string Audience { get; set; }
        public string Key { get; set; }
        public int Lifetime { get; set; } = 0;
        public int LifetimeRefresh { get; set; } = 0;
    }

    public class BpmOptions
    {
        public string FinAnalysisUrl { get; set; }
    }

    public class CamundaOptions
    {
        public string Url { get; set; }
        public string BpmUrl { get; set; }

        public string StandardProcessKey { get; set; }
        public string ExpressProcessKey { get; set; }

    }

    public class EmailOptions
    {
        public string DefaultRecipient { get; set; }
        public string SmtpClientName { get; set; }
        public string SmtpClientPort { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
    }

    public class Integrations
    {
        public BaseIntegrationOptions PKB { get; set; }
        public BaseIntegrationOptions GBDFL { get; set; }
        public BaseIntegrationOptions GBDUL { get; set; }
        public BaseIntegrationOptions ZAGS { get; set; }
        public BaseIntegrationOptions GCVP { get; set; }
        public BaseIntegrationOptions ASP { get; set; }
        public BaseIntegrationOptions GKB { get; set; }
        public BaseIntegrationOptions PLDG { get; set; }
    }

    public class C1IntegrationOption
    {
        public string Login { get; set; }
        public string Password { get; set; }
        public string Url { get; set; }
        public int TimerSeconds { get; set; }
    }

    public class BaseCredentialOptions
    {
        public string Login { get; set; }
        public string Password { get; set; }
    }

    public class BaseIntegrationOptions: BaseCredentialOptions
    {
        public string Url { get; set; }
        public string UserId { get; set; }
    }
}
