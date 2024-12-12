using UnityEngine;
using CandyCoded.HapticFeedback;

public class DamageTower : MonoBehaviour
{

    public void AttackTowerByHand()
    {
        Vibrate();
        TowerHealth.towerHealth.CurrentLife(GlobalVariables._damageForWalkingZombie);
    }

    public void AttackTowerByStone()
    {
        Vibrate();
        TowerHealth.towerHealth.CurrentLife(GlobalVariables._damageForZombieWIthStone);
    }

    public void AttackTowerByAutomate()
    {
        Vibrate();
        TowerHealth.towerHealth.CurrentLife(4);
    }

    void Vibrate()
    {
        Handheld.Vibrate();
        HapticFeedback.HeavyFeedback();
    }
}
