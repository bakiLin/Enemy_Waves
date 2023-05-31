using UnityEngine;

[RequireComponent(typeof(Rigidbody), typeof(CapsuleCollider))] 
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private FloatingJoystick _joystick;

    [SerializeField] private float _speed;

    private Rigidbody _rb;

    void Awake() 
    { 
        _rb = GetComponent<Rigidbody>();   
    }

    private void FixedUpdate() 
    {
        var movePosition = new Vector3(_joystick.Horizontal, _rb.velocity.y, _joystick.Vertical);
        _rb.velocity = movePosition * _speed;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Bullet")
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Enemy") 
        {
            Destroy(gameObject);
        }
    }
}
