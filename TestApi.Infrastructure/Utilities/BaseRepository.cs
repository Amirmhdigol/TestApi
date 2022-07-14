using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestApi.Common.Domain;
using TestApi.Common.Domain.Repository;
using TestApi.Infrastructure.Persistant;

namespace TestApi.Infrastructure.Utilities;
public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : BaseEntity
{
    protected readonly TAContext _context;
    public BaseRepository(TAContext context)
    {
        _context = context;
    }
    public virtual async Task<TEntity?> GetAsync(long id)
    {
        return await _context.Set<TEntity>().FirstOrDefaultAsync(t => t.Id.Equals(id)); ;
    }
    public async Task<TEntity?> GetTracking(long id)
    {
        return await _context.Set<TEntity>().AsTracking().FirstOrDefaultAsync(t => t.Id.Equals(id));

    }
    public async Task AddAsync(TEntity entity)
    {
        await _context.Set<TEntity>().AddAsync(entity);
    }
    public async Task<int> Save()
    {
        return await _context.SaveChangesAsync();
    }
    public TEntity? Get(long id)
    {
        return _context.Set<TEntity>().FirstOrDefault(t => t.Id.Equals(id));
    }
}