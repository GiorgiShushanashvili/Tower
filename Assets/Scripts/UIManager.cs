using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
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

    private void Start()
    {
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
    }

    private void FixedUpdate()
    {
        _temporaryCoins.text = TemporaryCoins._silverCoins.ToString();
        _persistentCoins.text = TemporaryCoins._goldCoins.ToString();
        _strengthCost.text = _strengthPrice.ToString();
        _speedCost.text = _speedPrice.ToString();
    }

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


}
