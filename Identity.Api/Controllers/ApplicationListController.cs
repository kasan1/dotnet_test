using System;
using System.Collections.Generic;
using System.Linq;
using Agro.Shared.Api.Controllers;
using Agro.Shared.Data.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace Agro.Identity.Api.Controllers
{
    public class ApplicationListController : BaseController
    {
        private readonly TestAppListProvider _db;
        public ApplicationListController()
        {
            _db = TestAppListProvider.Instance;
        }

        [HttpPost]
        public IActionResult List(Filter filter)
        {
            var query = _db.Table.Where(x => x.Status == filter.Type || filter.Type == ApplicationType.All);

            var search = !string.IsNullOrEmpty(filter.Search) ? filter.Search.ToLower().Trim() : null;
            if (search != null)
                query = query.Where(x => x.ClientFullName.ToLower().Trim().Contains(search)
                || x.Iin.ToLower().Trim().Contains(search));

            return Ok(new
            {
                TotalItems = query.Count(),
                Items = query
                    .OrderBy(filter.Column, nameof(ApplicationListEntry.Id), filter.Direction)
                    .Skip(filter.Skip)
                    .Take(filter.PageSize)
                    .ToList()
            });
        }

        [HttpGet("statistics")]
        public IActionResult Statistics()
        {
            return Ok(new
            {
                All = _db.Table.Count(),
                InWork = _db.Table.Where(x => x.Status == ApplicationType.InWork).Count(),
                Rework = _db.Table.Where(x => x.Status == ApplicationType.Rework).Count(),
                Review = _db.Table.Where(x => x.Status == ApplicationType.Review).Count(),
                Archive = _db.Table.Where(x => x.Status == ApplicationType.Archive).Count()
            });
        }

        public class Filter
        {
            public int PageIndex { get; set; }
            public int PageSize { get; set; }
            public int Skip => PageIndex * PageSize;
            public ApplicationType Type { get; set; }
            public string Search { get; set; }
            public string Column { get; set; }
            public string Direction { get; set; }
        }
    }
    public class ApplicationListEntry
    {
        public Guid Id { get; set; }
        public string ClientFullName { get; set; }
        public string Purpose { get; set; }
        public string Number { get; set; }
        public string Iin { get; set; }
        public DateTime DateCreated { get; set; }
        public ApplicationType Status { get; set; }
    }

    public enum ApplicationType
    {
        All = 1,
        InWork = 2,
        Review = 3,
        Rework = 4,
        Archive = 5
    }

    public sealed class TestAppListProvider
    {
        private static TestAppListProvider instance = null;
        private IQueryable<ApplicationListEntry> table = null;
        private TestAppListProvider() { }

        public static TestAppListProvider Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new TestAppListProvider();
                    instance.table = GenerateTable().AsQueryable();
                }

                return instance;
            }
        }

        public IQueryable<ApplicationListEntry> Table => table;

        private static IEnumerable<ApplicationListEntry> GenerateTable()
        {
            var result = new List<ApplicationListEntry>();

            for (var i = 0; i < 30; i++)
            {
                if (i % 2 == 0)
                    result.Add(GenerateItem(ApplicationType.InWork));

                if (i % 3 == 0)
                    result.Add(GenerateItem(ApplicationType.Rework));
                result.Add(GenerateItem(ApplicationType.Review));
            }

            return result;
        }

        private static ApplicationListEntry GenerateItem(ApplicationType type)
        {
            var random = new Random();
            var client = random.Next(1, 10);

            return new ApplicationListEntry
            {
                Id = Guid.NewGuid(),
                ClientFullName = $"FIO [{client}]",
                Purpose = random.Next(1, 3) == 1 ? "Животноводство" : "Растениеводство",
                DateCreated = new DateTime(2020, random.Next(1, 13), random.Next(1, 22)),
                Iin = string.Concat(Enumerable.Repeat(client, 10)),
                Number = $"{random.Next(100, 1000)}-200-300",
                Status = type
            };
        }
    }
}