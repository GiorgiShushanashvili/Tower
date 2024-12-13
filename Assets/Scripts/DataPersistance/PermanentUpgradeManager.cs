using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PermanentUpgradeManager : MonoBehaviour
{
    [Header("Kill Bonus")]
    [SerializeField] TextMeshProUGUI _currentKillBonus;
    [SerializeField] TextMeshProUGUI _potentialKillBonus;

    /*private int _killBonusToIncrease;
    private int _nextKillBonuss;
    private int _killBonusUpgradePrice = 4;*/


    [Header("Damage Resistance")]
    [SerializeField] TextMeshProUGUI _currentResistance;
    [SerializeField] TextMeshProUGUI _potentialResistance;

    /*private float _resistanceToIncrease = 0.005f;
    private float _nextResistance;
    private int _resistanceUpgradePrice = 4;*/


    [Header("Regeneration Range")]
    [SerializeField] TextMeshProUGUI _currentRangeForRegeneration;
    [SerializeField] TextMeshProUGUI _potentialRangeForRegeneration;

    private float _rangeToIncrease = 1;
    private float _nextRegenRange;
    private int _rangeUpgradePrice = 4;

    [Header("RegenerationInterval")]
    [SerializeField] TextMeshProUGUI _currentInterval;
    [SerializeField] TextMeshProUGUI _potentialInterval;

    private float _intervalToDecrease = 0.05f;
    private float _nextInterval;
    private int _intervalPrice = 4;


    [Header("Strength")]
    [SerializeField] TextMeshProUGUI _currentStrength;
    [SerializeField] TextMeshProUGUI _currentStrengthForMainStats;
    [SerializeField] TextMeshProUGUI _potentialStrength;

    private float _strengthToIncrease = 0.5f;
    private float _nextStrength;
    private int _strengthPrice = 4;

    [Header("Speed")]
    [SerializeField] TextMeshProUGUI _currentSpeed;
    [SerializeField] TextMeshProUGUI _currentSpeedForMainStats;
    [SerializeField] TextMeshProUGUI _potentialSpeed;

    private float _speedToIncrease;
    private float _nextSpeed;
    private int _speedPrice;


    [Header("HealthBar")]
    [SerializeField] TextMeshProUGUI _health;

    [Header("Coins")]
    //[SerializeField] TextMeshProUGUI _temporaryCoins;
    [SerializeField] TextMeshProUGUI _persistentCoins;

    private void Start()
    {
        
    }
}
