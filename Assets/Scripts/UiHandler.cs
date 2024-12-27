using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UiHandler : MonoBehaviour
{
    [SerializeField] GameData gameData;
    private UpdateHandler handler;

    [Header("Strength")]
    [SerializeField] TextMeshProUGUI _currentStrength;
    [SerializeField] TextMeshProUGUI _strengthForMainPanel;
    [SerializeField] TextMeshProUGUI _potentialStrength;
    [SerializeField] TextMeshProUGUI _StrengthUpgradeCost;
    private float _initialStrengthPrice=4;

    [Header("Speed")]
    [SerializeField] TextMeshProUGUI _currentSpeed;
    [SerializeField] TextMeshProUGUI _speedForMainPanel;
    [SerializeField] TextMeshProUGUI _potentialSpeed;
    [SerializeField] TextMeshProUGUI _bulletSpeedUpgradeCost;
    private float _initialBulletSpeedPrice = 4;

    [Header("Damage Resistance")]
    [SerializeField] TextMeshProUGUI _currentResistance;
    [SerializeField] TextMeshProUGUI _potentialResistance;
    [SerializeField] TextMeshProUGUI _damageResistanceUpgradeCost;
    private float _initialDamageResistancePrice = 4;

    [Header("RegenerationInterval")]
    [SerializeField] TextMeshProUGUI _currentInterval;
    [SerializeField] TextMeshProUGUI _potentialInterval;
    [SerializeField] TextMeshProUGUI _regenerationIntervalUpgradeCost;
    private float _initialRegenerationIntervalPrice = 4;

    [Header("Regeneration Range")]
    [SerializeField] TextMeshProUGUI _currentRangeForRegeneration;
    [SerializeField] TextMeshProUGUI _potentialRangeForRegeneration;
    [SerializeField] TextMeshProUGUI _regenerationUpgradeCost;
    private float _initialRegenerationPrice = 4;

    [Header("HealthBar")]
    [SerializeField] TextMeshProUGUI _currentHealth;
    [SerializeField] TextMeshProUGUI _potentialHealth;
    [SerializeField] TextMeshProUGUI _healthUpgradeCost;
    private float _initialHealthUpgradePrice = 4;

    [Header("Kill Bonus")]
    [SerializeField] TextMeshProUGUI _currentKillBonus;
    [SerializeField] TextMeshProUGUI _potentialKillBonus;
    [SerializeField] TextMeshProUGUI _killBonusUpgradeCost;
    private float _initialKillBonusUpgradePrice = 4;

    [Header("wave Bonus")]
    [SerializeField] TextMeshProUGUI _currentWaveBonus;
    [SerializeField] TextMeshProUGUI _potentialWaveBonus;
    [SerializeField] TextMeshProUGUI _waveBonusUpgradeCost;
    private float _initialWaveBonusUpgradePrice = 4;

    [Header("Coins")]
    [SerializeField] TextMeshProUGUI _silverCoins;
    [SerializeField] TextMeshProUGUI _goldCoins;

    private void Start()
    {
        handler = new UpdateHandler();
        _goldCoins.text = TemporaryCoins._goldCoins.ToString();
        _silverCoins.text = TemporaryCoins._silverCoins.ToString();
        _speedForMainPanel.text = GlobalVariables._bulletSpeedForPlayer.ToString();
        _strengthForMainPanel.text = GlobalVariables._damageStrengthForPlayer.ToString();
        SetInitialStats();
        SetInitialsPrices();
    }

    private void FixedUpdate()
    {
        _goldCoins.text = TemporaryCoins._goldCoins.ToString();
        _silverCoins.text = TemporaryCoins._silverCoins.ToString();
        _speedForMainPanel.text=GlobalVariables._bulletSpeedForPlayer.ToString();
        _strengthForMainPanel.text= GlobalVariables._damageStrengthForPlayer.ToString();
    }

    private void SetInitialStats()
    {
        handler.SetInitialValues(DataPersistanceManager.Instance.GetLevelInfo().PlayerStrengthLvl, gameData._maxLevel,
            gameData._minDamageStrength, gameData._maxDamageStrength, ref GlobalVariables._damageStrengthForPlayer,
            ref _currentStrength, ref _potentialStrength);

        handler.SetInitialValues(DataPersistanceManager.Instance.GetLevelInfo().BulletSpeedLvl, gameData._maxLevel,
            gameData._minBulletSpeed, gameData._maxBulletSpeed, ref GlobalVariables._bulletSpeedForPlayer,
            ref _currentSpeed, ref _potentialSpeed);

        handler.SetInitialValues(DataPersistanceManager.Instance.GetLevelInfo().MaxHealthLvl, gameData._maxLevel,
            gameData._minHealth, gameData._maxHealth, ref GlobalVariables._maxHealth,
            ref _currentHealth, ref _potentialHealth);

        handler.SetInitialValues(DataPersistanceManager.Instance.GetLevelInfo().DamageResistanceLvl, gameData._maxLevel,
            gameData._minDamageResistance, gameData._maxDamageResistance, ref GlobalVariables._damageResistance,
            ref _currentResistance, ref _potentialResistance);

        handler.SetInitialValues(DataPersistanceManager.Instance.GetLevelInfo().RegenerationTimeIntervalLvl, gameData._maxLevel,
            gameData._worstRegenerationTimeInterval, gameData._bestRgenerationTimeInterval, ref GlobalVariables._regenerationInterval,
            ref _currentInterval, ref _potentialInterval);

        handler.SetInitialValues(DataPersistanceManager.Instance.GetLevelInfo().RegenerationLvl, gameData._maxLevel,
            gameData._minRegeneration, gameData._maxRegeneration, ref GlobalVariables._regeneration,
            ref _currentRangeForRegeneration, ref _potentialRangeForRegeneration);

        handler.SetInitialValues(DataPersistanceManager.Instance.GetLevelInfo().KillBonusLvl, gameData._maxLevel,
            gameData._minKillBonus, gameData._maxKillBonus, ref GlobalVariables._killBonus,
            ref _currentKillBonus, ref _potentialKillBonus);

        handler.SetInitialValues(DataPersistanceManager.Instance.GetLevelInfo().WaveBonusLvl, gameData._maxLevel,
            gameData._minWaveBonus, gameData._maxWaveBonus, ref GlobalVariables._waveBonus,
            ref _currentWaveBonus, ref _potentialWaveBonus);

    }

    private void SetInitialsPrices()
    {
        handler.SetPricesForLiveUpgrade(DataPersistanceManager.Instance.GetLevelInfo().PlayerStrengthLvl, gameData._maxLevel,
            ref _initialStrengthPrice, ref _StrengthUpgradeCost);

        handler.SetPricesForLiveUpgrade(DataPersistanceManager.Instance.GetLevelInfo().BulletSpeedLvl, gameData._maxLevel,
            ref _initialBulletSpeedPrice, ref _bulletSpeedUpgradeCost);

        handler.SetPricesForLiveUpgrade(DataPersistanceManager.Instance.GetLevelInfo().DamageResistanceLvl, gameData._maxLevel,
            ref _initialDamageResistancePrice, ref _damageResistanceUpgradeCost);

        handler.SetPricesForLiveUpgrade(DataPersistanceManager.Instance.GetLevelInfo().RegenerationTimeIntervalLvl, gameData._maxLevel,
            ref _initialRegenerationIntervalPrice, ref _regenerationIntervalUpgradeCost);

        handler.SetPricesForLiveUpgrade(DataPersistanceManager.Instance.GetLevelInfo().RegenerationLvl, gameData._maxLevel,
            ref _initialRegenerationPrice, ref _regenerationUpgradeCost);

        handler.SetPricesForLiveUpgrade(DataPersistanceManager.Instance.GetLevelInfo().MaxHealthLvl, gameData._maxLevel,
            ref _initialHealthUpgradePrice, ref _healthUpgradeCost);

        handler.SetPricesForLiveUpgrade(DataPersistanceManager.Instance.GetLevelInfo().KillBonusLvl, gameData._maxLevel,
            ref _initialKillBonusUpgradePrice, ref _killBonusUpgradeCost);

        handler.SetPricesForLiveUpgrade(DataPersistanceManager.Instance.GetLevelInfo().WaveBonusLvl, gameData._maxLevel,
            ref _initialWaveBonusUpgradePrice, ref _waveBonusUpgradeCost);
    }

    #region
    public void UpgradePlayerStrength()
    {
        if (_initialStrengthPrice <= TemporaryCoins._silverCoins)
        {
            TemporaryCoins._silverCoins -= _initialStrengthPrice;
            _silverCoins.text = TemporaryCoins._silverCoins.ToString();

            handler.SetUpgrade(ref DataPersistanceManager.Instance.GetLevelInfo().PlayerStrengthLvl, gameData._maxLevel,
                gameData._minDamageStrength, gameData._maxDamageStrength, ref GlobalVariables._damageStrengthForPlayer,
                ref _currentStrength, ref _potentialStrength);

            handler.SetPricesForLiveUpgrade(DataPersistanceManager.Instance.GetLevelInfo().PlayerStrengthLvl, gameData._maxLevel,
                ref _initialStrengthPrice, ref _StrengthUpgradeCost);
        }
    }

    public void UpgradeBulletSpeed()
    {
        if (_initialBulletSpeedPrice<=TemporaryCoins._silverCoins)
        {
            TemporaryCoins._silverCoins -= _initialBulletSpeedPrice;
            _silverCoins.text = TemporaryCoins._silverCoins.ToString();

            handler.SetUpgrade(ref DataPersistanceManager.Instance.GetLevelInfo().BulletSpeedLvl, gameData._maxLevel,
            gameData._minBulletSpeed, gameData._maxBulletSpeed, ref GlobalVariables._bulletSpeedForPlayer,
            ref _currentSpeed, ref _potentialSpeed);

            handler.SetPricesForLiveUpgrade(DataPersistanceManager.Instance.GetLevelInfo().BulletSpeedLvl, gameData._maxLevel,
                ref _initialBulletSpeedPrice, ref _bulletSpeedUpgradeCost);
        }
    }

    public void UpgradeHealth()
    {
        if (_initialHealthUpgradePrice <= TemporaryCoins._silverCoins)
        {
            TemporaryCoins._silverCoins -= _initialHealthUpgradePrice;
            _silverCoins.text = TemporaryCoins._silverCoins.ToString();

            handler.SetUpgrade(ref DataPersistanceManager.Instance.GetLevelInfo().MaxHealthLvl, gameData._maxLevel,
            gameData._minHealth, gameData._maxHealth, ref GlobalVariables._maxHealth,
            ref _currentHealth, ref _potentialHealth);

            handler.SetPricesForLiveUpgrade(DataPersistanceManager.Instance.GetLevelInfo().MaxHealthLvl, gameData._maxLevel,
                ref _initialHealthUpgradePrice, ref _healthUpgradeCost);
        }
    }

    public void UpgradeDamagdeResistance()
    {
        if (_initialDamageResistancePrice <= TemporaryCoins._silverCoins)
        {
            TemporaryCoins._silverCoins -= _initialDamageResistancePrice;
            _silverCoins.text = TemporaryCoins._silverCoins.ToString();

            handler.SetUpgrade(ref DataPersistanceManager.Instance.GetLevelInfo().DamageResistanceLvl, gameData._maxLevel,
            gameData._minDamageResistance, gameData._maxDamageResistance, ref GlobalVariables._damageResistance,
            ref _currentResistance, ref _potentialResistance);

            handler.SetPricesForLiveUpgrade(DataPersistanceManager.Instance.GetLevelInfo().DamageResistanceLvl, gameData._maxLevel,
                ref _initialDamageResistancePrice, ref _damageResistanceUpgradeCost);
        }
    }

    public void UpgradeRegenerationInterval()
    {
        if (_initialRegenerationIntervalPrice <= TemporaryCoins._silverCoins)
        {
            TemporaryCoins._silverCoins -= _initialRegenerationIntervalPrice;
            _silverCoins.text = TemporaryCoins._silverCoins.ToString();

            handler.SetUpgrade(ref DataPersistanceManager.Instance.GetLevelInfo().RegenerationTimeIntervalLvl, gameData._maxLevel,
            gameData._worstRegenerationTimeInterval, gameData._bestRgenerationTimeInterval, ref GlobalVariables._regenerationInterval,
            ref _currentInterval, ref _potentialInterval);

            handler.SetPricesForLiveUpgrade(DataPersistanceManager.Instance.GetLevelInfo().RegenerationTimeIntervalLvl, gameData._maxLevel,
                ref _initialRegenerationIntervalPrice, ref _regenerationIntervalUpgradeCost);
        }
    }

    public void UpgradeRegenartionRange()
    {
        if (_initialRegenerationPrice <= TemporaryCoins._silverCoins)
        {
            TemporaryCoins._silverCoins -= _initialRegenerationPrice;
            _silverCoins.text = TemporaryCoins._silverCoins.ToString();

            handler.SetUpgrade(ref DataPersistanceManager.Instance.GetLevelInfo().RegenerationLvl, gameData._maxLevel,
            gameData._minRegeneration, gameData._maxRegeneration, ref GlobalVariables._regeneration,
            ref _currentRangeForRegeneration, ref _potentialRangeForRegeneration);

            handler.SetPricesForLiveUpgrade(DataPersistanceManager.Instance.GetLevelInfo().RegenerationLvl, gameData._maxLevel,
                ref _initialRegenerationPrice, ref _regenerationUpgradeCost);
        }
    }

    public void UpgradeKillBonus()
    {
        if (_initialKillBonusUpgradePrice <= TemporaryCoins._silverCoins)
        {
            TemporaryCoins._silverCoins -= _initialKillBonusUpgradePrice;
            _silverCoins.text = TemporaryCoins._silverCoins.ToString();

            handler.SetUpgrade(ref DataPersistanceManager.Instance.GetLevelInfo().KillBonusLvl, gameData._maxLevel,
            gameData._minKillBonus, gameData._maxKillBonus, ref GlobalVariables._killBonus,
            ref _currentKillBonus, ref _potentialKillBonus);

            handler.SetPricesForLiveUpgrade(DataPersistanceManager.Instance.GetLevelInfo().KillBonusLvl, gameData._maxLevel,
                ref _initialKillBonusUpgradePrice, ref _killBonusUpgradeCost);
        }
    }

    public void UpgradeWaveBonus()
    {
        if (_initialWaveBonusUpgradePrice <= TemporaryCoins._silverCoins)
        {
            TemporaryCoins._silverCoins -= _initialWaveBonusUpgradePrice;
            _silverCoins.text = TemporaryCoins._silverCoins.ToString();

            handler.SetUpgrade(ref DataPersistanceManager.Instance.GetLevelInfo().WaveBonusLvl, gameData._maxLevel,
            gameData._minWaveBonus, gameData._maxWaveBonus, ref GlobalVariables._waveBonus,
            ref _currentWaveBonus, ref _potentialWaveBonus);

            handler.SetPricesForLiveUpgrade(DataPersistanceManager.Instance.GetLevelInfo().WaveBonusLvl, gameData._maxLevel,
                ref _initialWaveBonusUpgradePrice, ref _waveBonusUpgradeCost);
        }
    }
    #endregion
}
