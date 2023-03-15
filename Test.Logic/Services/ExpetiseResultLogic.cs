using Agro.Shared.Data.Repos.Expertise;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Agro.Shared.Data.Primitives;
using Microsoft.EntityFrameworkCore;
using Agro.Okaps.Logic.Models;
using Agro.Shared.Data.Context.Dictionary;
using Agro.Shared.Data.Context;
using Agro.Shared.Logic.Dictionary;
using System.Linq;

namespace Agro.Okaps.Logic
{
    public class ExpetiseResultLogic : IExpetiseResultLogic
    {
        private readonly IExpertiseResultRepo _expertiseResulRepo;
        private readonly IDictionaryLogic _dictionarylogic;

        //private readonly ExpertiseResultRepo _ExpertiseResulRepo;

        public ExpetiseResultLogic(IExpertiseResultRepo expertiseResulRepo, IDictionaryLogic dictionarylogic)
        {
            _expertiseResulRepo = expertiseResulRepo;
            _dictionarylogic = dictionarylogic;
        }


        public async Task<object> AddExpertiseResult(ExpertiseResultInDto model)
        {
            var StatusId = _dictionarylogic.DictionaryRepo<DicLoanHistoryStatus>()
                .GetQueryable(x => !x.IsDeleted && x.Code.Equals(model.ExpertiseCode))
                .Select(x => x.Id)
                .FirstOrDefault();
            var juristRes = await _expertiseResulRepo.GetQueryable(x => x.ApplicationId == model.ApplicationId && x.ExpertiseId == StatusId).FirstOrDefaultAsync();
            if (juristRes == null)
            {
                var decisions = _dictionarylogic.DictionaryRepo<DicDecision>()
                .GetQueryable(x => !x.IsDeleted && x.Code.Equals(model.DecisionsCode))
                .Select(x => x.Id)
                .FirstOrDefault();

                ExpertiseResult expertiseResult = new ExpertiseResult
                {
                    UserId = model.UserId,
                    ApplicationId = model.ApplicationId,
                    ExpertiseId = _dictionarylogic.DictionaryRepo<DicLoanHistoryStatus>().GetQueryable(x => !x.IsDeleted && x.Code.Equals(model.ExpertiseCode)).Select(x => x.Id).FirstOrDefault(),
                    DecisionId = decisions,
                    Comment = model.Comment
                };
                await _expertiseResulRepo.Add(expertiseResult);
            }
            else
            {
                juristRes.UserId = model.UserId;
                juristRes.ExpertiseId = _dictionarylogic.DictionaryRepo<DicLoanHistoryStatus>()
                                        .GetQueryable(x => !x.IsDeleted && x.Code.Equals(model.ExpertiseCode))
                                        .Select(x => x.Id)
                                        .FirstOrDefault();
                juristRes.DecisionId = _dictionarylogic.DictionaryRepo<DicDecision>()
                                        .GetQueryable(x => !x.IsDeleted && x.Code.Equals(model.DecisionsCode))
                                        .Select(x => x.Id)
                                        .FirstOrDefault();
                juristRes.Comment = juristRes.Comment + "----" + model.Comment;
                await _expertiseResulRepo.Update(juristRes);
            }
            return true;
        }

        public async Task<object> GetExpertiseResults(Guid ApplicationId)
        {
            /*var StatusId = _dictionarylogic.DictionaryRepo<DicLoanHistoryStatus>()
                .GetQueryable(x => !x.IsDeleted && x.Code.Equals(model.ExpertiseCode))
                .Select(x => x.Id)
                .FirstOrDefault();*/

            //var expertiseRes = await _expertiseResulRepo.GetQueryable(x => x.ApplicationId == ApplicationId)
            //    .Select(x => new
            //    {
            //        ExpertName = x.User.FullName,
            //        code = x.DicDecision.Code,
            //        NameRu = x.DicDecision.NameRu,
            //        x.Comment,
            //        expertiseName = x.DicLoanHistoryStatus.Code,
            //        expertiseNameRu = x.DicLoanHistoryStatus.NameRu
            //    })
            //    .ToListAsync();

            //return expertiseRes;
            throw new NotImplementedException();
        }
        public bool GetExpertiseResultsJurist(Guid ApplicationId)
        {
            return _expertiseResulRepo.GetQueryable(x => x.ApplicationId == ApplicationId).Where(x => x.DicLoanHistoryStatus.Code.Equals("DueExpertise")).ToList().Count > 0;
        }

        public async Task<string> GetExpertiseResultForCamunda(Guid ApplicationId)
        {
            var expertiseRes = await _expertiseResulRepo.GetQueryable(x => x.ApplicationId == ApplicationId)
                .Select(x => new
                {
                    DecisionCode = x.DicDecision.Code,
                    expertise = x.DicLoanHistoryStatus.Code,
                })
                .ToListAsync();
            if (expertiseRes.Count == 0)
            {
                return "error";

            }

            if (expertiseRes.Any(x => x.DecisionCode != "accept"))
            {
                return "return";
            }
            return "accept";
        }
    }
}
