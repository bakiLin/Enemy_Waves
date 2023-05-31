using UnityEngine;

[RequireComponent(typeof(Rigidbody), typeof(CapsuleCollider))]
public abstract class Enemy : MonoBehaviour
{
    [SerializeField] protected float _speed;
    [SerializeField] protected float _minDistance;
    [SerializeField] protected float _attackCooldown;

    protected float _timer;
    protected float _currentDistance;

    protected Transform _player;

    protected Rigidbody _rb;

    protected Vector3 _movePosition;

    protected EnemySpawn _enemySpawn;
    
    protected void Awake()
    {
        _player = FindObjectOfType<PlayerMovement>().transform;
        _enemySpawn = FindObjectOfType<EnemySpawn>();
        _rb = GetComponent<Rigidbody>();

        _timer = _attackCooldown;
    }

    protected void FixedUpdate()
    {
        if ( _player != null ) 
        {
            _currentDistance = Vector3.Distance(transform.position, _player.position);

            Move();
            Attack();
        }
        else
        {
            _rb.velocity = Vector3.zero;
        }
    }

    protected void Move()
    {
        transform.LookAt(_player);

        if (_currentDistance > _minDistance)
        {
            _movePosition = _player.position - transform.position;
            _rb.velocity = _movePosition * _speed;
        }
        else
        {
            _rb.velocity = Vector3.zero;
        }
    }

    protected abstract void Attack();

    protected void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Bullet")
        {
            _enemySpawn.enemyCount--;

            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }
}
