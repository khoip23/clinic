using Clinic.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Clinic.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TestTableController : ControllerBase
    {
        //[HttpGet]
        //public IEnumerable<TestTable> Get()
        //{
        //    return await _context.TestTables.ToListAsync();
        //}
    }
}
