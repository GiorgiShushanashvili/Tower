using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="GameDataScriptableObject",menuName = "ScriptableObjects/GameDataScriptableObject",order=2)]
public class GameData : ScriptableObject
{
    public float _minDamageStrength = 4f;
    public float _maxDamageStrength = 100;

    public float _minBulletSpeed = 3f;
    public float _maxBulletSpeed = 10f;

    public float _minHealth = 78.6f;
    public float _maxHealth = 150;

    public float _minRegeneration = 10;
    public float _maxRegeneration = 30;

    public float _worstRegenerationTimeInterval = 2f;
    public float _bestRgenerationTimeInterval = 0.5f;

    public float _minDamageResistance = 0.005f;
    public float _maxDamageResistance = 0.5f;

    public int _minKillBonus = 10;
    public int _maxKillBonus = 100;

    public int _minWaveBonus = 15;
    public int _maxWaveBonus = 120;

    public int _minLevel = 1;
    public int _maxLevel = 30;
}
