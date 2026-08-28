using System;
using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Bullet : MonoBehaviour
{
    [SerializeField] private float _force;
    [SerializeField] private float _lifeTime;

    private Rigidbody2D _rigidbody;

    public event Action<Bullet> Destroyed;

    private void OnEnable()
    {
        _rigidbody = GetComponent<Rigidbody2D>();

        StartCoroutine(Exist());
    }

    public void Fly(Vector2 direction)
    {
        _rigidbody.AddForce(direction * _force, ForceMode2D.Impulse);
    }

    private IEnumerator Exist()
    {
        yield return new WaitForSeconds(_lifeTime);

        Destroyed?.Invoke(this);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent(out IKillable killable))
        {   
            killable.Kill();
        }
    }
}
