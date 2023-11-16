using FormulaOne.Data;
using FormulaOne.Models;
using FormulaOne.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace FormulaOne.Repository;

public class DriverRepository : GenericRepository<Driver>, IDriverRepository
{
    public DriverRepository(AppDbContext context, ILogger logger) : base(context, logger) { }

    public override async Task<IEnumerable<Driver>> All()
    {
        try
        {
            return await _dbSet.Where(x => x.status == 1)
            .AsNoTracking()
            .AsSplitQuery()
            .OrderBy(x => x.AddedDate)
            .ToListAsync();
        }
        catch (Exception e)
        {
            _logger.LogError(e, "{Repo} All function error", typeof(DriverRepository));
            throw;
        }
    }

    public override async Task<bool> Delete(Guid id)
    {
        try
        {
            var result = await _dbSet.FirstOrDefaultAsync(x => x.Id == id);
            if (result == null)
            {
                return false;
            }
            result.status = 0;
            result.UpdatedDate = DateTime.UtcNow;

            return true;
        }
        catch (Exception e)
        {
            _logger.LogError(e, "{Repo} All funciton error", typeof(DriverRepository));
            throw;
        }
    }

    public override async Task<bool> Update(Driver driver)
    {
        try
        {
            var result = await _dbSet.FirstOrDefaultAsync(x => x.Id == driver.Id);
            if (result == null) return false;

            result.UpdatedDate = DateTime.UtcNow;
            result.DriverNumber = driver.DriverNumber;
            result.FirstName = driver.FirstName;
            result.LastName = driver.LastName;
            result.DateOfBirths = driver.DateOfBirths;

            return true;

        }
        catch (Exception e)
        {
            _logger.LogError(e, "{Repo} All funciton error", typeof(DriverRepository));
            throw;
        }
    }
}