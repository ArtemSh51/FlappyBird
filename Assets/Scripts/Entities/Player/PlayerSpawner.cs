using System;
using UnityEngine;

public class PlayerSpawner : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private PlayButton _button;

    public event Action PlayerKilled
    {
        add => _player.Killed += value;
        remove => _player.Killed -= value;
    }
}
