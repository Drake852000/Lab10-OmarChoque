using Lab10_OmarChoque.Infrastructure;

namespace Lab10_OmarChoque.Domain.Interfaces;

public interface IResponseRepository
{
    Task<IEnumerable<Response>> GetAllAsync();
    Task<Response?> GetByIdAsync(Guid id);
    Task AddAsync(Response response);
    Task UpdateAsync(Response response);
    Task DeleteAsync(Guid id);
}