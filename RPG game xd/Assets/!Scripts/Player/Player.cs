using System;
using R3;
using UnityEngine;
using Zenject;

public class Player : Entity
{
    [Inject] private readonly ViewManager _viewManager;
    [SerializeField] private PlayerConfig _config;
    public static Transform Transform => _self.transform;
    private static Player _self;
    private Health _health;
    private MeleeComponent _melee;
    private BlockComponent _block;
    private MagicComponent _magic;
    private bool _isPaused = false;
    private IDisposable _pauseSubscription;

    private void Awake()
    {
        _self = this;
        Initialize();
    }

    public override void Initialize()
    {
        _melee = GetComponent<MeleeComponent>();
        _melee.Initialize(_config.SwordDamage);
        _block = GetComponent<BlockComponent>();
        _magic = GetComponent<MagicComponent>();
        _magic.Initialize(_config.SwordDamage);
        _pauseSubscription = EventManager.Recieve<EscPressEvent>().Subscribe(TogglePause);
    }

    private void OnDestroy()
    {
        _pauseSubscription?.Dispose();
    }

    public void Configure(PlayerData data)
    {
        _health = GetComponent<Health>();
        _health.Initialize(data.Health);
        transform.SetPositionAndRotation(data.Transform);
    }

    private void TogglePause(EscPressEvent evt)
    {
        if (!_isPaused)
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.Confined;
            _isPaused = true;
            _viewManager.Show<PauseView>(true, false);
        }
        else
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
            _isPaused = false;
            _viewManager.ShowLast();
        }
    }

    public void Unpause()
    {
        if (_isPaused)
            TogglePause(new EscPressEvent());
    }
}
