using UnityEngine;

public class MagicEnemy : Enemy
{
    public override string AddressablesPath => _path;
    [SerializeField] private string _path;
    [SerializeField] private MagicEnemyConfig _config;
    [SerializeField] private EnemyUI _enemyUI;
    private MagicComponent _magicComponent;

    public override void Initialize()
    {
        base.Initialize();
        _runawayHpThreshold = _config.RunawayThreshold;
        _healthComponent.OnValueChanged += _enemyUI.SetHp;
        _healthComponent.Initialize(_config.HP);
        _magicComponent = GetComponent<MagicComponent>();
        _magicComponent.Initialize(_config.MagicDamage);
    }

    public override void CheckTargetDistance()
    {
        base.CheckTargetDistance();

        if (_targetDistance < _config.AttackRange && !_isAttacking && !_isPeaceful)
        {
            //_agent.updateRotation = false;
            //Vector3 targetRotation = Quaternion.LookRotation(Target.transform.position, Vector3.up).eulerAngles;
            //targetRotation = new Vector3(0, targetRotation.y, 0);
            //transform.eulerAngles = targetRotation;
            _isWalking = false;
            _isAttacking = true;
            
            //transform.DORotate(Quaternion.LookRotation(Target.transform.position).eulerAngles, 0.3f).SetEase(Ease.InOutSine);
        }
    }

    public void CompleteMagicAttack()
    {
        if (_isAttacking)
        {
            _isAttacking = false;
            _agent.updateRotation = true;
            MagicEndedEvent magicEndedEvent = new() { SenderID = ID };
            EventManager.Broadcast(magicEndedEvent);
        }
    }
}