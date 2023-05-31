using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    [SerializeField] private GameObject _startButton;
    [SerializeField] private GameObject _menuButton;
    [SerializeField] private GameObject _statusBar;
    [SerializeField] private GameObject _joystick;

    private void Awake() => Time.timeScale = 0;

    public void StartGame()
    {
        _startButton.SetActive(false);
        _statusBar.SetActive(true); 
        _joystick.SetActive(true);

        Time.timeScale = 1;
    }

    public void Menu() => SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    public void GameOver() => _menuButton.SetActive(true);

    public void StatusBar() => _statusBar.SetActive(!_statusBar.activeSelf);
}
