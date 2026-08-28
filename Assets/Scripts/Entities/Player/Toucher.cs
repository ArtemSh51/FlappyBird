using System;
using UnityEngine;

public class Toucher : MonoBehaviour
{
    [SerializeField] private PlayButton _button;

    public event Action PlayerTouched;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Ground _))
        {
            PlayerTouched?.Invoke();
        }
    }
}
