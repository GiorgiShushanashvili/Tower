using UnityEngine;

public class Zombie : ZombieParent
{
    public float health;

    private void Start()
    {
        _health = 5f;
        _speed = 0.3f;
        _isMoving = true;
        //type = ZombieType.Warrior;
    }
    void Update()
    {
        if (_isMoving)
        { 
            ZombieMove();
        }
        health = _health;
    }

    public override void ZombieMove()
    {
        Vector3 dirToCube=(_cube.position- transform.position).normalized;
        transform.position = Vector3.MoveTowards(transform.position, _cube.position, _speed * Time.deltaTime);
        //_rb.MovePosition(transform.position+ dirToCube * _speed*Time.deltaTime);
    }

    private bool isDead = false;

    public override void TakeDamage(float damage)
    {
        _health -= damage;
        if(_health <= 0 && !isDead)
        {
            _animator.SetBool("Dead", true);
            _isMoving = false;
            Die();
            isDead = true;
            TemporaryCoins.Instance.IncreaseCoinsByWalkingZombies();
            
        }
    }

    private void Die()
    {
        if (CriticalAreaHandler.CriticalInstance._criticalAreaZombies.Count > 0)
        {
            CriticalAreaHandler.CriticalInstance.RemoveZombie();
        }
        AnimationManager.Animation._animator.SetBool("Shooting", false);
        AnimationManager.Animation._animator.SetBool("IsInTriggerZone", false);

        Destroy(gameObject,1.2f);
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
            Destroy(other.gameObject);
            TakeDamage(other.gameObject.GetComponent<Bullet>()._bulletStrength);
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

