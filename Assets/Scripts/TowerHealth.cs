using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class TowerHealth : MonoBehaviour
{
    public static TowerHealth towerHealth;

    [SerializeField] private TextMeshProUGUI _towerHealth;

    private int _maxHealth;
    private int _currentHealth;
    private int _regenrate;
    private float _intervalForRegeneration;

    private bool _isRegenerating = false;

    void Start()
    {
        _intervalForRegeneration = GlobalVariables._regenerationInterval;
        _maxHealth=GlobalVariables._maxHealth;
        _regenrate = GlobalVariables._regeneration;
        if (towerHealth == null)
        {
            towerHealth = this;
        }
        RefreshLife();
    }




    public void CurrentLife(int damage)
    {
        _currentHealth -= damage;
        _towerHealth.text = _currentHealth.ToString();
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
        _towerHealth.text = _maxHealth.ToString();
    }


    private IEnumerator Heal()
    {
        _isRegenerating=true;
        while (_currentHealth < _maxHealth)
        {
            yield return new WaitForSeconds(_intervalForRegeneration);
            int healthToAdd = Mathf.Min(_regenrate, _maxHealth - _currentHealth);
            _currentHealth += healthToAdd;
            _towerHealth.text = _currentHealth.ToString();

            if (_currentHealth >= _maxHealth)
            {
                _currentHealth = _maxHealth;
                break;
            }
        }
        _isRegenerating = false;
    }
}
