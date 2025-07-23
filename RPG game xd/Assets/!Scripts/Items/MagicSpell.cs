using UnityEngine;

public class MagicSpell : BaseItem, IWeapon
{
    [SerializeField] private GameObject _spellPrefab;
    [SerializeField] private ParticleSystem _mainParticle;
    [SerializeField] private ParticleSystem _subParticle;
    public float Cooldown => _cooldown;
    [SerializeField] private float _cooldown = 2f;
    [SerializeField] private Light _light;
    private MagicElement _element;

    private void Awake()
    {
        _light.range = 0;
    }

    public void SetElement(MagicElement element)
    {
        _element = element;
        var mainGradient = _mainParticle.colorOverLifetime;
        mainGradient.color = new ParticleSystem.MinMaxGradient(element.BaseColor, element.SecondColor);
        var subGradient = _subParticle.colorOverLifetime;
        subGradient.color = new ParticleSystem.MinMaxGradient(element.BaseColor, element.SecondColor);
        _light.color = element.BaseColor;
        _subParticle.GetComponent<ParticleSystemRenderer>().material.SetColor("_EmissionColor", element.BaseColor * 8f);
    }

    public void Cast(Transform root, int damage)
    {
        GameObject fireball = Instantiate(_spellPrefab, transform.position, Quaternion.identity);
        Spell spell = fireball.GetComponent<Spell>();
        spell.Initialize(damage, GetComponentInParent<IEntity>().ID, _element);
        fireball.GetComponent<Rigidbody>().linearVelocity = root.forward.normalized * 5f;
    }

    public void StartCast()
    {
        _mainParticle.Play();
        _subParticle.Play();
        _light.range = 10;
    }

    public void StopCast()
    {
        _mainParticle.Stop();
        _subParticle.Stop();
        _light.range = 0;
    }
}