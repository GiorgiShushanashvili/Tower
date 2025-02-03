using UnityEngine;
using static Enums;


public class PLayerMove : MonoBehaviour
{
    public void PlayerMove()
    {
        if (ObjectClones._player.pLayerCondition==PLayerCondition.Standard)
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
        }
    }
}
