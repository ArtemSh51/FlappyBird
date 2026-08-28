using System;
using UnityEngine;

public class InputReader : MonoBehaviour
{
    [SerializeField] private KeyCode _keyCodeJump = KeyCode.Space;
    [SerializeField] private KeyCode _keyCodeShoot = KeyCode.Mouse0;

    public event Action ButtonJumpPressed;
    public event Action ButtonShootPressed;

    private void Update()
    {
        if (Input.GetKeyDown(_keyCodeJump))
        {
            ButtonJumpPressed?.Invoke();
        }

        if (Input.GetKeyDown(_keyCodeShoot))
        {
            ButtonShootPressed?.Invoke();
        }
    }
}
