using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstBoostPlayer : PlayerParent
{

    Quaternion targetRotation;
    Transform targetZoombie;

    public void check() 
    {
        float distanceThreshold = 0.2f;
        if (Vector3.Distance(transform.position, potentialPos) <= distanceThreshold)
        {
            while (CriticalAreaHandler.CriticalInstance._criticalAreaZombies.Count > 0)
            {
                targetZoombie = CriticalAreaHandler.CriticalInstance._criticalAreaZombies[0];
                Vector3 lookAtPosition = targetZoombie.position;
                lookAtPosition.y = gameObject.transform.position.y;

                targetRotation = Quaternion.LookRotation(lookAtPosition - transform.position);

                transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, 0.9f);
                break;
            }
            move = false;
            CriticalAreaHandler.CriticalInstance._isMoving = false;
            AnimationManager.Animation._animator.SetBool("Shooting", true);
        }
    }

    public void Helper()
    {
        float viewableAngle = Vector3.Angle(targetZoombie.forward, transform.forward);


    }
}
