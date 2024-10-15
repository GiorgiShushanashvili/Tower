using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PLayerManager : MonoBehaviour
{
    public static PLayerManager Instance;

    [Header("Strength")]
    [SerializeField] TextMeshProUGUI _currentStrength;
    [SerializeField] TextMeshProUGUI _potentialStrength;

    private float _startingDamageStrength = 3f;
    private float _strengthDifference = 1f;
    private float _nextStrength;

    [Header("Speed")]
    [SerializeField] TextMeshProUGUI _currentSpeed;
    [SerializeField] TextMeshProUGUI _potentialSpeed;

    private float _startingSpeed = 4f;
    private float _speedDifference = 1f;
    private float _nextSpeed;


    //public Bullet _bullet;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
    }

    private void Start()
    {
        _nextStrength = _startingDamageStrength + _strengthDifference;
        _currentStrength.text = _startingDamageStrength.ToString();
        _potentialStrength.text = _nextStrength.ToString();

        _nextSpeed = _startingSpeed + _speedDifference;
        _currentSpeed.text = _startingSpeed.ToString();
        _potentialSpeed.text = _nextSpeed.ToString();
    }

    public void UpdateStrength()
    {
        UpdateDamageStrength();
        _currentStrength.text = _startingDamageStrength.ToString();
        _potentialStrength.text = _nextStrength.ToString();
    }
    private void UpdateDamageStrength()
    {
        _startingDamageStrength += _strengthDifference;
        _nextStrength += _strengthDifference;
    }

    public float UpdateStrengthForLive()
    {
        return _startingDamageStrength;
    }



    public void UpdateSpeed()
    {
        UpdateSpeedStats();
        _currentSpeed.text = _startingSpeed.ToString();
        _potentialSpeed.text = _nextSpeed.ToString();
    }
    private void UpdateSpeedStats()
    {
        _startingSpeed += _speedDifference;
        _nextSpeed += _speedDifference;
    }

    public float UpdateSpeedForLive()
    {
        return _startingSpeed;
    }
}
