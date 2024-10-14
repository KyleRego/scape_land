using AutoMapper;
using ScapeLand.Data;
using ScapeLand.Entity;

namespace ScapeLand.Services;

public interface ICrudServiceBase<TDto, TNtt, TRep>
                    where TRep : ICrudData<TNtt> where TNtt : NttBase
{
    public Task Create(TDto dto);
    public Task<TDto> Get(string id);
    public Task Update(TDto dto);
    public Task Delete(string id);
}

public abstract class CrudServiceBase<TDto, TNtt, TRep>(IMapper mapper,
                                                        TRep repository)
                                        : ICrudServiceBase<TDto, TNtt, TRep>
                        where TRep : ICrudData<TNtt> where TNtt : NttBase
{
    protected readonly TRep _rep = repository;
    protected readonly IMapper _mapper = mapper;

    public Task Create(TDto dto)
    {
        var ntt = _mapper.Map<TNtt>(dto);
        return _rep.Create(ntt);
    }

    public async Task Delete(string id)
    {
        TNtt ntt = await _rep.Find(id);

        await _rep.Delete(ntt);
    }

    public async Task<TDto> Get(string id)
    {
        TNtt ntt = await _rep.Find(id);
        return _mapper.Map<TDto>(ntt);
    }

    public async Task Update(TDto dto)
    {
        TNtt ntt = _mapper.Map<TNtt>(dto);
        await _rep.Update(ntt);
    }
}
