using UnityEngine;

[RequireComponent(typeof(Rigidbody), typeof(SphereCollider))]
public class Bullet : MonoBehaviour
{
    [SerializeField] private float _speed;

    private Rigidbody _rb;

    private void Awake()
    {
        Destroy(gameObject, 3f);

        _rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        var movePosition = transform.forward * _speed;
        _rb.velocity = movePosition;
    }
}
