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
    }
}
