using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] GameObject _bullet;
    [SerializeField] Transform _bulletPoint;
    [SerializeField] Rigidbody _bulletRb;

    private float _bulletSpeed;

    private void Start()
    {
        _bulletSpeed = PLayerManager.Instance.UpdateSpeedForLive();

        StartCoroutine(ShootToEnemy());
    }

    private IEnumerator ShootToEnemy()
    {
        while (true)
        {
            if(TriggerZone.Instance._zombies.Count > 0) { 
                Transform targetZombie = TriggerZone.Instance._zombies[0];
                if (targetZombie != null)
                {
                    GameObject bullet = Instantiate(_bullet, _bulletPoint.position, _bullet.transform.rotation);
                    Vector3 direction = (targetZombie.position - bullet.transform.position).normalized;
                    _bulletRb = bullet.GetComponent<Rigidbody>();
                    _bulletRb.velocity = direction * _bulletSpeed;
                    Debug.Log(_bulletSpeed);
                    yield return new WaitForSeconds(1);
                }
            }
            else
            {
                yield return new WaitForSeconds(2);
            }
        }
    }

}
