using System.Collections;
using UnityEngine;
using UnityEngine.Pool;

public class EnemySpawner : MonoBehaviour
{
    private const bool CanSpawn = true;
    private const bool HasCheck = true;

    [SerializeField] private Enemy _enemyPrefab;
    [SerializeField] private Score _score;

    [SerializeField] private int _defaultCountOfEnemies;
    [SerializeField] private int _maxCountOfEnemies;

    [SerializeField, Delayed] private float _minYPosition;
    [SerializeField, Delayed] private float _maxYPosition;

    [SerializeField] private float _timeSpawn;

    private ObjectPool<Enemy> _enemyPool;

    private void Awake()
    {
        _enemyPool = new ObjectPool<Enemy>
        (
            createFunc: () => Instantiate(_enemyPrefab),
            actionOnGet: (enemy) => ConfigureTrapBeforeUse(enemy),
            actionOnRelease: (enemy) => ConfigureTrapAfterUse(enemy),
            actionOnDestroy: (enemy) => Destroy(enemy.gameObject),
            collectionCheck: HasCheck,
            defaultCapacity: _defaultCountOfEnemies,
            maxSize: _maxCountOfEnemies
        );
    }

    private void Start()
    {
        StartCoroutine(SpawnEnemy());
    }

    private void OnValidate()
    {
        if (_minYPosition > _maxYPosition)
        {
            _maxYPosition = _minYPosition + 1;
        }
    }

    private void ConfigureTrapBeforeUse(Enemy enemy)
    {
        enemy.Destroyed += TakeNewEnemy;

        enemy.transform.position = new Vector3(transform.position.x, transform.position.y + Random.Range(_minYPosition, _maxYPosition));

        enemy.gameObject.SetActive(true);
    }

    private void ConfigureTrapAfterUse(Enemy enemy)
    {
        enemy.Destroyed -= TakeNewEnemy;

        enemy.gameObject.SetActive(false);

        enemy.transform.position = Vector3.zero;

        _score.AddScore();
    }

    private void TakeNewEnemy(Enemy enemy)
    {
        _enemyPool.Release(enemy);
    }

    private IEnumerator SpawnEnemy()
    {
        WaitForSeconds wait = new WaitForSeconds(_timeSpawn);

        while (CanSpawn)
        {
            yield return wait;

            _enemyPool.Get();
        }
    }
}
