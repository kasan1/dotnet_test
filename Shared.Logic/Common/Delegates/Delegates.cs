using Agro.Shared.Logic.Common.Enums;
using Agro.Shared.Logic.Services.System.File;

namespace Agro.Shared.Logic.Common.Delegates
{
    public static class Delegates
    {
        public delegate IFileService FileServiceResolver(FileServiceTypeEnum fileServiceType);
    }
}
