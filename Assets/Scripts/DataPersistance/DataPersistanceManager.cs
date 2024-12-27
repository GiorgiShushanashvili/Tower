using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class DataPersistanceManager : MonoBehaviour
{
    public static DataPersistanceManager Instance { get; private set; }

    private PlayerData playerData;
    private List<IDataPersistance> dataPeristanceObjects;
    private FileDataHandler fileDataHandler;

    [SerializeField] private string fileName;
    [SerializeField] private bool useEncryption;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
            this.fileDataHandler = new FileDataHandler(Application.persistentDataPath, fileName,useEncryption);
            this.dataPeristanceObjects = FindAllDataPersistantObjects();
            LoadGame();
        }
    }

    /*private void Start()
    {
        this.fileDataHandler = new FileDataHandler(Application.persistentDataPath, fileName);
        LoadGame();
    }*/


    public void NewGame()
    {
        this.playerData=new PlayerData();
        SaveGame();
    }

    public void LoadGame()
    {
        this.playerData = fileDataHandler.Load();

        if (this.playerData == null)
        {
            NewGame();
        }
    }

    public PlayerData GetLevelInfo()
    {
        if (this.playerData == null)
        {
            NewGame();
        }
        return this.playerData;
    }

    public void SaveGame()
    {
        foreach (IDataPersistance dataPersistance in dataPeristanceObjects)
        {
            if (dataPersistance != null)
            {
                dataPersistance.SaveData(ref playerData);
            }
        }

        fileDataHandler.Save(playerData);
    }

    private void OnApplicationQuit()
    {
        //SaveGame();
    }

    private List<IDataPersistance> FindAllDataPersistantObjects()
    {
        IEnumerable<IDataPersistance> dataPersistanceObjects = FindObjectsOfType<MonoBehaviour>()
            .OfType<IDataPersistance>();
        return new List<IDataPersistance>(dataPersistanceObjects);
    }
}
