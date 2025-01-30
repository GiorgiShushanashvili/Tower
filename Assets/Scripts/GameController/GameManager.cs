using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using static Enums;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

   /* [SerializeField] private GameObject LevelTile;
    [SerializeField] private Transform _parent;
    [SerializeField] private Player _player;
    private PlayerParent obj;
    public Animator Obj

    {
        get => obj._controller;
        set => obj._controller = value;
    }

    public GameObject secondPistol
    {
        get => obj.secondPistol;
        set => obj.secondPistol = value;
    }


    MeshRenderer _renderer;
    MeshRenderer _renderer2;
    private Rigidbody _rb;

    float _heightDelta = 0.1f;

    List<GameObject> levels = new List<GameObject>();*/

    [SerializeField] GameObject _gameOverCanvas;
    private UpdateHandler _updateHandler;
    [SerializeField] private GameData gameData;


    //[SerializeField] public PlayerState[] _playerStates;

    //[SerializeField] LevelGenerator levelGenerator;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
    }

    private void Start()
    {
        _gameOverCanvas.SetActive(false);
        Time.timeScale = 1.0f;
    }


    private void Update()
    {
        //Debug.Log(BoostController.Instance.currentBoost);
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
       /* if (BoostController.Instance.currentBoost == 0)
        {
            obj.pLayerCondition = PLayerCondition.Standard;
            
        }
        if (BoostController.Instance.currentBoost == 2)
        {
            obj.pLayerCondition = PLayerCondition.FirstBoost;
        }
        if (BoostController.Instance.currentBoost == 4)
        {
            levelGenerator.secondPistol.SetActive(true);
            obj.pLayerCondition = PLayerCondition.SecondBoost;
        }*/
    }
}
