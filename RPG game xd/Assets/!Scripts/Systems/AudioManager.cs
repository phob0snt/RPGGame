using UnityEngine;
using Zenject;

public class AudioManager : IAudioManager, IInitializable
{
    private const string GEN_VOLUME = "GeneralVolume";
    public void Initialize()
    {
        float vol = PlayerPrefs.GetFloat(GEN_VOLUME, 1);
        SetVolume(vol);
    }

    public float GetVolume()
    {
        return PlayerPrefs.GetFloat(GEN_VOLUME, 1);
    }

    public void SetVolume(float value)
    {
        if (value < 0 || value > 1) return;
        AudioListener.volume = value;
        PlayerPrefs.SetFloat(GEN_VOLUME, value);
    }
}

public interface IAudioManager
{
    public float GetVolume();
    public void SetVolume(float value);
}