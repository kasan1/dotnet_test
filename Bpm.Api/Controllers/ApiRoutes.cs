namespace Agro.Bpm.Api.Controllers
{
    public static class ApiRoutes
    {
        public const string Base = "api";

        public static class Users
        {
            public const string Login = Base + "/users/login";
            public const string RefreshToken = Base + "/users/refresh";
            public const string Register = Base + "/users/register";
            public const string UpdateProfile = Base + "/users/profile";
            public const string ChangePassword = Base + "/users/password";
            public const string ForgotPassword = Base + "/users/password/forgot";
            public const string ResetPassword = Base + "/users/password/reset";
            public const string GetProfile = Base + "/users/profile";
            public const string AddToBranches = Base + "/users/branches";
            public const string List = Base + "/users";
        }

        public static class LoanApplications
        {
            public const string List = Base + "/loanapplications";
            public const string Navigation = Base + "/loanapplications/navigation";
            public const string Details = Base + "/loanapplications/{applicationId}";
            public const string CreateTask = Base + "/loanapplications/task";
            public const string CompleteTask = Base + "/loanapplications/task/complete";
            public const string ChangeStatus = Base + "/loanapplications/status";
            public const string ExpertiseResults = Base + "/loanapplications/expertise/{applicationTaskId}";
            public const string CommitteeResults = Base + "/loanapplications/committee/{applicationTaskId}";
        }

        public static class Comments
        {
            public const string AddComment = Base + "/comments";
            public const string List = Base + "/comments";
            public const string Remove = Base + "/comments/{commentId}";
        }

        public static class Files
        {
            public const string List = Base + "/files";
            public const string Upload = Base + "/files";            
            public const string Remove = Base + "/files/{fileId}";            
            public const string Download = Base + "/files/{fileId}";
            public const string ImportCheckingList = Base + "/files/checkinglist";
        }

        public static class Dictionary
        {
            public const string List = Base + "/dictionary";
        }

        public static class Integrations
        {
            public const string PKB = Base + "/integrations/pkb";
            public const string MonitoringReport = Base + "/integrations/monitoring/report";
        }

        public static class PdfReports
        {
            public const string MinutesOfCreditCommitteeMeeting = Base + "/pdfreports/minutesOfCreditCommitteeMeeting/{applicationId}";
        }

        public static class WordReports
        {
            public const string MinutesOfCreditCommitteeMeeting = Base + "/wordreports/minutesOfCreditCommitteeMeeting/{applicationId}";
        }

        public static class FinAnalysis
        {
            public const string Start = Base + "/finanalysis/start";
            public const string FillTemplateFile = Base + "/finanalysis/filltemplatefile";
            public const string GkbReport = Base + "/finanalysis/gkb";
        }
    }
}