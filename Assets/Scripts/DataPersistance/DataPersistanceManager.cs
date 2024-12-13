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

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
            this.fileDataHandler = new FileDataHandler(Application.persistentDataPath, fileName);

        }
    }

    private void Start()
    {
        this.fileDataHandler=new FileDataHandler(Application.persistentDataPath,fileName);
        this.dataPeristanceObjects=FindAllDataPersistantObjects();
        LoadGame();
    }


    public void NewGame()
    {
        this.playerData=new PlayerData();
    }

    public void LoadGame()
    {
        this.playerData = fileDataHandler.Load();

        if (this.playerData == null)
        {
            NewGame();
        }

        /*GlobalVariables._damageStrengthForPlayer=playerData.damageStrength;
        GlobalVariables._bulletSpeedForPlayer=playerData.bulletSpeed;
        GlobalVariables._maxHealth=playerData.TowerData.maxHealth;
        GlobalVariables._regeneration=playerData.TowerData.regeneration;
        GlobalVariables._regenerationInterval=playerData.TowerData.regenerationTimeInterval;
        GlobalVariables._damageResistance=playerData.TowerData.damageResistance;*/
        //GlobalVariables._killBonus=playerData.TowerData.bonusData.killBonus;
        //GlobalVariables._waveBonus=playerData.TowerData.bonusData.waveBonus;
    }

    public PlayerData GetLevelInfo()
    {
        return this.playerData;
    }

    public void SaveGame()
    { 
        foreach(IDataPersistance dataPersistance in dataPeristanceObjects)
        {
            dataPersistance.SaveData(ref playerData);
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
