using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private float _lifeTime = 3f;
    public float _damage;

    private void Start()
    {
        _damage =PLayerManager.Instance.UpdateStrengthForLive();
        Destroy(gameObject,_lifeTime);
    }

}
