using System;
using System.Collections.Generic;
using Agro.Shared.Logic.CQRS.Files.DTOs;
using static Agro.Shared.Data.Context.PolicyRules;

namespace Agro.Bpm.Logic.CQRS.FinAnalysis.Dto
{
    public class FinAnalysisResultDto
    {
        public DateTime DateOfInspection { get; set; }
        public string OverallStatus { get; set; }
        public List<FinAnalysisResultItem> Results { get; set; } = new List<FinAnalysisResultItem>();
    }

    public class FinAnalysisResultItem
    {
        public string BlockName { get; set; }
        public List<FinAnalysisSubject> Subjects { get; set; } = new List<FinAnalysisSubject>();
        public FileDto File { get; set; }
    }

    public class FinAnalysisSubject
    {
        public string Name { get; set; }
        public string StatusName { get; set; }
        public RejectStatuses? Status { get; set; }
    }
}
