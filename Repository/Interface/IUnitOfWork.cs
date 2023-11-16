namespace FormulaOne.Repository.Interface;

public interface IUnitOfWork
{
    IDriverRepository Drivers { get; }
    IAchievementRepository Achievements { get; }

    Task<bool> CompleteAsync();
}