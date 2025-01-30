using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstBoostPlayer : PlayerParent
{
    bool arrived;
    bool _killedAllZombiesInView;

    public override void PlayerMove()
    {
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
}
