using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TowerHealth : MonoBehaviour
{
    public static TowerHealth towerHealth;

    [SerializeField] private TextMeshProUGUI _towerHealth;

    private int _maxHealth = 100;
    //private int _damage = 2;
    private int _currentHealth;

    void Start()
    {
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
}
