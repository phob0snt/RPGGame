using R3;
using TMPro;
using UnityEngine;

public class Scoreboard : UIElement
{
    [SerializeField] private TMP_Text _scoreText;
    private int _score = 0;

    public override void Show()
    {
        _subscription = EventManager.Recieve<EnemyKilledEvent>().Subscribe(UpdateScore);
    }

    private void UpdateScore(EnemyKilledEvent evt)
    {
        _score++;
        _scoreText.text = $"Score: {_score}";
    }
}