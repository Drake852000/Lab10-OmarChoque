using Lab10_OmarChoque.Domain.Interfaces;
using Lab10_OmarChoque.Infrastructure;
using Lab10_OmarChoque.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Lab10_OmarChoque.Infrastructure.Repositories;

public class ResponseRepository : IResponseRepository
{
    private readonly AppDbContext _context;

    public ResponseRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Response>> GetAllAsync()
        => await _context.Responses.ToListAsync();

    public async Task<Response?> GetByIdAsync(Guid id)
        => await _context.Responses.FindAsync(id);

    public async Task AddAsync(Response response)
    {
        await _context.Responses.AddAsync(response);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Response response)
    {
        _context.Responses.Update(response);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Guid id)
    {
        var entity = await _context.Responses.FindAsync(id);
        if (entity != null)
        {
            _context.Responses.Remove(entity);
            await _context.SaveChangesAsync();
        }
    }
}