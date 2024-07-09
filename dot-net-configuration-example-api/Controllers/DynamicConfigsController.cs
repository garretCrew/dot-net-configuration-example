using dot_net_configuration_example_api.Services;
using Microsoft.AspNetCore.Mvc;

namespace dot_net_configuration_example_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DynamicConfigsController : ControllerBase
    {
        private readonly AppConfigs _appConfigs;

        public DynamicConfigsController(AppConfigs appConfigs)
        {
            _appConfigs = appConfigs;
        }

        [HttpGet]
        public IEnumerable<string> Get()
        {
            return _appConfigs.GetDynamicConfig();
        }
    }
}
