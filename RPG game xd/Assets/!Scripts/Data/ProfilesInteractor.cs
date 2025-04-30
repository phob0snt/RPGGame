using UnityEngine;

public class ProfilesInteractor : IProfilesInteractor
{
    private readonly IProfilesRepository _repository;
    public GameProfile ChosenProfile { get; private set;}

    public ProfilesInteractor(IProfilesRepository rep)
    {
        _repository = rep;
    }

    public void CreateNewGame()
    {
        ChosenProfile = new GameProfile();
        SaveGame(ChosenProfile);
    }

    public void SaveGame(GameProfile profile)
    {
        Debug.Log("INTERACTOR SAVED " + profile);
        _repository.Save(profile);
    }

    public void LoadGame()
    {
        ChosenProfile = _repository.Load();
    }
}
