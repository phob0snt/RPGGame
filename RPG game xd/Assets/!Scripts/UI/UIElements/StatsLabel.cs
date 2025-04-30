using R3;
using UnityEngine;
using UnityEngine.UI;

public class StatsLabel : UIElement
{
    [SerializeField] private Slider _hpBar;

    public override void Show()
    {
        _subscription = EventManager.Recieve<PlayerStatsChangedEvent>().Subscribe(UpdateStats);
    }

    private void UpdateStats(PlayerStatsChangedEvent evt)
    {
        SetHp(evt.CurrentHp, evt.MaxHp);
    }

    private void SetHp(int current, int max)
    {
        _hpBar.maxValue = max;
        _hpBar.value = current;
    }
}