using Billing.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Billing.Domain.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity>
        where TEntity : IEntity
    {
        private readonly List<TEntity> _list = new List<TEntity>();



        public void Add(TEntity entity)
        {
            _list.Add(entity);
        }

        public IEnumerable<TEntity> All()
        {
            return _list;
        }
    }
}
