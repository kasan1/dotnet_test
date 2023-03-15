using Agro.Shared.Logic.Models;

namespace Agro.Shared.Logic
{
    public interface IPrintLogic
    {
        byte[] Generate(PrintInDto model);
    }
}
