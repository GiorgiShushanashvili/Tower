using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinBonusManager : MonoBehaviour
{
    private void Update()
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
}
