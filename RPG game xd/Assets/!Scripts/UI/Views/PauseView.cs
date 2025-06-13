using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class PauseView : View
{
    [Inject] private readonly Player _player;
    [SerializeField] private Button _resumeBtn;
    [SerializeField] private Button _switchModeBtn;
    [SerializeField] private TMP_Text _switchModeText;
    [SerializeField] private Button _saveAndQuitBtn;
    private bool _isPeacefulMode = false;

    private void OnEnable()
    {
        _resumeBtn.onClick.AddListener(() => _player.Unpause());
        _saveAndQuitBtn.onClick.AddListener(() => EventManager.Broadcast(Events.SaveAndQuitEvent));
        _switchModeBtn.onClick.AddListener(ChangeGameMode);
    }

    private void ChangeGameMode()
    {
        if (!_isPeacefulMode)
            _switchModeText.text = "Mode: Peaceful";
        else
            _switchModeText.text = "Mode: Normal";

        _isPeacefulMode = !_isPeacefulMode;
        
        EventManager.Broadcast(Events.TogglePeacefulEvent);
    }

    private void OnDisable()
    {
        _resumeBtn.onClick.RemoveAllListeners();
        _saveAndQuitBtn.onClick.RemoveAllListeners();
        _switchModeBtn.onClick.RemoveAllListeners();
    }
}