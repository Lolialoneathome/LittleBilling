using Billing.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Billing.Domain.Repositories
{
    public interface IRepository<TEntity>
        where TEntity : IEntity
    {
        void Add(TEntity entity);

        IEnumerable<TEntity> All();
    }
}
