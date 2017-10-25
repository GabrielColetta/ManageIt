using System;

namespace ManageIt.Domain.Contracts.Applications
{
    public interface IHomeApplication : IDisposable
    {
        string Index();
    }
}
