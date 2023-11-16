using FormulaOne.Data;
using FormulaOne.Models;
using FormulaOne.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace FormulaOne.Repository;

public class AchievementRepository : GenericRepository<Achievement>, IAchievementRepository
{
    public AchievementRepository(AppDbContext context, ILogger logger) : base(context, logger) { }

    public Task<bool> Add(Achievement entity)
    {
        throw new NotImplementedException();
    }

    public async Task<Achievement?> GetDriverAchievementAsync(Guid driverId)
    {
        try
        {
            return await _dbSet.FirstOrDefaultAsync(x => x.DriverId == driverId);
        }
        catch (Exception e)
        {
            _logger.LogError(e, "{Repo} GetDriverAchievementAsync function error", typeof(AchievementRepository));
            throw;
        }
    }

    public override async Task<IEnumerable<Achievement>> All()
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
            _logger.LogError(e, "{Repo} All function error", typeof(AchievementRepository));
            throw;
        }
    }

    public override async Task<bool> Delete(Guid id)
    {
        try
        {
            var result = await _dbSet.FirstOrDefaultAsync(x => x.Id == id);

            if (result == null) return false;

            result.status = 0;
            result.UpdatedDate = DateTime.UtcNow;
            return true;
        }
        catch (Exception e)
        {
            _logger.LogError(e, "{Repo} Delete function error", typeof(AchievementRepository));
            throw;
        }
    }

    public override async Task<bool> Update(Achievement achievement)
    {
        try
        {
            var result = await _dbSet.FirstOrDefaultAsync(x => x.Id == achievement.Id);
            if (result == null) return false;

            result.UpdatedDate = DateTime.UtcNow;
            result.FastestLap = achievement.FastestLap;
            result.PolePosition = achievement.PolePosition;
            result.RaceWins = achievement.RaceWins;
            result.WorldChampionship = achievement.WorldChampionship;
            return true;
        }
        catch (Exception e)
        {
            _logger.LogError(e, "{Repo} Update funciton error", typeof(AchievementRepository));
            throw;
        }
    }


}