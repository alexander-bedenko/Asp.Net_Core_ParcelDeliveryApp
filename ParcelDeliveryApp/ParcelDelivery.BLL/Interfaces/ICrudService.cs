using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using ParcelDelivery.BLL.Dtos;
using ParcelDelivery.DAL.Entities;

namespace ParcelDelivery.BLL.Interfaces
{
    public interface ICrudService<TEntity, TModel>
        where TEntity : BaseEntity
        where TModel : BaseDto
    {
        //Task CreateAsync(TModel model);
        //Task<OperationDetail> UpdateAsync(TModel model, string itemName);
        Task<IEnumerable<TModel>> GetAllAsync(Expression<Func<TEntity, bool>> filter);
        Task<IEnumerable<TModel>> GetAllAsync();
        IEnumerable<TModel> GetAll(Expression<Func<TEntity, bool>> filter);
        IEnumerable<TModel> GetAll();
        //Task<TModel> GetAsync(int id);
        //Task<OperationDetail> DeleteAsync(int id, string itemName);
    }
}