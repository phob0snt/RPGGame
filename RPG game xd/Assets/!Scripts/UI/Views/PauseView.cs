using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class PauseView : View
{
    [Inject] private readonly Player _player;
    [SerializeField] private Button _resumeBtn;
    [SerializeField] private Button _saveAndQuitBtn;

    private void OnEnable()
    {
        _resumeBtn.onClick.AddListener(() => _player.Unpause());
        _saveAndQuitBtn.onClick.AddListener(() => EventManager.Broadcast(Events.SaveAndQuitEvent));
    }

    private void OnDisable()
    {
        _resumeBtn.onClick.RemoveAllListeners();
        _saveAndQuitBtn.onClick.RemoveAllListeners();
    }
}