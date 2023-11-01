using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Repository.Contract
{
    public interface IGenericRepository<TModel> where TModel : class
    {
        
        Task<TModel> Create(TModel model);
        IQueryable<TModel> Read(Expression<Func<TModel, bool>>? filter = null);
        Task<bool> Update(TModel model);
        Task<bool> Delete(TModel model);
    }
}
