using UnityEngine;
using UnityEngine.UI;

public class EnemyUI : MonoBehaviour
{
    [SerializeField] private Image _fill;

    public void SetHp(int hp, int maxHp)
    {
        _fill.fillAmount = (float)hp / (float)maxHp;
    }
}