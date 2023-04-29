using Core.Repositories;
using Core.Services;
using Core.UnitOfWorks;
using Service.Mappings;
using Shared.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Service.Services
{
    public class GenericService<TEntity, TDto> : IGenericService<TEntity, TDto> where TEntity : class
        where TDto : class
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IGenericRepository<TEntity> _genericRepository;

        public GenericService(IUnitOfWork unitOfWork, IGenericRepository<TEntity> genericRepository)
        {
            _unitOfWork = unitOfWork;
            _genericRepository = genericRepository;
        }

        public async Task<Response<TDto>> AddAsync(TDto entity)
        {
            TEntity mapEntity = ObjectMapper.Mapper.Map<TEntity>(entity);
            await _genericRepository.AddAsync(mapEntity);
            await _unitOfWork.CommitAsync();
            TDto mapDtoEntity = ObjectMapper.Mapper.Map<TDto>(mapEntity);
            return Response<TDto>.Success(mapDtoEntity, 200);
        }

        public async Task<Response<NoDataDto>> DeleteAsync(int id)
        {
            TEntity entity = await _genericRepository.GetByIdAsync(id);
            if (entity == null)
            {
                return Response<NoDataDto>.Failed(404, "Id not found!");
            }
            _genericRepository.Delete(entity);
            _unitOfWork.Commit();
            return Response<NoDataDto>.Success(204);
        }

        public async Task<Response<IEnumerable<TDto>>> GetAllAsync()
        {
            List<TDto> entities = ObjectMapper.Mapper.Map<List<TDto>>(await _genericRepository.GetAllAsync());
            return Response<IEnumerable<TDto>>.Success(entities, 200);
        }

        public async Task<Response<TDto>> GetByIdAsync(int id)
        {
            TEntity isExistEntity = await _genericRepository.GetByIdAsync(id);
            if (isExistEntity == null)
            {
                return Response<TDto>.Failed(404, "Id not found!");
            }
            return Response<TDto>.Success(ObjectMapper.Mapper.Map<TDto>(isExistEntity), 200);
        }

        public async Task<Response<NoDataDto>> UpdateAsync(TDto entity, int id)
        {
            TEntity isExistEntity = await _genericRepository.GetByIdAsync(id);
            if (isExistEntity == null)
            {
                return Response<NoDataDto>.Failed(404, "Id not found!");
            }
            TEntity updateEntity = ObjectMapper.Mapper.Map<TEntity>(entity);
            _genericRepository.Update(updateEntity);
            _unitOfWork.Commit();
            return Response<NoDataDto>.Success(204);

        }
    }
}
