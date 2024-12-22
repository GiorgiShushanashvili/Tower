using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinBonusManager : MonoBehaviour
{
    public static CoinBonusManager instance;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }
    private void FixedUpdate()
    {
        AddCoinsByParticularKills();
    }


    public void AddCoinsByParticularKills()
    {
        if (CriticalAreaHandler._killedZombies == 50)
        {
            TemporaryCoins._silverCoins += GlobalVariables._killBonus;
            TemporaryCoins._goldCoins += GlobalVariables._killBonus;
            CriticalAreaHandler._killedZombies = 0;
        }
    }

    public void AddCoinsByDefeatingWave()
    {
        TemporaryCoins._silverCoins += GlobalVariables._waveBonus;
        TemporaryCoins._goldCoins += GlobalVariables._waveBonus;
    }
}
