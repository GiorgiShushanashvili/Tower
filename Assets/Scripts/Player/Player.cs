using Cinemachine.Utility;
using Unity.Mathematics;
using UnityEditor.Animations;
using UnityEngine;
using static Enums;

public class Player : PlayerParent
{

    [SerializeField] Transform _rightHandTarget;
    [SerializeField] Transform _leftHandTarget;

    Transform secondEnemyToSHoot;
    Transform targetZoombie;

    private bool _shjouldRotate = false;
    private bool _secondToShoot = false;

    private void Update()
    {
        /*else if (secondEnemyToSHoot != null)
        {
            _leftHandTarget.transform.position=secondEnemyToSHoot.position;
        }*/

        if (CriticalAreaHandler.CriticalInstance._isMoving)
        {
            PlayerMove();
        }
        else if (move)
        {
            Move();
        }
    }

    private void FixedUpdate()
    {
        if (targetZoombie != null && _shjouldRotate)
        {
            Debug.Log(8);
            _rightHandTarget.transform.position = targetZoombie.position;
        }
    }

    public override void PlayerMove()
    {
        _shjouldRotate=false;
        if (CriticalAreaHandler.CriticalInstance._criticalAreaZombies.Count > 0)
        {
            Transform targetZombie = CriticalAreaHandler.CriticalInstance._criticalAreaZombies[0];
            Vector3 dir = _tower.transform.position - targetZombie.position;

            Ray ray = new Ray(targetZombie.position, dir);
            RaycastHit[] hits = Physics.RaycastAll(ray, Mathf.Infinity);
            Debug.DrawRay(targetZombie.position, 50 * dir, Color.green, 2);

            foreach (var hit in hits)
            {
                if (hit.collider.CompareTag("Edge"))
                {
                    potentialPos = hit.point;
                    potentialPos.y = transform.position.y;
                    move = true;
                    CriticalAreaHandler.CriticalInstance._isMoving = false;
                    AnimationManager.Animation._animator.SetBool("IsInTriggerZone", true);
                    break;
                }

            }
        }
        else
        {
            AnimationManager.Animation._animator.SetBool("IsInTriggerZone", false);
        }
    }


    public override void Move()
    {
        Vector3 lookAtPosition = potentialPos;
        Quaternion targetRotation = Quaternion.LookRotation(lookAtPosition - transform.position);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, 0.6f);
        transform.position = Vector3.MoveTowards(transform.position, lookAtPosition, 1f * Time.deltaTime);
        checker();
    }

    public override void SHootingHelper()
    {
        while (CriticalAreaHandler.CriticalInstance._criticalAreaZombies.Count > 0)
        {
            targetZoombie = CriticalAreaHandler.CriticalInstance._criticalAreaZombies[0];
            GameObject bullet = Instantiate(_bullet, _bulletPoint.position, _bullet.transform.rotation);
            bullet.tag = "Bullet";
            Bullet spawnBullet = bullet.GetComponent<Bullet>();
            Vector3 targetPostion = targetZoombie.position;
            targetPostion.y = targetPostion.y + 0.25f;
            Vector3 direction = (targetPostion - bullet.transform.position).normalized;
            _bulletRb = bullet.GetComponent<Rigidbody>();
            Quaternion targetRotation = Quaternion.LookRotation(targetPostion - bullet.transform.position);
            bullet.transform.rotation = Quaternion.Slerp(bullet.transform.rotation, targetRotation, 4f);
            _bulletRb.velocity = direction * spawnBullet._bulletSpeed;
            break;
        }
    }

    public void SecondShoot()
    {
        while (CriticalAreaHandler.CriticalInstance._criticalAreaZombies.Count > 1)
        {
            if (_secondToShoot)
            {
                GameObject bullet = Instantiate(_bullet, secondBulletPoint.position, _bullet.transform.rotation);
                bullet.tag = "Bullet";
                Bullet spawnBullet = bullet.GetComponent<Bullet>();
                Vector3 targetPostion = secondEnemyToSHoot.position;
                targetPostion.y = targetPostion.y + 0.25f;
                Vector3 direction = (targetPostion - bullet.transform.position).normalized;
                _bulletRb = bullet.GetComponent<Rigidbody>();
                Quaternion targetRotation = Quaternion.LookRotation(targetPostion - bullet.transform.position);
                bullet.transform.rotation = Quaternion.Slerp(bullet.transform.rotation, targetRotation, 4f);
                _bulletRb.velocity = direction * spawnBullet._bulletSpeed;
            }
            break;
        }
    }

    public override void checker()
    {
        float distanceThreshold = 0.2f;
        _secondToShoot = false;
        if (Vector3.Distance(transform.position, potentialPos) <= distanceThreshold)
        {
            while (CriticalAreaHandler.CriticalInstance._criticalAreaZombies.Count > 0)
            {
                _shjouldRotate = true;
                Transform targetZoombie = CriticalAreaHandler.CriticalInstance._criticalAreaZombies[0];

                Vector3 lookAtPosition = targetZoombie.position;
                lookAtPosition.y = gameObject.transform.position.y;

                //_rightHandTarget.transform.position = targetZoombie.transform.position;
                Quaternion targetRotation = Quaternion.LookRotation(lookAtPosition - transform.position);

                transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, 0.9f);
                break;
            }
            //SecondEnemyDetector();
            move = false;
            CriticalAreaHandler.CriticalInstance._isMoving = false;
            AnimationManager.Animation._animator.SetBool("Shooting", true);
        }
    }

    private void SecondEnemyDetector()
    {
        if (CriticalAreaHandler.CriticalInstance._criticalAreaZombies.Count > 1)
        {
            for (int i = 1; i < CriticalAreaHandler.CriticalInstance._criticalAreaZombies.Count; i++)
            {
                secondEnemyToSHoot = CriticalAreaHandler.CriticalInstance._criticalAreaZombies[i];
                Vector3 targetDirection = secondEnemyToSHoot.position - transform.position;
                float viewableAngle = Vector3.Angle(targetDirection, transform.forward);
                if (viewableAngle > -50 && viewableAngle < 50)
                {
                    ObjectClones._player.secondPistol.SetActive(true);
                    _leftHandTarget.transform.position= secondEnemyToSHoot.position;
                    _secondToShoot = true;
                }
            }
        }
    }

}
