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

        public async Task<TModel> GetAsync(Expression<Func<TEntity, bool>> filter)
        {
            var entity = await _uow.Repository<TEntity>().GetAsync(filter);
            var dto = Mapper.Map<TModel>(entity);

            return dto;
        }

        public void Create(TModel model)
        {
            _uow.Repository<TEntity>().Create(Mapper.Map<TEntity>(model));
            _uow.Commit();
        }

        public async Task DeleteAsync(int id)
        {
            await _uow.Repository<TEntity>().DeleteAsync(Mapper.Map<TEntity>(id));
            await _uow.Commit();
        }

        public async Task<TModel> UpdateAsync(TModel model)
        {
            var entity = await _uow.Repository<TEntity>().UpdateAsync(Mapper.Map<TEntity>(model));
            await _uow.Commit();

            return Mapper.Map<TModel>(entity);
        }
    }
}
