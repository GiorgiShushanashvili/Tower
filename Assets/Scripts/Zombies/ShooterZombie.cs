using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ShooterZombie : ZombieParent
{
    [SerializeField] GameObject _stone;
    [SerializeField] Transform _stonePoint;
    [SerializeField] Rigidbody _stoneRb;
    [SerializeField] Transform _shooterChildStone;

    private float _forwardForce;
    private float _upForce;

    private void Start()
    {
        _health = GlobalVariables._healthForShootergZombie;
        _speed = 1f;
        //_damage = 3;
        _isMoving = true;
        _animator.enabled = true;

        _forwardForce = 4f;
        _upForce = 4f;

        type = ZombieType.Shooter;
        _shooterChildStone = transform.Find("Cube");
        _shooterChildStone.gameObject.SetActive(false);
    }

    void Update()
    {
        if (_isMoving)
        {
            ZombieMove();
        }
    }

    private bool isDead = false;

    public override void TakeDamage(float damage)
    {
        _health -= damage;
        if (_health <= 0 && !isDead)
        {
            _animator.SetBool("Dead", true);
            _isMoving = false;
            _shooterChildStone.gameObject.SetActive(false);
            Die();
            isDead = true;
            TemporaryCoins.Instance.IncreaseCoinsByPistolZombies();
        }
    }

    private void Die()
    {
        
        if (CriticalAreaHandler.CriticalInstance._criticalAreaZombies.Count > 0)
        {
            CriticalAreaHandler.CriticalInstance.RemoveZombie();
        }
        /*else
        {
            TriggerZone.Instance.RemoveZombie();
        }*/
        AnimationManager.Animation._animator.SetBool("Shooting", false);
        AnimationManager.Animation._animator.SetBool("IsInTriggerZone", false);
        Destroy(gameObject,1.2f);     
    }

    public override void ZombieMove()
    {
        Vector3 dirToCube = (_cube.position - transform.position).normalized;
        _rb.MovePosition(transform.position + dirToCube * _speed * Time.deltaTime);
    }

    private void ShootToTower()
    {
        GameObject stone = Instantiate(_stone, _stonePoint.position, Quaternion.identity);
        _stoneRb=stone.GetComponent<Rigidbody>();
        float upForce = Random.Range(_upForce - 0.5f, _upForce + 0.5f);
        Vector3 direction= transform.forward * _forwardForce + transform.up * upForce;
        _stoneRb.AddForce(direction, ForceMode.Impulse);
        Destroy(stone,2f)


        /* Vector3 target=_cube.transform.position;
         target.y = target.y + 0.4f;
         Quaternion targetRotation = Quaternion.LookRotation(target - transform.position);
         transform.rotation=Quaternion.Slerp(transform.rotation, targetRotation, 0.9f*Time.deltaTime);

         GameObject bullet = Instantiate(_bullet, _bulletPoint.position, Quaternion.identity);
         bullet.tag = "ZombieBullet";
         Bullet spawnBullet = bullet.GetComponent<Bullet>();
         _bulletRb=bullet.GetComponent<Rigidbody>();
         Vector3 direction = (target-bullet.transform.position).normalized;
         //bullet.transform.position += direction * 2f;
         _bulletRb.velocity=direction*2f/***//*Time.deltaTime*/
        ;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "ShooterZone")
        {
            _isMoving = false;
            _shooterChildStone.gameObject.SetActive(true);
            _animator.SetBool("Shooting", true);
        }
        else if(other.gameObject.tag == "Bullet")
        {
            TakeDamage(other.gameObject.GetComponent<Bullet>()._bulletStrength);
            Destroy(other.gameObject);
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
