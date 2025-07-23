using UnityEngine;
using UnityEngine.UI;

public class GameOverView : View
{
    [SerializeField] private Button _mainMenuBtn;

    public override void Show()
    {
        base.Show();
        _mainMenuBtn.onClick.AddListener(() =>
        {
            EventManager.Broadcast(Events.QuitEvent);
        });
    }
    
    public override void Hide()
    {
        base.Hide();
        _mainMenuBtn.onClick.RemoveAllListeners();
    }
}