using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] CapsuleCollider _capsuleCollider;

    

    public float _bulletSpeed;
    public float _bulletStrength;

    private float _lifeTime = 2f;
    
    private void Awake()
    {
        _capsuleCollider.isTrigger = true;
        _bulletSpeed =GlobalVariables._bulletSpeedForPlayer;
        _bulletStrength=GlobalVariables._damageStrengthForPlayer;
    }
    private void Start()
    {
        Destroy(gameObject,_lifeTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Tower")
        {
            _capsuleCollider.isTrigger = false;
            Destroy(gameObject);
        }
    }

}
