using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData
{
    public float damageStrength;
    public float bulletSpeed;
    public TowerData TowerData;
    
    public PlayerData()
    {
        this.damageStrength = 3f;    
        this.bulletSpeed = 4f;
        TowerData = new TowerData();
    }
}

[System.Serializable]
public class TowerData
{
    public float maxHealth=100f;
    public float regeneration=12f;
    public float regenerationInterval=2f;
    public float damageResistance=0.005f;
    public BonusData bonusData;

    /*public TowerData(float maxHealth, float regeneration, float regenerationInterval, float damageResistance, BonusData bonusData)
    {
        this.maxHealth = maxHealth;
        this.regeneration = regeneration;
        this.regenerationInterval = regenerationInterval;
        this.damageResistance = damageResistance;
        this.bonusData = bonusData;
    }*/
}

[System.Serializable]
public class BonusData
{
    public int waveBonus=15;
    public int killBonus=10;

    /*public BonusData(int waveBonus, int killBonus)
    {
        this.waveBonus = waveBonus;
        this.killBonus = killBonus;
    }*/
}