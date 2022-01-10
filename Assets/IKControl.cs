using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class IKControl : MonoBehaviour
{

    protected Animator animator;

    public bool ikActive = false;
    public Transform rightHandObj = null;
    public Transform lookObj = null;
    public Transform Hand;
    public Shoot gun;
    private bool isPistolInHand;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    //a callback for calculating IK
    void OnAnimatorIK()
    {
        if (animator&&isPistolInHand)
        {
            //if the IK is active, set the position and rotation directly to the goal. 
            RaycastHit hitInfo = new RaycastHit();
            bool hit = Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hitInfo);
            if (hit)
            {
                Vector3 cible = hitInfo.point;

                // Set the look target position, if one has been assigned
                if (lookObj != null)
                {
                    animator.SetLookAtWeight(1);
                    animator.SetLookAtPosition(lookObj.position);
                    Debug.Log("lookat");
                }

                //Debug.Log(Quaternion.Angle(Quaternion.LookRotation(rightHandObj.position - Hand.position), gameObject.transform.rotation));

                // Set the right hand target position and rotation, if one has been assigned
                if (Quaternion.Angle( Quaternion.LookRotation(cible - Hand.position),gameObject.transform.rotation)<90)
                {
                    animator.SetIKPositionWeight(AvatarIKGoal.RightHand, 1);
                    animator.SetIKRotationWeight(AvatarIKGoal.RightHand, 1);
                    animator.SetIKPosition(AvatarIKGoal.RightHand, cible);
                    animator.SetIKRotation(AvatarIKGoal.RightHand, Quaternion.LookRotation(cible - Hand.position) * Quaternion.Euler(0, 0, -90) );
                    
                    if (Input.GetMouseButtonDown(0))
                    {
                        Debug.Log("Hit " + hitInfo.transform.gameObject.name);
                        gun.ShootBullet();
                    }
                }
            }

            //if the IK is not active, set the position and rotation of the hand and head back to the original position
            else
            {
                animator.SetIKPositionWeight(AvatarIKGoal.RightHand, 0);
                animator.SetIKRotationWeight(AvatarIKGoal.RightHand, 0);
                animator.SetLookAtWeight(0);
            }
        }
    }

    public void ToggleIsPistolInHand()
    {
        isPistolInHand = !isPistolInHand;
        gun.gameObject.SetActive(isPistolInHand);
    }
}