using System.Collections;
using UnityEngine;

public class GunEnemy : Gun, IEnemyShootable
{
    private const bool CanSpawn = true;

    [SerializeField] private int _minSpawnTime;
    [SerializeField] private int _maxSpawnTime;

    private float _timeDeltaBulletCreation;

    private Coroutine _coroutine;

    private void OnEnable()
    {
        _timeDeltaBulletCreation = Random.Range(_minSpawnTime, _maxSpawnTime);

        if (_coroutine == null)
        {
            _coroutine = StartCoroutine(Shoot());
        }
    }

    private void OnDisable()
    {
        if (_coroutine != null)
        {
            StopCoroutine(_coroutine);

            _coroutine = null;
        }
    }

    private void OnValidate()
    {
        if (_minSpawnTime > _maxSpawnTime)
        {
            _maxSpawnTime = _minSpawnTime + 1;
        }
    }

    public IEnumerator Shoot()
    {
        WaitForSeconds wait = new WaitForSeconds(_timeDeltaBulletCreation);

        while (CanSpawn)
        {
            TakeBullet();

            yield return wait;
        }
    }
}
