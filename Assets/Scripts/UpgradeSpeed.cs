using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UpgradeSpeed : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI _currentSpeed;
    [SerializeField] TextMeshProUGUI _speedToIincrease;

    private int _speedDifference=2;

    private int _speed;
    private int _potentialSpeed;


    public void ButtonPresses()
    {
        AddSpeed();
        UpdatePotentialSpeed();
        _currentSpeed.text = _speed.ToString();
        _speedToIincrease.text = _potentialSpeed.ToString();
    }
    private void Start()
    {
       _potentialSpeed = _speed+_speedDifference;
    }

    private void AddSpeed()
    {
        _speed= _speed + _speedDifference;
    }
    private void UpdatePotentialSpeed()
    {
        _potentialSpeed= _potentialSpeed + _speedDifference;
    }

}
