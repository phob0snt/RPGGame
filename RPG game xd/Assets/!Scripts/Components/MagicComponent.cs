using System;
using UnityEngine;

public class MagicComponent : EntityComponent
{
    public event Action<float> OnCooldownUpdated;
    [SerializeField] private MagicSpell _spell;
<<<<<<< Updated upstream
    [SerializeField] private Transform _castRoot;

    private event Action<MagicStartedEvent> _magicStarted;
    private event Action<MagicEndedEvent> _magicEnded;

    private void Awake()
    {
        _magicStarted = (e) => _spell.StartCast();
        _magicEnded = (e) => _spell.StopCast();
    }
    
    private void OnEnable()
    {
        EventManager.AddListener(_magicStarted);
        EventManager.AddListener(_magicEnded);
=======
    [SerializeField] private Transform _characterRoot;
    private IDisposable _magicStarted;
    private IDisposable _magicEnded;
    private float _lastCastTime;
    private int _damage;


    public void Initialize(int damage)
    {
        _damage = damage;
    }

    public void SetElement(MagicElement element)
    {
        if (_spell == null) return;
        _spell.SetElement(element);
    }

    private void OnEnable()
    {
        _magicStarted = EventManager.Recieve<MagicStartedEvent>().Subscribe((e) =>
        {
            if (e.SenderID != GetComponentInParent<Entity>().ID)
                return;
            _spell.StartCast();
        });
        _magicEnded = EventManager.Recieve<MagicEndedEvent>().Subscribe((e) =>
        {
            if (e.SenderID != GetComponentInParent<Entity>().ID)
                return;
            _spell.StopCast();
        });
    }

    private void Update()
    {
        UpdateCooldown();
    }

    private void UpdateCooldown()
    {
        _lastCastTime += Time.deltaTime;
        float cooldownRatio = _lastCastTime / _spell.Cooldown;
        OnCooldownUpdated?.Invoke(cooldownRatio > 1f ? 1f : cooldownRatio);
>>>>>>> Stashed changes
    }

    private void OnDisable()
    {
        EventManager.RemoveListener(_magicStarted);
        EventManager.RemoveListener(_magicEnded);
    }
    public void CastSpell()
    {
        _spell.Cast(_characterRoot, _damage);
        _lastCastTime = 0f;
    }
}