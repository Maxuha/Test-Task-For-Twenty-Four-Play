using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    private const int GameScene = 1;
    [SerializeField] private GameObject menu;
    [SerializeField] private GameObject gamePlay;
    [SerializeField] private Text levelText;
    private bool _isMainMenu = true;
    private GameManager _gameManager;

    public GameManager GameManager
    {
        set => _gameManager = value;
    }

    public void StartGame()
    {
        if (_isMainMenu)
            SceneManager.LoadScene(GameScene);
        else
        {
            menu.SetActive(false);
            gamePlay.gameObject.SetActive(true);
            _gameManager.ResumeGame();
        }
    }

    public void Exit()
    {
        _gameManager.PauseGame();
        Application.Quit();
    }

    public void Pause()
    {
        _gameManager.PauseGame();
        _isMainMenu = false;
        menu.SetActive(true);
        gamePlay.gameObject.SetActive(false);
    }

    public void UpdateLevelText(int level)
    {
        levelText.text = level.ToString();
    }
}