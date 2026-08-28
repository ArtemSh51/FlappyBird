using System;
using UnityEngine;

public class Player : MonoBehaviour, IKillable
{
    [SerializeField] private PlayerMover _mover;
    [SerializeField] private InputReader _reader;
    [SerializeField] private PlayerAnimator _animator;
    [SerializeField] private GameObject _gun;

    private IPlayerShootable _shootable;

    public event Action Killed;

    private void Awake()
    {
        _shootable = _gun.GetComponent<IPlayerShootable>();
    }

    private void OnEnable()
    {
        _reader.ButtonJumpPressed += _mover.Jump;
        _reader.ButtonJumpPressed += _animator.PlayAnimation;

        _reader.ButtonShootPressed += _shootable.Shoot;
    }

    private void OnDisable()
    {
        _reader.ButtonJumpPressed -= _mover.Jump;
        _reader.ButtonJumpPressed -= _animator.PlayAnimation;

        _reader.ButtonShootPressed -= _shootable.Shoot;
    }

    private void FixedUpdate()
    {
        _mover.Move();
    }

    public void Kill()
    {
        Killed?.Invoke();
    }
}
