using Shared.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Core.Services
{
    public interface IGenericService<TEntity, TDto> where TEntity : class
      where TDto : class
    {
        Task<Response<TDto>> AddAsync(TDto entity);
        Task<Response<NoDataDto>> UpdateAsync(TDto entity, int id);
        Task<Response<NoDataDto>> DeleteAsync(int id);
        Task<Response<IEnumerable<TDto>>> GetAllAsync();
        Task<Response<TDto>> GetByIdAsync(int id);
    }
}
