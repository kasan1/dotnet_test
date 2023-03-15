using System;
using System.Collections.Generic;
using System.Text;

namespace Agro.Shared.Data.Primitives
{
    public enum QueueTaskType
    {
        New = 1,
        Complete = 2,
        Error = 3,
        InWork = 4
    }
}
