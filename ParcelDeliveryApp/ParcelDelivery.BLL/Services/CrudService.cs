using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using AutoMapper;
using ParcelDelivery.BLL.Dtos;
using ParcelDelivery.BLL.Interfaces;
using ParcelDelivery.DAL.Entities;
using ParcelDelivery.DAL.Interfaces;

namespace ParcelDelivery.BLL.Services
{
    public class CrudService<TEntity, TModel> : BaseService, ICrudService<TEntity, TModel>
        where TEntity : BaseEntity
        where TModel : BaseDto
    {
        protected CrudService(IUnitOfWork uow)
            : base(uow)
        {
        }

        public async Task<IEnumerable<TModel>> GetAllAsync(Expression<Func<TEntity, bool>> filter)
        {
            var entities = await _uow.Repository<TEntity>().GetAllAsync(filter);
            var dtos = Mapper.Map<IEnumerable<TEntity>, IEnumerable<TModel>>(entities);

            return dtos;
        }

        public async Task<IEnumerable<TModel>> GetAllAsync()
        {
            var entities = await _uow.Repository<TEntity>().GetAllAsync();
            var dtos = Mapper.Map<IEnumerable<TEntity>, IEnumerable<TModel>>(entities);

            return dtos;
        }

        public IEnumerable<TModel> GetAll(Expression<Func<TEntity, bool>> filter)
        {
            var entities = _uow.Repository<TEntity>().GetAll(filter);
            var dtos = Mapper.Map<IEnumerable<TEntity>, IEnumerable<TModel>>(entities);

            return dtos;
        }

        public IEnumerable<TModel> GetAll()
        {
            var entities = _uow.Repository<TEntity>().GetAll();
            var dtos = Mapper.Map<IEnumerable<TEntity>, IEnumerable<TModel>>(entities);

            return dtos;
        }
    }
}
