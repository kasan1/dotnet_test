using System;
using System.Collections.Generic;
using Agro.Bpm.Logic.CQRS.Contracts.Dto;
using Agro.Bpm.Logic.CQRS.FinAnalysis.Dto;
using Agro.Bpm.Logic.CQRS.LoanApplicaitons.DTOs.ClientDetails;
using Agro.Bpm.Logic.CQRS.RoleControls.Dto;
using Agro.Bpm.Logic.Models.Common;
using Agro.Shared.Data.Primitives;
using Agro.Shared.Logic.CQRS.Files.DTOs;

namespace Agro.Bpm.Logic.CQRS.LoanApplicaitons.DTOs
{
    public class LoanApplicationDetailsDto
    {
        public LoanApplicationCommonData Application { get; set; } = new LoanApplicationCommonData();
        public DetailsDto ClientDetails { get; set; } = new DetailsDto();
        public LoanApplicationAssets Assets { get; set; } = new LoanApplicationAssets();
        public ClientExtraDetails ClientExtraDetails { get; set; } = new ClientExtraDetails();
        public ContractsDto Contracts { get; set; } = new ContractsDto();
        public List<FileDto> Documents { get; set; } = new List<FileDto>();
        public FinAnalysisResultDto FinAnalysis { get; set; }
        public List<RoleControlsSettings> Forms { get; set; } = new List<RoleControlsSettings>();

    }

    public class LoanApplicationCommonData
    {
        public Guid LoanApplicationId { get; set; }
        public DateTime CreatedDate { get; set; }
        public string UserRole { get; set; }
        public string Status { get; set; }
        public LoanTypeEnum LoanType { get; set; }
    }

    public class LoanApplicationPersonalData
    {
        public string Fullname { get; set; }
        public string MaritalStatus { get; set; }
        public int ChildrenCount { get; set; }
        public string Iin { get; set; }
        public string Identification { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
    }

    public class LoanApplicationAssets
    {
        public TableData Land { get; set; }
        public TableData Bio { get; set; }
        public TableData Flora { get; set; }
        public TableData Tech { get; set; }
    }

    public class ClientExtraDetails
    {
        public TableData Owners { get; set; }
        public TableData Licenses { get; set; }
        public TableData VatCertificates { get; set; }
    }
}

