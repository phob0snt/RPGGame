using UnityEngine;

public class Sword : BaseItem, IWeapon
{
<<<<<<< Updated upstream
    public void Attack()
    {
        Debug.Log("Sword Attack");
    }
}
=======
    [SerializeField] private ParticleSystem _trail;
    [SerializeField] private ParticleSystem _glow;
    [SerializeField] private bool _useEffects = false;

    public void SetElement(MagicElement element)
    {
        var trailGradient = _trail.colorOverLifetime;
        trailGradient.color = new ParticleSystem.MinMaxGradient(element.BaseColor, element.SecondColor);
        var glowGradient = _glow.colorOverLifetime;
        glowGradient.color = new ParticleSystem.MinMaxGradient(element.BaseColor, element.SecondColor);
    }

    public void PlayEffects()
    {
        if (!_useEffects) return;
        _trail.Play();
        _glow.Play();
    }
}
>>>>>>> Stashed changes
