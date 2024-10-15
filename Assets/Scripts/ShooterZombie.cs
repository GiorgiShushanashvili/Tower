using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShooterZombie : ZombieParent
{
    private void Start()
    {
        _health = 5;
        _speed = 3f;
        _damage = 3;
        _isMoving = true;
        _animator.enabled = true;
    }

    void Update()
    {
        if (_isMoving)
        {
            ZombieMove();
        }
    }

    public override void TakeDamage(float damage)
    {
        _health -= damage;
        if (_health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Destroy(gameObject);
        TriggerZone.Instance.RemoveZombie();
    }

    public override void ZombieMove()
    {
        Vector3 dirToCube = (_cube.position - transform.position).normalized;
        _rb.MovePosition(transform.position + dirToCube * _speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "ShooterZone")
        {
            _isMoving = false;
            _animator.SetBool("Shooting", true);
        }
        else if(other.gameObject.tag == "Bullet")
        {
            TakeDamage(other.gameObject.GetComponent<Bullet>()._damage);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "ShooterZone")
        {
            _animator.SetBool("Shooting", false);
            _isMoving = true;
        }
    }
}
