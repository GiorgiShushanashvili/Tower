using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "WaveScriptableObject", menuName = "ScriptableObjects/WaveScriptableObject",order=2)]
public class Wave : ScriptableObject
{

    [SerializeField]
    public GameObject[] _enemyPrefabs;
    public float[] _damageStrengthForZombies;
    public int[] _numberToSpawn;
    public float _timeIntervalBetweenZombies;
    public float _timeBeforeWave;
    public int[] _range;

    public float[] _healths;


    public void StartMethod()
    {
        GlobalVariables._damageForWalkingZombie = _damageStrengthForZombies[0];
        GlobalVariables._damageForZombieWIthStone = _damageStrengthForZombies[1];

        GlobalVariables._healthForWalkingZombie=_healths[0];
        GlobalVariables._healthForShootergZombie=_healths[1];

    }
}
