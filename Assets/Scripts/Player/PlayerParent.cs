using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerParent : MonoBehaviour
{
    [SerializeField] public GameObject _tower;
    [SerializeField] public GameObject _bullet;
    [SerializeField] public Transform _bulletPoint;
    [SerializeField] public Rigidbody _bulletRb;

    [SerializeField] public GameObject secondPistol;
    [SerializeField] public Transform secondBulletPoint;

    [SerializeField] public Animator _controller;


    public Vector3 potentialPos;
    public bool move = false;

    public virtual void SHootingHelper() { }
    public virtual void checker() { }
    public virtual void Move() { }
    public virtual void PlayerMove() { }

    public float Degree(Vector3 pos)
    {
        return Mathf.Atan2(pos.x, pos.z);
    }
}
