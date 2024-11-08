using Unity.VisualScripting;
using UnityEngine;

public class TemporaryCoins : MonoBehaviour
{
    public static TemporaryCoins Instance;

    public static int _silverCoins=50;
    public static int _goldCoins;

    [Header("Silver Coin")]
    private int _walkingZombiePrizeSilver = 3;
    private int _pistolZombiePrizeSilver = 5;

    [Header("Gold Coin")]
    private int _walkingZombiePrizeGold = 2;
    private int _pistolZombiePrizeGold = 3;



    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    private void Start()
    {
        _goldCoins = PlayerPrefs.GetInt("ActualGold", _goldCoins);
    }

    public void IncreaseCoinsByWalkingZombies()
    {
        _silverCoins += _walkingZombiePrizeSilver;
        _goldCoins += _walkingZombiePrizeGold;

        SaveGoldCoins();
    }

    public void IncreaseCoinsByPistolZombies()
    {
        _silverCoins += _pistolZombiePrizeSilver;
        _goldCoins += _pistolZombiePrizeGold;

        SaveGoldCoins();
    }

    private void SaveGoldCoins()
    {
        PlayerPrefs.SetInt("ActualGold", _goldCoins);
        PlayerPrefs.Save();
    }
}
