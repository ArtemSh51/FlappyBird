using System;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Enemy : MonoBehaviour, IKillable
{
    [SerializeField] private EnemyMover _mover;
    [SerializeField] private EnemyAnimator _animator;

    public event Action<Enemy> Destroyed;

    private void Update()
    {
        _animator.PlayFlightAnimation();

        _mover.Move();
    }

    public void Kill()
    {
        Destroyed?.Invoke(this);
    }
}
