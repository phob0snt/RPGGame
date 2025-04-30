public interface IProfilesInteractor
{
    public GameProfile ChosenProfile { get; }
    void CreateNewGame();
    void LoadGame();
    void SaveGame(GameProfile profile);
}
