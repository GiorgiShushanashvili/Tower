using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [SerializeField] GameObject _gameOverCanvas;
    private UpdateHandler _updateHandler;
    [SerializeField] private GameData gameData;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        _updateHandler = new UpdateHandler();
    }

    private void Start()
    {
        _gameOverCanvas.SetActive(false);
        Time.timeScale = 1.0f;
    }

    public void GameOver()
    {
        _gameOverCanvas.SetActive(true);
        Time.timeScale = 0;
    }

    public void Restart()
    {
        DataPersistanceManager.Instance.LoadGame();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void MainMenu()
    {
        DataPersistanceManager.Instance.LoadGame();
        SceneManager.LoadScene("MainMenu");
    }
}
