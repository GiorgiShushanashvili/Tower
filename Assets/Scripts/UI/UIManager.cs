using System;
using TMPro;
using UnityEditor;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [Header("Kill Bonus")]
    [SerializeField] TextMeshProUGUI _currentKillBonus;
    [SerializeField] TextMeshProUGUI _potentialKillBonus;

    private int _killBonusToIncrease = 4;
    private int _nextKillBonuss;
    private int _killBonusUpgradePrice = 4;


    [Header("Damage Resistance")]
    [SerializeField] TextMeshProUGUI _currentResistance;
    [SerializeField] TextMeshProUGUI _potentialResistance;

    private float _resistanceToIncrease = 0.005f;
    private float _nextResistance;
    private int _resistanceUpgradePrice = 4;


    [Header("Regeneration Range")]
    [SerializeField] TextMeshProUGUI _currentRangeForRegeneration;
    [SerializeField] TextMeshProUGUI _potentialRangeForRegeneration;

    private float _rangeToIncrease = 1;
    private float _nextRegenRange;
    private int _rangeUpgradePrice=4;

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
    private int _strengthPrice=4;

    [Header("Speed")]
    [SerializeField] TextMeshProUGUI _currentSpeed;
    [SerializeField] TextMeshProUGUI _currentSpeedForMainStats;
    [SerializeField] TextMeshProUGUI _potentialSpeed;

    private float _speedToIncrease=0.5f;
    private float _nextSpeed;
    private int _speedPrice = 3;


    [Header("HealthBar")]
    [SerializeField] TextMeshProUGUI _health;

    [Header("Coins")]
    [SerializeField] TextMeshProUGUI _temporaryCoins;
    [SerializeField] TextMeshProUGUI _persistentCoins;


    [Header("Upgrade Costs")]
    [SerializeField] TextMeshProUGUI _strengthCost;
    [SerializeField] TextMeshProUGUI _speedCost;
    [SerializeField] TextMeshProUGUI _intervalCost;
    [SerializeField] TextMeshProUGUI _regenrationCost;
    [SerializeField] TextMeshProUGUI _resistanceCost;
    [SerializeField] TextMeshProUGUI _killBonusUpgradeCost;

    private void Start()
    {
        _nextKillBonuss=GlobalVariables._killBonus+_killBonusToIncrease;
        _currentKillBonus.text=GlobalVariables._killBonus.ToString();
        _potentialKillBonus.text=_nextKillBonuss.ToString();

        _nextResistance=GlobalVariables._damageResistance+_resistanceToIncrease;
        _currentResistance.text=GlobalVariables._damageResistance.ToString();
        _potentialResistance.text = _nextResistance.ToString();

        _nextRegenRange=GlobalVariables._regeneration+_rangeToIncrease;
        _currentRangeForRegeneration.text=GlobalVariables._regeneration.ToString();
        _potentialRangeForRegeneration.text=_nextRegenRange.ToString();

        _nextInterval=GlobalVariables._regenerationInterval-_intervalToDecrease;
        _currentInterval.text=GlobalVariables._regenerationInterval.ToString();
        _potentialInterval.text=_nextInterval.ToString();

        _nextStrength = GlobalVariables._damageStrengthForPlayer + _strengthToIncrease;
        _currentStrength.text = GlobalVariables._damageStrengthForPlayer.ToString();
        _currentStrengthForMainStats.text = GlobalVariables._damageStrengthForPlayer.ToString();
        _potentialStrength.text = _nextStrength.ToString();

        _nextSpeed = GlobalVariables._bulletSpeedForPlayer + _speedToIncrease;
        _currentSpeed.text = GlobalVariables._bulletSpeedForPlayer.ToString();
        _currentSpeedForMainStats.text = GlobalVariables._bulletSpeedForPlayer.ToString();
        _potentialSpeed.text = _nextSpeed.ToString();

        _temporaryCoins.text= TemporaryCoins._silverCoins.ToString();
        _persistentCoins.text=TemporaryCoins._goldCoins.ToString();

        _strengthCost.text=_strengthPrice.ToString();
        _speedCost.text=_speedPrice.ToString();
        _intervalCost.text=_intervalPrice.ToString();
        _regenrationCost.text=_rangeUpgradePrice.ToString();
        _resistanceCost.text=_resistanceUpgradePrice.ToString();
        _killBonusUpgradeCost.text = _killBonusUpgradePrice.ToString();
    }

    private void FixedUpdate()
    {
        _temporaryCoins.text = TemporaryCoins._silverCoins.ToString();
        _persistentCoins.text = TemporaryCoins._goldCoins.ToString();
        _strengthCost.text = _strengthPrice.ToString();
        _speedCost.text = _speedPrice.ToString();
        _intervalCost.text = _intervalPrice.ToString();
        _regenrationCost.text= _rangeUpgradePrice.ToString();
        _resistanceCost.text= _resistanceUpgradePrice.ToString();
        _killBonusUpgradeCost.text= _killBonusUpgradePrice.ToString();
    }


    #region
    public void UpdateKillBonus()
    {
        if (_killBonusUpgradePrice < TemporaryCoins._silverCoins)
        {
            UpgradeKillBonusStats();
            TemporaryCoins._silverCoins -= _killBonusUpgradePrice;
            _killBonusUpgradePrice += 1;
        }
        _currentKillBonus.text=GlobalVariables._killBonus.ToString();
        _potentialKillBonus.text=_nextKillBonuss.ToString();
    }

    private void UpgradeKillBonusStats()
    {
        GlobalVariables._killBonus += _killBonusToIncrease;
        _nextKillBonuss += _killBonusToIncrease;
    }

    #endregion



    #region
    public void UpdateDamageResistance()
    {
        if (_resistanceUpgradePrice < TemporaryCoins._silverCoins)
        {
            UpgradeResistanceStats();
            TemporaryCoins._silverCoins -= _resistanceUpgradePrice;
            _resistanceUpgradePrice += 1;
        }
        _currentResistance.text = Math.Round(GlobalVariables._damageResistance,3).ToString();
        _potentialResistance.text = Math.Round(_nextResistance, 3).ToString();
    }

    private void UpgradeResistanceStats()
    {
        GlobalVariables._damageResistance += _resistanceToIncrease;
        _nextResistance += _resistanceToIncrease;
    }

    #endregion


    #region
    public void UpdateRegeneration()
    {
        if (_rangeUpgradePrice < TemporaryCoins._silverCoins)
        {
            UpdateRegenerationStats();
            TemporaryCoins._silverCoins -= _rangeUpgradePrice;
            _rangeUpgradePrice += 1;
        }
        _currentRangeForRegeneration.text=Math.Round(GlobalVariables._regeneration,1).ToString();
        _potentialRangeForRegeneration.text=Math.Round(_nextRegenRange,3).ToString();
    }

    private void UpdateRegenerationStats()
    {
        GlobalVariables._regeneration += _rangeToIncrease;
        _nextRegenRange += _rangeToIncrease;
    }

    #endregion


    #region
    public void UpdateStrength()
    {
        if (_strengthPrice < TemporaryCoins._silverCoins)
        {
            UpdateDamageStrength();
            TemporaryCoins._silverCoins -= _strengthPrice;
            _strengthPrice += 1;
        }
        _currentStrength.text = GlobalVariables._damageStrengthForPlayer.ToString();
        _currentStrengthForMainStats.text= GlobalVariables._damageStrengthForPlayer.ToString();
        _potentialStrength.text = _nextStrength.ToString();
    }
    private void UpdateDamageStrength()
    {
        GlobalVariables._damageStrengthForPlayer += _strengthToIncrease;
        _nextStrength += _strengthToIncrease;
    }
    #endregion


    #region
    public void UpdateSpeed()
    {
        if (_speedPrice < TemporaryCoins._silverCoins)
        {
            UpdateSpeedStats();
            TemporaryCoins._silverCoins -= _speedPrice;
            _speedPrice += 1;
        }
        _currentSpeed.text = GlobalVariables._bulletSpeedForPlayer.ToString();
        _currentSpeedForMainStats.text = GlobalVariables._bulletSpeedForPlayer.ToString();
        _potentialSpeed.text = _nextSpeed.ToString();
    }

    private void UpdateSpeedStats()
    {
        GlobalVariables._bulletSpeedForPlayer += _speedToIncrease;
        _nextSpeed += _speedToIncrease;
    }
    #endregion

    #region

    public void UpdateRegenerationInreval()
    {
        if (_intervalPrice < TemporaryCoins._silverCoins)
        {
            UpdateIntervalStats();
            TemporaryCoins._silverCoins -= _intervalPrice;
            _intervalPrice += 1;
        }
        _currentInterval.text = GlobalVariables._regenerationInterval.ToString();
        _potentialInterval.text = _nextInterval.ToString();
    }

    private void UpdateIntervalStats()
    {
        GlobalVariables._regenerationInterval -= _intervalToDecrease;
        _nextInterval -= _intervalToDecrease;
    }

    #endregion
}
