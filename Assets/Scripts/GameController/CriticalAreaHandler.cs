using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CriticalAreaHandler : MonoBehaviour
{
    public static CriticalAreaHandler CriticalInstance;
    public List<Transform> _criticalAreaZombies;

    public bool _isMoving = false;
    public static int _killedZombies;
    public static int _killedZombiesInWave;

    private void Awake()
    {
        if (CriticalInstance == null)
        {
            CriticalInstance = this;
        }
    }

    void Start()
    {
        _criticalAreaZombies = new List<Transform>();
    }


    private void FixedUpdate()
    {
        /*if (CriticalAreaHandler.CriticalInstance._criticalAreaZombies.Count > 0)
        {
            AnimationManager.Animation._animator.SetBool("IsInTriggerZone", true);
        }
        else
        {
            AnimationManager.Animation._animator.SetBool("IsInTriggerZone", false);
        }*/
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Zombie")||other.CompareTag("ShooterZombie"))
        {
            
            if (_criticalAreaZombies.Count == 0)
            {
                _isMoving = true; }

            _criticalAreaZombies.Add(other.transform);
        }
    }

    public void RemoveZombie()
    {
        _killedZombies++;
        _killedZombiesInWave++;
        _criticalAreaZombies.RemoveAt(0);

        if (_criticalAreaZombies.Count> 0)
        {
            _isMoving = true; }
    }

}
