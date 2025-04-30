using System;
using System.Threading.Tasks;
using R3;
using UnityEngine;

[RequireComponent(typeof(Player), typeof(PlayerController))]
public class PlayerCombatController : MonoBehaviour
{
    private Player _player;
    private PlayerController _controller;
    private IDisposable _blockSubscription;
    private IDisposable _attackSubscription;
    private IDisposable _magicSubscription;

    private void Awake()
    {
        _player = GetComponent<Player>();
        _controller = GetComponent<PlayerController>();
    }

    private void OnEnable()
    {
        _blockSubscription = EventManager.Recieve<BlockPressEvent>().Subscribe(Block);
        _attackSubscription = EventManager.Recieve<SwordAttackPressEvent>().Subscribe((e) => Attack());
        _magicSubscription = EventManager.Recieve<MagicAttackPressEvent>().Subscribe((e) => Magic());
    }

    private void OnDisable()
    {
        _blockSubscription?.Dispose();
        _attackSubscription?.Dispose();
        _magicSubscription?.Dispose();
        _blockSubscription = null;
        _attackSubscription = null;
        _magicSubscription = null;
    }

    public void Block(BlockPressEvent e)
    {
        _controller.IsBlocking = e.IsBlocking;
    }

    public async void Attack()
    {
        if(_controller.IsAttacking)
            return;

        await Task.Yield();
        _controller.IsAttacking = true;
    }

    public async void Magic()
    {
        if(_controller.IsMagic)
            return;
            
        await Task.Yield();
        _controller.IsMagic = true;
    }
}