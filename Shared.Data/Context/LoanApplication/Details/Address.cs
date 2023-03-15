using System;
using System.ComponentModel.DataAnnotations.Schema;
using Agro.Shared.Data.Entities.Base;

namespace Agro.Shared.Data.Context
{
    public class Address : BaseEntity
    {
        public string Fact { get; set; }
        public string Register { get; set; }
    }
}
