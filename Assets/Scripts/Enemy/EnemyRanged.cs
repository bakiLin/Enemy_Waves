using UnityEngine;

public class EnemyRanged : Enemy
{
    [SerializeField] private GameObject _projectile;
    
    protected override void Attack()
    {
        if (_currentDistance <= _minDistance)
        {
            if (_timer > 0)
            {
                _timer -= Time.fixedDeltaTime;
            }
            else
            {
                _timer = _attackCooldown;
                var bulletSpawnPos = transform.position + transform.forward;
                Instantiate(_projectile, bulletSpawnPos, transform.rotation);
            }
        }
    }
}
