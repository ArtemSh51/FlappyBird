using UnityEngine;

public class CameraMover : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private float _offsetX;
    [SerializeField] private float _offsetY;

    private void Update()
    {
        transform.position = new Vector3(_player.transform.position.x + _offsetX, transform.position.y, transform.position.z);
    }
}
