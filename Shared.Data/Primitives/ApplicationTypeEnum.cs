using System;
using System.Collections.Generic;
using System.Text;

namespace Agro.Shared.Data.Primitives
{
    public enum ApplicationTypeEnum
    {
        CMAll = -1,
        CMNew = 1,
        CMInWork = 2,
        CMReview = 3,
        CMRework = 4,
        CMArchive = 5,
        CMFinished = 200,

        URAll = -2,
        URNew = 6,
        URRework = 7,
        URBoss = 21,

        EPledgeAll = 30,
        EPledge = 31,
        EPledgeRework = 31,
        EPledgeBoss = 32,
        EAct = 41,
        // credit committee
        CCNew = 8,

        Temp=0,
        PrepareCreditDossier = 50,

        CredAdminAll = 60,
        CredAdminCheck = 61,
        Completed = 100,
        Undefined=101,
    }
}