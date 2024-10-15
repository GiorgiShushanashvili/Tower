using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Zombie : ZombieParent
{
    //private Bullet _bullet;

    private void Start()
    {
        _health = 100f;
        _speed = 5f;
        _isMoving = true;
    }
    void Update()
    {
        if (_isMoving)
        { 
            ZombieMove();
        }
    }

    public override void ZombieMove()
    {
        Vector3 dirToCube=(_cube.position- transform.position).normalized;
        _rb.MovePosition(transform.position+ dirToCube * _speed*Time.deltaTime);
    }

    public override void TakeDamage(float damage)
    {
        _health -= damage;
        if(_health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Destroy(gameObject);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Tower")
        {
            _isMoving = false;
            _animator.SetBool("Attack", true);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Bullet")
        {
            TakeDamage(other.gameObject.GetComponent<Bullet>()._damage);
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Tower")
        {
            _animator.SetBool("Attack", false);
            _isMoving = true;
        }
    }
}

