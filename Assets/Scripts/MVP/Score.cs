using System;
using UnityEngine;

public class Score : MonoBehaviour
{
    private int _value;

    public event Action<int> Changed;

    public void AddScore()
    {
        _value++;

        Changed?.Invoke(_value);
    }
}
