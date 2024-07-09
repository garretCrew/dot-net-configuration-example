using dot_net_configuration_example_api.Services;
using Microsoft.AspNetCore.Mvc;

namespace dot_net_configuration_example_api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class StaticConfigsController : ControllerBase
{
    private readonly AppConfigs _appConfigs;

    public StaticConfigsController(AppConfigs appConfigs)
    {
        _appConfigs = appConfigs;
    }

    [HttpGet]
    public IEnumerable<string> GetStatic()
    {
        return _appConfigs.GetStaticConfig();
    }
}