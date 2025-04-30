using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class SettingsView : View
{
    [Inject] private readonly IAudioManager _audioManager;
    [SerializeField] private Slider _volumeSlider;
    [SerializeField] private Button _backBtn;

    public override void Show()
    {
        base.Show();
        _volumeSlider.value = _audioManager.GetVolume();
        _backBtn.onClick.AddListener(_viewManager.ShowLast);
        _volumeSlider.onValueChanged.AddListener(_audioManager.SetVolume);
    }

    public override void Hide()
    {
        base.Hide();
        _backBtn.onClick.RemoveAllListeners();
        _volumeSlider.onValueChanged.RemoveAllListeners();
    }
}