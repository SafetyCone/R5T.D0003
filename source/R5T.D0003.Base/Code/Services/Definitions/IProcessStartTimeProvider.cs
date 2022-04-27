using System;
using System.Threading.Tasks;

using R5T.T0064;


namespace R5T.D0003
{
    [ServiceDefinitionMarker]
    public interface IProcessStartTimeProvider : IServiceDefinition
    {
        Task<DateTime> GetProcessStartTimeAsync();
    }
}
