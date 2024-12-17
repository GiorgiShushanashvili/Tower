using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PermanentUpgradeManager : MonoBehaviour
{
    [SerializeField] GameData gameData;
    private UpdateHandler handler;

    [Header("Strength")]
    [SerializeField] TextMeshProUGUI _currentStrength;
    [SerializeField] TextMeshProUGUI _potentialStrength;
    [SerializeField] TextMeshProUGUI _StrengthUpgradeCost;
    private float _initialStrengthPrice = 10;

    [Header("Speed")]
    [SerializeField] TextMeshProUGUI _currentSpeed;
    [SerializeField] TextMeshProUGUI _potentialSpeed;
    [SerializeField] TextMeshProUGUI _bulletSpeedUpgradeCost;
    private float _initialBulletSpeedPrice = 15;

    [Header("Damage Resistance")]
    [SerializeField] TextMeshProUGUI _currentResistance;
    [SerializeField] TextMeshProUGUI _potentialResistance;
    [SerializeField] TextMeshProUGUI _damageResistanceUpgradeCost;
    private float _initialDamageResistancePrice = 10;

    [Header("RegenerationInterval")]
    [SerializeField] TextMeshProUGUI _currentInterval;
    [SerializeField] TextMeshProUGUI _potentialInterval;
    [SerializeField] TextMeshProUGUI _regenerationIntervalUpgradeCost;
    private float _initialRegenerationIntervalPrice = 15;

    [Header("Regeneration Range")]
    [SerializeField] TextMeshProUGUI _currentRangeForRegeneration;
    [SerializeField] TextMeshProUGUI _potentialRangeForRegeneration;
    [SerializeField] TextMeshProUGUI _regenerationUpgradeCost;
    private float _initialRegenerationPrice = 12;

    [Header("HealthBar")]
    [SerializeField] TextMeshProUGUI _currentHealth;
    [SerializeField] TextMeshProUGUI _potentialHealth;
    [SerializeField] TextMeshProUGUI _healthUpgradeCost;
    private float _initialHealthUpgradePrice = 20;

    [Header("Kill Bonus")]
    [SerializeField] TextMeshProUGUI _currentKillBonus;
    [SerializeField] TextMeshProUGUI _potentialKillBonus;
    [SerializeField] TextMeshProUGUI _killBonusUpgradeCost;
    private float _initialKillBonusUpgradePrice = 20;

    [Header("Coins")]
    [SerializeField] TextMeshProUGUI _goldCoins;

    private void Start()
    {
        handler = new UpdateHandler();
        _goldCoins.text=TemporaryCoins._goldCoins.ToString();
        SetInitialStats();
        SetInitialsPrices();
    }

    private void FixedUpdate()
    {
        _goldCoins.text = TemporaryCoins._goldCoins.ToString();
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
    }

    #region
    public void UpgradePlayerStrength()
    {
        if (_initialStrengthPrice <= TemporaryCoins._goldCoins)
        {
            TemporaryCoins._goldCoins -= _initialStrengthPrice;
            _goldCoins.text = TemporaryCoins._goldCoins.ToString();

            handler.SetUpgrade(ref DataPersistanceManager.Instance.GetLevelInfo().PlayerStrengthLvl, gameData._maxLevel,
                gameData._minDamageStrength, gameData._maxDamageStrength, ref GlobalVariables._damageStrengthForPlayer,
                ref _currentStrength, ref _potentialStrength);

            handler.SetPricesForLiveUpgrade(DataPersistanceManager.Instance.GetLevelInfo().PlayerStrengthLvl, gameData._maxLevel,
                ref _initialStrengthPrice, ref _StrengthUpgradeCost);

            DataPersistanceManager.Instance.SaveGame();
        }
    }

    public void UpgradeBulletSpeed()
    {
        if (_initialBulletSpeedPrice <= TemporaryCoins._goldCoins)
        {
            TemporaryCoins._goldCoins -= _initialBulletSpeedPrice;
            _goldCoins.text = TemporaryCoins._goldCoins.ToString();

            handler.SetUpgrade(ref DataPersistanceManager.Instance.GetLevelInfo().BulletSpeedLvl, gameData._maxLevel,
            gameData._minBulletSpeed, gameData._maxBulletSpeed, ref GlobalVariables._bulletSpeedForPlayer,
            ref _currentSpeed, ref _potentialSpeed);

            handler.SetPricesForLiveUpgrade(DataPersistanceManager.Instance.GetLevelInfo().BulletSpeedLvl, gameData._maxLevel,
                ref _initialBulletSpeedPrice, ref _bulletSpeedUpgradeCost);

            DataPersistanceManager.Instance.SaveGame();
        }
    }

    public void UpgradeHealth()
    {
        if (_initialHealthUpgradePrice <= TemporaryCoins._goldCoins)
        {
            TemporaryCoins._goldCoins -= _initialHealthUpgradePrice;
            _goldCoins.text = TemporaryCoins._goldCoins.ToString();

            handler.SetUpgrade(ref DataPersistanceManager.Instance.GetLevelInfo().MaxHealthLvl, gameData._maxLevel,
            gameData._minHealth, gameData._maxHealth, ref GlobalVariables._maxHealth,
            ref _currentHealth, ref _potentialHealth);

            handler.SetPricesForLiveUpgrade(DataPersistanceManager.Instance.GetLevelInfo().MaxHealthLvl, gameData._maxLevel,
                ref _initialHealthUpgradePrice, ref _healthUpgradeCost);

            DataPersistanceManager.Instance.SaveGame();
        }
    }

    public void UpgradeDamagdeResistance()
    {
        if (_initialDamageResistancePrice <= TemporaryCoins._goldCoins)
        {
            TemporaryCoins._goldCoins -= _initialDamageResistancePrice;
            _goldCoins.text = TemporaryCoins._goldCoins.ToString();

            handler.SetUpgrade(ref DataPersistanceManager.Instance.GetLevelInfo().DamageResistanceLvl, gameData._maxLevel,
            gameData._minDamageResistance, gameData._maxDamageResistance, ref GlobalVariables._damageResistance,
            ref _currentResistance, ref _potentialResistance);

            handler.SetPricesForLiveUpgrade(DataPersistanceManager.Instance.GetLevelInfo().DamageResistanceLvl, gameData._maxLevel,
                ref _initialDamageResistancePrice, ref _damageResistanceUpgradeCost);

            DataPersistanceManager.Instance.SaveGame();
        }
    }

    public void UpgradeRegenerationInterval()
    {
        if (_initialRegenerationIntervalPrice <= TemporaryCoins._goldCoins)
        {
            TemporaryCoins._goldCoins -= _initialRegenerationIntervalPrice;
            _goldCoins.text = TemporaryCoins._goldCoins.ToString();

            handler.SetUpgrade(ref DataPersistanceManager.Instance.GetLevelInfo().RegenerationTimeIntervalLvl, gameData._maxLevel,
            gameData._worstRegenerationTimeInterval, gameData._bestRgenerationTimeInterval, ref GlobalVariables._regenerationInterval,
            ref _currentInterval, ref _potentialInterval);

            handler.SetPricesForLiveUpgrade(DataPersistanceManager.Instance.GetLevelInfo().RegenerationTimeIntervalLvl, gameData._maxLevel,
                ref _initialRegenerationIntervalPrice, ref _regenerationIntervalUpgradeCost);

            DataPersistanceManager.Instance.SaveGame();
        }
    }

    public void UpgradeRegenartionRange()
    {
        if (_initialRegenerationPrice <= TemporaryCoins._goldCoins)
        {
            TemporaryCoins._goldCoins -= _initialRegenerationPrice;
            _goldCoins.text = TemporaryCoins._goldCoins.ToString();

            handler.SetUpgrade(ref DataPersistanceManager.Instance.GetLevelInfo().RegenerationLvl, gameData._maxLevel,
            gameData._minRegeneration, gameData._maxRegeneration, ref GlobalVariables._regeneration,
            ref _currentRangeForRegeneration, ref _potentialRangeForRegeneration);

            handler.SetPricesForLiveUpgrade(DataPersistanceManager.Instance.GetLevelInfo().RegenerationLvl, gameData._maxLevel,
                ref _initialRegenerationPrice, ref _regenerationUpgradeCost);

            DataPersistanceManager.Instance.SaveGame();
        }
    }

    public void UpgradeKillBonus()
    {
        if (_initialKillBonusUpgradePrice <= TemporaryCoins._goldCoins)
        {
            TemporaryCoins._goldCoins -= _initialKillBonusUpgradePrice;
            _goldCoins.text = TemporaryCoins._goldCoins.ToString();

            handler.SetUpgrade(ref DataPersistanceManager.Instance.GetLevelInfo().KillBonusLvl, gameData._maxLevel,
            gameData._minKillBonus, gameData._maxKillBonus, ref GlobalVariables._killBonus,
            ref _currentKillBonus, ref _potentialKillBonus);

            handler.SetPricesForLiveUpgrade(DataPersistanceManager.Instance.GetLevelInfo().KillBonusLvl, gameData._maxLevel,
                ref _initialKillBonusUpgradePrice, ref _killBonusUpgradeCost);

            DataPersistanceManager.Instance.SaveGame();
        }
    }
    #endregion
}
