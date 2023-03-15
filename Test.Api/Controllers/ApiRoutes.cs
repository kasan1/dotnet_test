namespace Agro.Okaps.Api.Controllers
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
            public const string GetProfile = Base + "/users/profile";
            public const string ConfirmEmail = Base + "/users/email";
        }

        public static class Dictionary
        {
            public const string List = Base + "/dictionary/{code}";
            public const string ListTechTypes = Base + "/dictionary/techtypes";
            public const string ListTechProducts = Base + "/dictionary/techproducts";
            public const string ListTechModels = Base + "/dictionary/techmodels";
            public const string ListCountries = Base + "/dictionary/countries";
            public const string ListProviders = Base + "/dictionary/providers";
            public const string ListAccessories = Base + "/dictionary/accessories";
        }

        public static class Calculator
        {
            public const string Calculate = Base + "/calculator/calculate";
            public const string UpdateModelsRate = Base + "/calculator/models/rate";
        }

        public static class LoanApplication
        {
            public const string Post = Base + "/loanapplication/temp";
            public const string List = Base + "/loanapplication";
            public const string Delete = Base + "/loanapplication/{applicationId}";
            public const string Update = Base + "/loanapplication/update";
            public const string GetFile = Base + "/loanapplication/{applicationId}/file";
            public const string GetFiles = Base + "/loanapplication/files";
            public const string Sign = Base + "/loanapplication/{applicationId}/sign";
            public const string GetContracts = Base + "/loanapplication/{applicationId}/contracts";
            public const string GetAllContracts = Base + "/loanapplication/contracts";
            public const string PostDetails = Base + "/loanapplication/{applicationId}/details";
            public const string DeleteDetails = Base + "/loanapplication/{applicationId}/details";
            public const string GetDetails = Base + "/loanapplication/{applicationId}/details";
            public const string GetDetailsFile = Base + "/loanapplication/{applicationId}/details/file";
            public const string PostActivities = Base + "/loanapplication/{applicationId}/activities";
            public const string GetActivities = Base + "/loanapplication/{applicationId}/activities";
            public const string PostExtraDetails = Base + "/loanapplication/{applicationId}/details/extra";
            public const string GetExtraDetails = Base + "/loanapplication/{applicationId}/details/extra";
        }

        public static class PaymentSchedule
        {
            public const string Download = Base + "/paymentschedule/download";
        }

        public static class Files
        {
            public const string List = Base + "/files";
            public const string Upload = Base + "/files";
            public const string Remove = Base + "/files/{fileId}";
            public const string Download = Base + "/files/{fileId}";

            public const string ListUL = Base + "/files/ul/{applicationId}";
            public const string ListFL = Base + "/files/fl/{applicationId}";
        }

        public static class FinAnalysis
        {
            public const string Start = Base + "/finanalysis/start";
            public const string FillTemplateFile = Base + "/finanalysis/filltemplatefile";
            public const string GkbReport = Base + "/finanalysis/gkb";
        }

        public static class Agreement
        {
            public const string Create = Base + "/agreement";
        }

        public static class Notifications
        {
            public const string List = Base + "/notifications";
        }
    }
}