namespace Wbd.Pillars.Services;

public interface IGameService
{
    #region Properties
    Creator Creator { get; }
    #endregion Properties

    #region Methods
    Task LoadAsync();
    Task SaveAsync();
    Task<bool> DoesSaveExist();
    Task CreateSaveSlotAsync();
    #endregion Methods
}
