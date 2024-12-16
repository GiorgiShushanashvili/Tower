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
    [SerializeField] TextMeshProUGUI _potentialStrength;

    [Header("Speed")]
    [SerializeField] TextMeshProUGUI _currentSpeed;
    [SerializeField] TextMeshProUGUI _potentialSpeed;

    [Header("Damage Resistance")]
    [SerializeField] TextMeshProUGUI _currentResistance;
    [SerializeField] TextMeshProUGUI _potentialResistance;

    [Header("RegenerationInterval")]
    [SerializeField] TextMeshProUGUI _currentInterval;
    [SerializeField] TextMeshProUGUI _potentialInterval;

    [Header("Regeneration Range")]
    [SerializeField] TextMeshProUGUI _currentRangeForRegeneration;
    [SerializeField] TextMeshProUGUI _potentialRangeForRegeneration;

    [Header("HealthBar")]
    [SerializeField] TextMeshProUGUI _currentHealth;
    [SerializeField] TextMeshProUGUI _potentialHealth;

    [Header("Kill Bonus")]
    [SerializeField] TextMeshProUGUI _currentKillBonus;
    [SerializeField] TextMeshProUGUI _potentialKillBonus;

    private void Start()
    {
        handler = new UpdateHandler();
        SetInitialStats();
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

    #region
    public void UpgradePlayerStrength()
    {
        handler.SetUpgrade(ref DataPersistanceManager.Instance.GetLevelInfo().PlayerStrengthLvl, gameData._maxLevel,
            gameData._minDamageStrength, gameData._maxDamageStrength,ref GlobalVariables._damageStrengthForPlayer,
            ref _currentStrength,ref _potentialStrength);

        //DataPersistanceManager.Instance.SaveGame();
    }

    public void UpgradeBulletSpeed()
    {
        handler.SetUpgrade(ref DataPersistanceManager.Instance.GetLevelInfo().BulletSpeedLvl, gameData._maxLevel,
            gameData._minBulletSpeed, gameData._maxBulletSpeed, ref GlobalVariables._bulletSpeedForPlayer,
            ref _currentSpeed, ref _potentialSpeed);
        //DataPersistanceManager.Instance.SaveGame();
    }

    public void UpgradeHealth()
    {
        handler.SetUpgrade(ref DataPersistanceManager.Instance.GetLevelInfo().MaxHealthLvl, gameData._maxLevel,
            gameData._minHealth, gameData._maxHealth, ref GlobalVariables._maxHealth,
            ref _currentHealth, ref _potentialHealth);
        //DataPersistanceManager.Instance.SaveGame();
    }

    public void UpgradeDamagdeResistance()
    {
        handler.SetUpgrade(ref DataPersistanceManager.Instance.GetLevelInfo().DamageResistanceLvl, gameData._maxLevel,
            gameData._minDamageResistance, gameData._maxDamageResistance, ref GlobalVariables._damageResistance,
            ref _currentResistance, ref _potentialResistance);
    }

    public void UpgradeRegenerationInterval()
    {
        handler.SetUpgrade(ref DataPersistanceManager.Instance.GetLevelInfo().RegenerationTimeIntervalLvl, gameData._maxLevel,
            gameData._worstRegenerationTimeInterval, gameData._bestRgenerationTimeInterval, ref GlobalVariables._regenerationInterval,
            ref _currentInterval, ref _potentialInterval);
    }

    public void UpgradeRegenartionRange()
    {
        handler.SetUpgrade(ref DataPersistanceManager.Instance.GetLevelInfo().RegenerationLvl, gameData._maxLevel,
            gameData._minRegeneration, gameData._maxRegeneration, ref GlobalVariables._regeneration,
            ref _currentRangeForRegeneration, ref _potentialRangeForRegeneration);
    }

    public void UpgradeKillBonus()
    {
        handler.SetUpgrade(ref DataPersistanceManager.Instance.GetLevelInfo().KillBonusLvl, gameData._maxLevel,
            gameData._minKillBonus, gameData._maxKillBonus, ref GlobalVariables._killBonus,
            ref _currentKillBonus, ref _potentialKillBonus);
    }
    #endregion
}
