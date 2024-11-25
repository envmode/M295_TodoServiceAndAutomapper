namespace M295_TodoServiceAndAutomapper.Services.Abstract
{
    public interface IGenericService<T, TDto> where T : class where TDto : class
    {
        Task<IEnumerable<TDto>> GetAllAsync();

        Task<TDto?> GetByIdAsync(long id);

        Task<TDto> CreateAsync(TDto dto);

        Task<bool> UpdateAsync(long id, TDto dto);

        Task<bool> DeleteAsync(long id);
    }
}