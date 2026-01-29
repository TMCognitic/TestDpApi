using BStorm.Tools.CommandQuerySeparation.Queries;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ActionConstraints;
using TestDpApi.Queries;

namespace TestDpApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TestController : ControllerBase
    {
        private readonly IQueryHandler<GetPasswdQuery, string> _handler;

        public TestController(IQueryHandler<GetPasswdQuery, string> handler)
        {
            _handler = handler;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(new { Passwd = _handler.Execute(new GetPasswdQuery()) });
        }
    }
}
