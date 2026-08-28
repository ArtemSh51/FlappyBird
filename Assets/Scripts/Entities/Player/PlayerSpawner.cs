using System;
using UnityEngine;

public class PlayerSpawner : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private PlayButton _button;

    public event Action PlayerKilled;

    private void OnEnable()
    {
        _player.Killed += Respawn;
    }

    private void OnDisable()
    {
        _player.Killed -= Respawn;
    }

    public void Respawn()
    {
        PlayerKilled?.Invoke();
    }
}
