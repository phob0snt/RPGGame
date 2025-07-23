using System.Threading.Tasks;
using UnityEngine;
using Zenject;

public class AudioManager : IAudioManager, IInitializable
{
    private readonly IAssetLoader _loader;
    public AudioManager(IAssetLoader loader)
    {
        _loader = loader;
    }

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

    public async void Play(AudioType audioType)
    {
        switch (audioType)
        {
            case AudioType.WinSound:
                AudioClip clip = await _loader.LoadAssetAsync<AudioClip>(AddressablesPaths.WIN_SOUND);
                Camera.main.GetComponent<AudioSource>().PlayOneShot(clip);
                break;
            default:
                Debug.LogWarning($"Audio type {audioType} not implemented.");
                break;
        }
    }
}

public interface IAudioManager
{
    float GetVolume();
    void SetVolume(float value);
    void Play(AudioType audioType);
}

public enum AudioType
{
    WinSound
}