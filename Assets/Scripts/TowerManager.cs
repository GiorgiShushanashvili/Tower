using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerManager : MonoBehaviour
{
    private DamageTower _damageTower;

    private void Start()
    {
        _damageTower = GetComponent<DamageTower>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Stone")
        {
            _damageTower.AttackTowerByStone();
        }
    }
}
