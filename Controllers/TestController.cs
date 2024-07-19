using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TestController : ControllerBase
    {
        private readonly TestService _testService;
        private readonly TestService2 _testService2;

        public TestController(TestService testService, TestService2 testService2)
        {
            _testService = testService;
            _testService2 = testService2;
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

        [HttpGet("4")]
        public Guid Get4()
        {
            var testService = AppService.ServiceProvider.GetService<TestService>();
            return testService.GetGuid();
        }


        [HttpGet("5")]
        public Guid Get5()
        {
            return _testService2.GetGuid();
        }

        [HttpGet("6")]
        public Guid Get6()
        {
            return AppService.TestService2.GetGuid();
        }


        [HttpGet("7")]
        public Guid Get7()
        {
            var testService = AppService.Services.BuildServiceProvider().GetService<TestService2>();
            return testService.GetGuid();
        }
    }
}
