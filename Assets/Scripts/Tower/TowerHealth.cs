using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Playables;

public class TowerHealth : MonoBehaviour
{
    public static TowerHealth towerHealth;

    [SerializeField] private TextMeshProUGUI _towerHealth;
    [SerializeField] GameData _gameData;

    private UpdateHandler _updateHandler;

    private float _maxHealth;
    private float _currentHealth;
    private float _regenrate;
    private float _intervalForRegeneration;

    private bool _isRegenerating = false;

    void Start()
    {
        _updateHandler = new UpdateHandler();
        if (towerHealth == null)
        {
            towerHealth = this;
        }

        GlobalVariables._maxHealth = _updateHandler.CalculateUpgrade(_gameData._minHealth, _gameData._maxHealth, 0, _gameData._maxLevel,
            DataPersistanceManager.Instance.GetLevelInfo().MaxHealthLvl);

        _maxHealth = GlobalVariables._maxHealth;
        _intervalForRegeneration = GlobalVariables._regenerationInterval;
         _regenrate = GlobalVariables._regeneration;
         RefreshLife();
    }


    public void CurrentLife(float damage)
    {
        _currentHealth -= (damage-damage*GlobalVariables._damageResistance);
        _towerHealth.text = Math.Round(_currentHealth, 1).ToString();
        if (Die())
        {
            RefreshLife();
            GameManager.Instance.GameOver();
        }
        if (_currentHealth < _maxHealth&&!_isRegenerating)
        {
            StartCoroutine(Heal());
        }
    }

    public bool Die()
    {
        return _currentHealth <= 0;
    }

    public void RefreshLife()
    {
        _currentHealth = _maxHealth;
        _towerHealth.text =Math.Round(_maxHealth,1).ToString();
    }

    private IEnumerator Heal()
    {
        _isRegenerating=true;
        while (_currentHealth < _maxHealth)
        {
            yield return new WaitForSeconds(_intervalForRegeneration);
            float healthToAdd = Mathf.Min(_regenrate, _maxHealth - _currentHealth);
            _currentHealth += healthToAdd;
            _towerHealth.text =Math.Round(_currentHealth,1).ToString();

            if (_currentHealth >= _maxHealth)
            {
                _currentHealth = _maxHealth;
                break;
            }
        }
        _isRegenerating = false;
    }
}
