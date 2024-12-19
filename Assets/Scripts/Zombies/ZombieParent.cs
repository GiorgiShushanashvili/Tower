using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ZombieParent : MonoBehaviour
{
    [SerializeField] protected Transform _cube;
    [SerializeField] protected Animator _animator;
     protected MeshCollider _cubeCollider;
    [SerializeField] protected CapsuleCollider _zombieCollider;
    [SerializeField] protected Rigidbody _rb;

    Transform child;

    public ZombieType type { get; set; }
    public float _health { get;protected set; }
    public float _speed { get; set; }
    public int _damage { get; protected set; }
    public bool _isMoving { get; protected set; }
    //public float _timeInterval { get;set; }

    private void Start()
    {
        child = _cube.transform.Find("Cylinder");
        _cubeCollider = _cube.GetComponent<MeshCollider>();
        //_health = 100f;
        _isMoving = true;
    }

    public virtual void ZombieMove() { }

    public virtual void TakeDamage(float damage) { }

}
public enum ZombieType
{
    Warrior = 1,
    Shooter = 2
}
