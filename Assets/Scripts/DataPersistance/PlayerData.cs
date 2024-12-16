using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData
{
    public int PlayerStrengthLvl=0;
    public int BulletSpeedLvl=0;

    public int MaxHealthLvl = 0;
    public int RegenerationLvl = 0;
    public int RegenerationTimeIntervalLvl = 0;
    public int DamageResistanceLvl = 0;

    public int WaveBonusLvl = 0;
    public int KillBonusLvl = 0;



    //public float damageStrength;
    //public float bulletSpeed;
    //public TowerData TowerData;
    
    /*public PlayerData()
    {
        this.damageStrength = 3f;    
        this.bulletSpeed = 4f;
        TowerData = new TowerData();
    }*/
}

/*[System.Serializable]
public class TowerData
{
    public float maxHealth=78.4f;
    public float healthToIncrease = 4.6f;
    public float nextHealth = 83f;
    public int healthUpgradePrice = 4;

    public float regeneration=12f;
    public float regnerationRange = 3f;
    public float nextRegeneration = 15f;
    public int regenerationUpgradePrice = 4;


    public float regenerationTimeInterval=2f;
    public float regenerationTimeIntervalRange = 0.05f;



    public float damageResistance=0.005f;
    public BonusData bonusData;

    *//*public TowerData(float maxHealth, float regeneration, float regenerationInterval, float damageResistance, BonusData bonusData)
    {
        this.maxHealth = maxHealth;
        this.regeneration = regeneration;
        this.regenerationInterval = regenerationInterval;
        this.damageResistance = damageResistance;
        this.bonusData = bonusData;
    }*//*
}

[System.Serializable]
public class BonusData
{
    public int waveBonus=15;
    public int waveBonusToIncrease = 4;
    public int nextWaveBonus = 19;
    public int waveBonusPrice = 4;

    public int killBonus=10;
    public int killBonusToIncrease=3;
    public int nextKillBonus=13;
    public int killBonusPrice = 4;


    *//*public BonusData(int waveBonus, int killBonus)
    {
        this.waveBonus = waveBonus;
        this.killBonus = killBonus;
    }*//*
}*/