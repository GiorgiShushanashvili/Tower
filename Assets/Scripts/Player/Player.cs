using Cinemachine.Utility;
using UnityEditor.Animations;
using UnityEngine;
using static Enums;

public class Player : PlayerParent
{
    //[SerializeField] private ObjectClones objectClones;

    private void Update()
    {  
        if (CriticalAreaHandler.CriticalInstance._isMoving)
        {
            PlayerMove();
        }
        else if (move)
        {
            Move();
        }
    }

    public override void PlayerMove()
    {
        if (CriticalAreaHandler.CriticalInstance._criticalAreaZombies.Count > 0)
        {
            Transform targetZombie = CriticalAreaHandler.CriticalInstance._criticalAreaZombies[0];
            Vector3 dir = _tower.transform.position - targetZombie.position;
            
            Ray ray = new Ray(targetZombie.position, dir);
            RaycastHit[] hits=Physics.RaycastAll(ray,Mathf.Infinity);
            Debug.DrawRay(targetZombie.position, 50 * dir, Color.green, 2);

            foreach(var hit in hits)
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
            Transform targetZoombie = CriticalAreaHandler.CriticalInstance._criticalAreaZombies[0];
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

    public override void checker()
    {
        float distanceThreshold = 0.2f;
        if (Vector3.Distance(transform.position, potentialPos) <= distanceThreshold)
        {
            while (CriticalAreaHandler.CriticalInstance._criticalAreaZombies.Count > 0)
            {
                Transform targetZoombie = CriticalAreaHandler.CriticalInstance._criticalAreaZombies[0];
                Vector3 lookAtPosition = targetZoombie.position;
                lookAtPosition.y = gameObject.transform.position.y;

                Quaternion targetRotation = Quaternion.LookRotation(lookAtPosition - transform.position);

                transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, 0.9f);
                break;
            }
            move = false;
            CriticalAreaHandler.CriticalInstance._isMoving = false;
            AnimationManager.Animation._animator.SetBool("Shooting", true);
        }
    }

    }
