public interface IProfilesRepository
{
    GameProfile Load();
    void Save(GameProfile profile);
}
