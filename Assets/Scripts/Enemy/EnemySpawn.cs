using UnityEngine;
using UnityEngine.UI;

public class EnemySpawn : MonoBehaviour
{
    [SerializeField] private Level[] _level;

    [SerializeField] private GameObject _player;

    [SerializeField] private Text _gameStatus;

    [HideInInspector] public int enemyCount;

    private ButtonManager _buttonManager;

    private int _levelNumber = 0;

    private bool _levelOn = false;

    private float _timer = 3f;

    private void Awake()
    {
        _buttonManager = FindObjectOfType<ButtonManager>();
    }

    private void Update()
    {
        if (enemyCount == 0)
        {
            if (_levelOn)
            {
                _buttonManager.StatusBar();
                _levelOn = false;
                _levelNumber++;
                _timer = 3f;
            }
            else
            {
                Startlevel();
            }
        }

        if (_levelNumber == 3 || _player == null)
        {
            _gameStatus.text = "Game Over";
            _buttonManager.GameOver();

            gameObject.SetActive(false);
        }
    }

    private void Startlevel()
    {
        if (_timer > 0)
        {
            _gameStatus.text = $"Level will start in {Mathf.Ceil(_timer)}";
            _timer -= Time.deltaTime;
        }
        else
        {
            _buttonManager.StatusBar();

            _levelOn = true;

            var level = _level[_levelNumber];
            enemyCount = level.enemyAmount;
            
            for (int i = 0; i < level.spawnPosition.Length; i++)
            {
                int num = Random.Range(0, 2);
                Instantiate(level.enemyPrefab[num], level.spawnPosition[i], Quaternion.identity);
            }
        }
    }
}
