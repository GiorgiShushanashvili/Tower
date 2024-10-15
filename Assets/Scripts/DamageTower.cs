using UnityEngine;

public class DamageTower : MonoBehaviour
{

    public void AttackTowerByHand()
    {
        TowerHealth.towerHealth.CurrentLife(2);
    }

    public void AttackTowerByPistol()
    {
        TowerHealth.towerHealth.CurrentLife(3);
    }

    public void AttackTowerByAutomate()
    {
        TowerHealth.towerHealth.CurrentLife(4);
    }
}
