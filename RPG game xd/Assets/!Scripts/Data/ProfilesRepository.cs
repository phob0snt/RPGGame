using System.IO;
using UnityEngine;
using Newtonsoft.Json;

public class ProfilesRepository : IProfilesRepository
{
    private readonly string _path = Path.Combine(Application.persistentDataPath, "save.json");

    public void Clear()
    {
        if (File.Exists(_path))
        {
            File.Delete(_path);
        }
    }

    public GameProfile Load()
    {
        GameProfile profile = null;
        try
        {
            profile = JsonConvert.DeserializeObject<GameProfile>(File.ReadAllText(_path));
        }
        catch (FileNotFoundException)
        {
            Debug.LogWarning("Save file not found. Creating new profile.");
        }
        catch (JsonException e)
        {
            Debug.LogError($"Error deserializing save file: {e.Message}");
        }
        return profile ?? new GameProfile();
    }

    public void Save(GameProfile profile)
    {
        var json = JsonConvert.SerializeObject(profile, Formatting.Indented);
        File.WriteAllText(_path, json);
    }
}