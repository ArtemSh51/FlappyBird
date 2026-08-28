using UnityEngine;
using UnityEngine.Pool;

public class Gun : MonoBehaviour
{
    private const bool HasCheck = true;

    [SerializeField] private Bullet _bulletPrefab;
    [SerializeField] private int _defaultCountOfBullets;
    [SerializeField] private int _maxCountOfBullets;

    [SerializeField] private bool _shootRight;

    private ObjectPool<Bullet> _bulletPool;

    private void Awake()
    {
        _bulletPool = new ObjectPool<Bullet>
        (
            createFunc: () => Instantiate(_bulletPrefab),
            actionOnGet: (bullet) => SetUpBulletBeforeUse(bullet),
            actionOnRelease: (bullet) => SetUpBulletAfterUse(bullet),
            actionOnDestroy: (bullet) => Destroy(bullet.gameObject),
            collectionCheck: HasCheck,
            defaultCapacity: _defaultCountOfBullets,
            maxSize: _maxCountOfBullets
        );
    }

    public void TakeBullet()
    {
        _bulletPool.Get();
    }

    private Vector2 ChooseDirectionOfShooting()
    {
        int indexDirection = _shootRight ? 1 : -1;

        return indexDirection * transform.right;
    }

    private void SetUpBulletBeforeUse(Bullet bullet)
    {
        bullet.Destroyed += ReturnBullet;

        bullet.transform.position = transform.position;

        bullet.gameObject.SetActive(true);

        bullet.Fly(ChooseDirectionOfShooting());
    }

    private void SetUpBulletAfterUse(Bullet bullet)
    {
        bullet.gameObject.SetActive(false);

        bullet.transform.position = Vector3.zero;

        bullet.transform.rotation = Quaternion.identity;

        if (bullet.TryGetComponent(out Rigidbody2D rigidbody))
        {
            rigidbody.velocity = Vector3.zero;
            rigidbody.angularVelocity = 0;
        }

        bullet.Destroyed -= ReturnBullet;
    }

    private void ReturnBullet(Bullet bullet)
    {
        _bulletPool.Release(bullet);
    }
}
