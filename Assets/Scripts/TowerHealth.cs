using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TowerHealth : MonoBehaviour
{
    public static TowerHealth towerHealth;

    [SerializeField] private TextMeshProUGUI _towerHealth;

    private float _maxHealth;
    private float _currentHealth;
    private float _regenrate;
    private float _intervalForRegeneration=1f;

    void Start()
    {
        _maxHealth=GlobalVariables._maxHealth;
        _regenrate = GlobalVariables._regeneration;
        if (towerHealth == null)
        {
            towerHealth = this;
        }
        RefreshLife();      
    }

    private void Update()
    {
        if (_currentHealth == _maxHealth)
        {
            StopCoroutine(Heal());
        }
    }

    public void CurrentLife(float damage)
    {
        _currentHealth -= damage;
        _towerHealth.text = _currentHealth.ToString();
        StartCoroutine(Heal());
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
        _currentHealth += _regenrate;
        yield return new WaitForSeconds(_intervalForRegeneration); 
    }
}
