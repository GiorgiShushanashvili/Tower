using System;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class TemporaryCoins : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI _silverCoin;
    [SerializeField] TextMeshProUGUI _goldCoin;

    public static TemporaryCoins Instance;

    public static float _silverCoins=50;
    public static float _goldCoins;

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
        _goldCoins = PlayerPrefs.GetFloat("ActualGold", _goldCoins);
    }

    private void FixedUpdate()
    {
        UpdateCoinsFont();
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
        PlayerPrefs.GetFloat("ActualGold", _goldCoins);
        PlayerPrefs.Save();
    }

    private void UpdateCoinsFont()
    {
        if (_silverCoin.text.Length >= 5)
        {
            _silverCoin.fontSize = 28;
        }
        if(_goldCoin.text.Length >= 5)
        {
            _goldCoin.fontSize = 28;
        }
    }
}
