using FormulaOne.Models;

namespace FormulaOne.Repository.Interface;

public interface IAchievementRepository : IGenericRepository<Achievement>
{
    Task<Achievement?> GetDriverAchievementAsync(Guid driverId);
}