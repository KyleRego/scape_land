using AutoMapper;
using ScapeLand.Data;
using ScapeLand.Dtos;
using ScapeLand.Entity;

namespace ScapeLand.Services;

public interface IPromptService
                : ICrudServiceBase<PromptDto, PromptNtt, IPromptRepository>
{
    public Task<PromptDto> InitPrompt();
}

public class PromptService(IMapper mapper,
                            IPromptRepository repository,
                            IOptionResultRepository optionRepository)
    : CrudServiceBase<PromptDto, PromptNtt, IPromptRepository>(mapper, repository),
                                                                IPromptService
{
    private readonly IOptionResultRepository _optionData = optionRepository;

    public async Task<PromptDto> InitPrompt()
    {
        PromptNtt? ntt = await _rep.FindInitialPrompt();

        if (ntt == null)
        {
            ntt = new("Welcome to Scape Land...");

            List<Tuple<string, string>> opts =
            [
                Tuple.Create("New Character", "Are you ready"),
                Tuple.Create("Wretched", "You will have no protections."),
                Tuple.Create("Tutorial", "Are you sure you want to start with the tutorial?"),
            ];

            List<OptionNtt> options = opts.Select(o =>
                new OptionNtt(ntt.Id, o.Item1, o.Item2)
            ).ToList();

            ntt.Options = options;

            await _rep.Create(ntt);
        }

        List<OptionDto> choices = ntt.Options.Select(o =>
            new OptionDto(o.Id, o.Text, o.Warning)
        ).ToList();

        return new(ntt.Id, ntt.Text, choices);
    }
}
