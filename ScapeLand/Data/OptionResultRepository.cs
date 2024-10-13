using Microsoft.EntityFrameworkCore;
using ScapeLand.Entity;

namespace ScapeLand.Data;

public interface IOptionResultRepository : ICrudRepository<OptionResultNtt>
{
    public Task<OptionResultNtt> FindByOptionId(string optionId);
}

public class OptionResultRepository(AppDbContext dbC)
                                        : CrudRepository<OptionResultNtt>(dbC),
                                 IOptionResultRepository
{
    public async Task<OptionResultNtt> FindByOptionId(string optionId)
    {
        return await _dbC.Results
                        .FirstOrDefaultAsync(r => r.OptionId == optionId)
            ?? throw new ApplicationException("No result found for optionId");
    }
}
