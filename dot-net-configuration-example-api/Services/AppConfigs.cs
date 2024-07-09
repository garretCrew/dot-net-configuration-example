using dot_net_configuration_example_api.Models;
using Microsoft.Extensions.Options;

namespace dot_net_configuration_example_api.Services;

public class AppConfigs
{
    private readonly AppStaticConfigs _staticConfigs;
    private AppDynamicConfigs _dynamicConfigs;

    public AppConfigs(IOptions<AppStaticConfigs> staticConfigs, IOptionsMonitor<AppDynamicConfigs> dynamicConfigs)
    {
        _staticConfigs = staticConfigs.Value;
        _dynamicConfigs = dynamicConfigs.CurrentValue;
    }

    public IEnumerable<string> GetStaticConfig()
    {
        return new[] 
        {
            _staticConfigs.svar1,
            _staticConfigs.svar2,
            _staticConfigs.svar3
        };
    }

    public IEnumerable<string> GetDynamicConfig()
    {
        return new[]
        {
            _dynamicConfigs.dvar1,
            _dynamicConfigs.dvar2,
            _dynamicConfigs.dvar3
        };
    }
}