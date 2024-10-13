using Microsoft.EntityFrameworkCore;
using ScapeLand.Entity;

namespace ScapeLand.Data;

public interface IPromptRepository : ICrudRepository<PromptNtt>
{
    public Task<PromptNtt?> FindInitialPrompt();
}

public class PromptRepository(AppDbContext dbC) : CrudRepository<PromptNtt>(dbC)
                                                            , IPromptRepository
{
    public async Task<PromptNtt?> FindInitialPrompt()
    {
        return await _dbC.Prompts.FirstOrDefaultAsync(_ => _.InitialPrompt == true);
    }
}
