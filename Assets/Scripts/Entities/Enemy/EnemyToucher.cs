using UnityEngine;

public class EnemyToucher : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out IKillable player))
        {
            player.Kill();
        }
    }
}
