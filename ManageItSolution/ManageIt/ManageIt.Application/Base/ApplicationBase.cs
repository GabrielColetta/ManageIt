using ManageIt.Domain.Contracts.Patterns;
using System;

namespace ManageIt.Application.Base
{
    public abstract class ApplicationBase<TEntityModel, TEntity> : IDisposable
        where TEntityModel : IEntityModel, new()
        where TEntity : class, IEntity
    {
        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
