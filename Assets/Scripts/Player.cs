using UnityEngine;

public class Player : MonoBehaviour
{

    [SerializeField] GameObject _tower;
    [SerializeField] GameObject _bullet;
    [SerializeField] Transform _bulletPoint;
    [SerializeField] Rigidbody _bulletRb;

    Vector3 potentialPos;


    bool move = false;


    private void FixedUpdate()
    {
        if (CriticalAreaHandler.CriticalInstance._isMoving)
        {

            PLayerMove();
        }
        else if (move)
        {
            Move();
        }
    }

    private void PLayerMove()
    {
        while (CriticalAreaHandler.CriticalInstance._criticalAreaZombies.Count > 0)
        {
            Transform targetZombie = CriticalAreaHandler.CriticalInstance._criticalAreaZombies[0];
            float res = Degree(targetZombie.position);
            potentialPos.x = 0.4f * Mathf.Sin(res);
            potentialPos.z = 0.4f * Mathf.Cos(res);
            potentialPos.y = transform.position.y;
            move = true;
            CriticalAreaHandler.CriticalInstance._isMoving = false;
            break;
        }
    }

    private void Move()
    {
        Vector3 lookAtPosition = potentialPos;
        lookAtPosition.y = transform.position.y;
        Quaternion targetRotation = Quaternion.LookRotation(lookAtPosition - transform.position);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, 0.6f);
        transform.position = Vector3.MoveTowards(transform.position, lookAtPosition, 1f * Time.deltaTime);
        checker();
    }

    private void SHootingHelper()
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

    void checker()
    {
        float distanceThreshold = 0.03f;

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

        float Degree(Vector3 pos)
        {
            return Mathf.Atan2(pos.x, pos.z);
        }
    }
