using R3;
using UnityEngine;
using UnityEngine.UI;

public class StatsLabel : UIElement
{
    [SerializeField] private Slider _hpBar;
    [SerializeField] private Slider _magicCooldownBar;

    public override void Show()
    {
        _subscription = EventManager.Recieve<PlayerStatsChangedEvent>().Subscribe(UpdateStats);
    }

    public void UpdateMagicCooldown(float ratio)
    {
        _magicCooldownBar.value = ratio;
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
