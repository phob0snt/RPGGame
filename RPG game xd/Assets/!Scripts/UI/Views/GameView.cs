public class GameView : View
{
    public void UpdateCooldown(float ratio)
    {
        var statsLabel = TryGetUIElement<StatsLabel>();
        if (statsLabel != null)
        {
            statsLabel.UpdateMagicCooldown(ratio);
        }
    }
}
