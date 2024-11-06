using AutoMapper;
using ScapeLand.Data;
using ScapeLand.Entity;

namespace ScapeLand.Services;

public interface ICrudServiceBase<TDto, TEntity, TRepository>
            where TRepository : ICrudData<TEntity> where TEntity : EntityBase
{
    public Task Create(TDto dto);
    public Task<TDto> Get(string id);
    public Task Update(TDto dto);
    public Task Delete(string id);
}

public abstract class CrudServiceBase<TDto, TEntity, TRepository>(
                                        IMapper mapper, TRepository repository)
                                : ICrudServiceBase<TDto, TEntity, TRepository>
             where TRepository : ICrudData<TEntity> where TEntity : EntityBase
{
    protected readonly TRepository _rep = repository;
    protected readonly IMapper _mapper = mapper;

    public Task Create(TDto dto)
    {
        var ntt = _mapper.Map<TEntity>(dto);
        return _rep.Create(ntt);
    }

    public async Task Delete(string id)
    {
        TEntity ntt = await _rep.Find(id);

        await _rep.Delete(ntt);
    }

    public async Task<TDto> Get(string id)
    {
        TEntity ntt = await _rep.Find(id);
        return _mapper.Map<TDto>(ntt);
    }

    public async Task Update(TDto dto)
    {
        TEntity ntt = _mapper.Map<TEntity>(dto);
        await _rep.Update(ntt);
    }
}
