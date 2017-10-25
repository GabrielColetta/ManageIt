using ManageIt.Domain.Contracts.Patterns;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace ManageIt.Domain.Contracts.Applications
{
    public interface IApplicationBase<TEntityModel, TEntity> : IDisposable
        where TEntityModel : class, new()
        where TEntity : IEntity
    {
        void Create(TEntityModel model);
        void Update(TEntityModel model);
        void Delete(long id);
        TEntityModel GetById(long id);
        TEntityModel GetById(long id, Expression<Func<TEntity, TEntityModel>> parameters);
        IEnumerable<TEntityModel> GetPaginated(int page);
        IEnumerable<TEntityModel> GetPaginated(int page, Expression<Func<TEntity, TEntityModel>> parameters);
    }
}
