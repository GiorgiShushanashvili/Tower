using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "WaveScriptableObject", menuName = "ScriptableObjects/WaveScriptableObject",order=2)]
public class Wave : ScriptableObject
{
    /*[SerializeField] Zombie[] walkerZombies;
    [SerializeField] float _timeIntervalBewteenWalkerZombies;*/

    [SerializeField]
    public ZombieParent[] _enemyPrefabs;
    public List<float> _damageStrengthForZombies;
    public List<float> _numberToSpawn;
    public float _timeIntervalBetweenZombies;
    public float _timeBeforeWave;
    public List<float> _range;


    private void Start()
    {
        /*_timeIntervalBetweenZombies = new List<float>();
        _timeBeforeWave = new float();
        _damageStrengthForZombies = new List<float>();*/
        StartMethod();
    }

    private void StartMethod()
    {
        foreach (var zombie in _enemyPrefabs)
        {
            if (zombie.type == ZombieType.Warrior)
            {
                GlobalVariables._damageForWalkingZombie = _damageStrengthForZombies[0];

            }
            else if (zombie.type == ZombieType.Shooter)
            {
                GlobalVariables._damageForWalkingZombie = _damageStrengthForZombies[1];
            }
        }
    }
}
