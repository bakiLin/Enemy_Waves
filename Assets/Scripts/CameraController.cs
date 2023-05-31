using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform _player;

    private Vector3 _offset;

    private void Awake()
    {
        _offset = _player.position - transform.position;
    }

    private void LateUpdate()
    {
        if (_player != null)
        {
            transform.position = _player.position - _offset;

            if (transform.position.z <= -25f)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y, -25f);
                transform.LookAt(_player);
            }
        }
    }
}
