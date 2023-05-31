using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private GameObject _projectile;

    [SerializeField] private float _attackCooldown;
    [SerializeField] private float _minDistance;

    private Transform _closest;

    private GameObject _arrow;

    private float _timer;

    private void Awake()
    {
        _arrow = transform.GetChild(0).gameObject;
        _timer = _attackCooldown;
    }

    private void FixedUpdate()
    {
        FindClosest();
        Arrow();
    }

    private void FindClosest()
    {
        Enemy[] enemies = FindObjectsOfType<Enemy>();

        if (enemies.Length > 0)
        {
            var closestDist = Vector3.Distance(transform.position, enemies[0].transform.position);
            _closest = enemies[0].transform;

            foreach (var e in enemies)
            {
                var currentDistance = Vector3.Distance(transform.position, e.transform.position);
                if (currentDistance < closestDist)
                {
                    closestDist = currentDistance;
                    _closest = e.transform;
                }
            }
        }
    }

    private void Arrow()
    {
        if (_closest != null)
        {
            transform.LookAt(_closest);
            if (!_arrow.activeSelf) _arrow.SetActive(true);

            Shoot();
        }
        else
        {
            _arrow.SetActive(false);
        }
    }

    private void Shoot()
    {
        if (Vector3.Distance(transform.position, _closest.position) <= _minDistance)
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
