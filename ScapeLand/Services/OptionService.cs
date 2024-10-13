using AutoMapper;
using ScapeLand.Data;
using ScapeLand.Dtos;
using ScapeLand.Entity;

namespace ScapeLand.Services;

public interface IOptionService
        : ICrudServiceBase<OptionDto, OptionNtt, IOptionRepository>
{
    public Task<OptionResultNtt> GetOptionResult(string optionId);
}

public class OptionService(IMapper mapper,
                            IOptionRepository repository,
                            IOptionResultRepository resultRepository)
    : CrudServiceBase<OptionDto, OptionNtt, IOptionRepository>(mapper, repository),
                                                                IOptionService
{
    private readonly IOptionResultRepository _resultData = resultRepository;

    public async Task<OptionResultNtt> GetOptionResult(string optionId)
    {
        return await _resultData.FindByOptionId(optionId);  
    }
}
