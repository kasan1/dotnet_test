using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Agro.Shared.Data.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Agro.Shared.Api.Controllers
{
    [Authorize]
    public class ProtectedTestController : BaseController
    {
        private readonly TestTableProvider _db;
        public ProtectedTestController()
        {
            _db = TestTableProvider.Instance;
        }

        [HttpGet("test1")]
        public IActionResult Test1()
        {
            Thread.Sleep(1000);
            return new JsonResult("test1");
        }

        [HttpGet("test2")]
        public IActionResult Test2()
        {
            Thread.Sleep(1000);
            return new JsonResult("test2");
        }

        [HttpGet("test3")]
        public IActionResult Test3()
        {
            Thread.Sleep(1500);
            return new JsonResult("test3");
        }

        [HttpGet("testTable")]
        public IActionResult TestTable([FromQuery] Filter filter)
        {
            try
            {
                return Ok(new
                {
                    TotalItems = _db.Table.Count(),
                    Items = _db.Table.OrderBy(filter.Column, nameof(TestRecord.Id), filter.Direction)
                    .Skip(filter.Skip)
                    .Take(filter.PageSize)
                    .ToList()
                });
            }
            catch
            {
                return Ok();
            }
        }
    }

    public class Filter
    {
        public string Column { get; set; }
        public string Direction { get; set; }
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public int Skip => PageIndex * PageSize;
    }

    public class TestRecord
    {
        public int Id { get; set; }
        public DateTime DateCreated { get; set; }
        public string Title { get; set; }
        public decimal Price { get; set; }
        public TestSubRecord SubRecord { get; set; }
        public bool IsActive { get; set; }
    }

    public class TestSubRecord
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }

    public sealed class TestTableProvider
    {
        private static TestTableProvider instance = null;
        private IQueryable<TestRecord> table = null;
        private TestTableProvider() { }

        public static TestTableProvider Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new TestTableProvider();
                    instance.table = GenerateTable().AsQueryable();
                }

                return instance;
            }
        }

        public IQueryable<TestRecord> Table => table;

        private static IEnumerable<TestRecord> GenerateTable()
        {
            var random = new Random();

            var result = new List<TestRecord>();
            for (var i = 1; i <= 100; i++)
                result.Add(new TestRecord
                {
                    Id = i,
                    IsActive = random.Next(1, 3) == 1,
                    Title = $"Title - ${Guid.NewGuid().ToString()}",
                    Price = (decimal)random.Next(1000000, 2000000),
                    DateCreated = DateTime.UtcNow.AddDays(-random.Next(1, 100)),
                    SubRecord = new TestSubRecord
                    {
                        Id = 100 + i,
                        Description = "Some description...",
                        Title = $"Title - ${Guid.NewGuid().ToString()}",
                    }
                });

            return result;
        }
    }
}