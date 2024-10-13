using Microsoft.EntityFrameworkCore;
using ScapeLand.Entity;

namespace ScapeLand.Data;

public interface IOptionRepository : ICrudRepository<OptionNtt>
{

}

public class OptionRepository(AppDbContext dbC)
                                : CrudRepository<OptionNtt>(dbC),
                                 IOptionRepository
{

}
