using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [SerializeField] GameObject _gameOverCanvas;
    private UpdateHandler _updateHandler;
    [SerializeField] private GameData gameData;


    [SerializeField] public PlayerState[] _playerStates;
    [SerializeField] LevelGenerator levelGenerator;

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


    private void Update()
    {
        check();
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
    private void check()
    {
        if (BoostController.Instance.currentBoost < 2)
        {
            levelGenerator.secondPistol.SetActive(false);
            levelGenerator.Obj.runtimeAnimatorController = _playerStates[0].animatorController;
        }
        if (BoostController.Instance.currentBoost > 2 && BoostController.Instance.currentBoost < 4)
        {
            levelGenerator.secondPistol.SetActive(true);
            levelGenerator.Obj.runtimeAnimatorController = _playerStates[1].animatorController;
        }
        /*if(BoostController.Instance.currentBoost > 4 && BoostController.Instance.currentBoost < 6)
        {
            AnimationManager.Animation._animator = _playerStates[1].animator;
        }*/
    }
}
