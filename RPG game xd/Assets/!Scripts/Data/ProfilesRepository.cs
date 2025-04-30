using System.IO;
using UnityEngine;
using Newtonsoft.Json;

public class ProfilesRepository : IProfilesRepository
{
    private readonly string _path = Path.Combine(Application.persistentDataPath, "save.json");

    public GameProfile Load()
    {
        return JsonConvert.DeserializeObject<GameProfile>(File.ReadAllText(_path));
    }

    public void Save(GameProfile profile)
    {
        var json = JsonConvert.SerializeObject(profile, Formatting.Indented);
        File.WriteAllText(_path, json);
    }
}