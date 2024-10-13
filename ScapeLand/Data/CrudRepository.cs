using Microsoft.EntityFrameworkCore;
using ScapeLand.Entity;

namespace ScapeLand.Data;

public interface ICrudRepository<T> where T : NttBase
{
    public Task Create(T ntt);
    public Task<T> Find(string id);
    public Task Update(T ntt);
    public Task Delete(T ntt);
}

public abstract class CrudRepository<T>(AppDbContext dbC) : ICrudRepository<T>
                                                             where T : NttBase 
{
    protected readonly AppDbContext _dbC = dbC;

    public async Task<T> Find(string id)
    {
        return await _dbC.Set<T>().FirstOrDefaultAsync(e => e.Id == id)
            ?? throw new ApplicationException("Entity not found by id");
    }

    public async Task Create(T ntt)
    {
        _dbC.Add(ntt);
        await _dbC.SaveChangesAsync();
    }

    public async Task Update(T ntt)
    {
        _dbC.Entry(ntt).State = EntityState.Modified;
        await _dbC.SaveChangesAsync();
    }

    public async Task Delete(T ntt)
    {
        _dbC.Entry(ntt).State = EntityState.Deleted;
        await _dbC.SaveChangesAsync();
    }
}
