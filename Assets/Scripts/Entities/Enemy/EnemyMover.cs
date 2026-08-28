using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    [SerializeField] private float _speed;

    public void Move()
    {
        transform.position += Vector3.left * _speed * Time.deltaTime;
    }
}
