using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TestController : ControllerBase
    {
        private readonly TestService _testService;

        public TestController(TestService testService)
        {
            _testService = testService;
        }

        [HttpGet("1")]
        public Guid Get()
        {
           return _testService.GetGuid();
        }

        [HttpGet("2")]
        public Guid Get2()
        {
            var testService = AppService.Services.BuildServiceProvider().GetService<TestService>();
            return testService.GetGuid();
        }

        [HttpGet("3")]
        public Guid Get3()
        {
            var testService = AppService.Services.BuildServiceProvider()
                .GetService<IHttpContextAccessor>()
                .HttpContext
                .RequestServices
                .GetService<TestService>();
            return testService.GetGuid();
        }
    }
}
