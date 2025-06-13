using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class MenuView : View
{
    [Inject] private readonly IProfilesInteractor _interactor;
    [SerializeField] private Button _newGameBtn;
    [SerializeField] private Button _loadGameBtn;
    [SerializeField] private Button _settingsBtn;
    [SerializeField] private Button _quitBtn;

    private void OnEnable()
    {
        _newGameBtn.onClick.AddListener(() =>
        {
            _interactor.CreateNewGame();
            EventManager.Broadcast(new LoadSceneEvent());
        });
        _loadGameBtn.onClick.AddListener(() =>
        {
            _interactor.LoadGame();
            EventManager.Broadcast(new LoadSceneEvent());
        });
        _settingsBtn.onClick.AddListener(() => _viewManager.Show<SettingsView>());
        _quitBtn.onClick.AddListener(() => Application.Quit());
    }

    private void OnDisable()
    {
        _newGameBtn.onClick.RemoveAllListeners();
        _loadGameBtn.onClick.RemoveAllListeners();
        _settingsBtn.onClick.RemoveAllListeners();
        _quitBtn.onClick.RemoveAllListeners();
    }
}