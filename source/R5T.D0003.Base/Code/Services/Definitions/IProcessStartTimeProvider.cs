using System;
using System.Threading.Tasks;


namespace R5T.D0003
{
    public interface IProcessStartTimeProvider
    {
        Task<DateTime> GetProcessStartTimeAsync();
    }
}
