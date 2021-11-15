using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetector : MonoBehaviour
{
    public InputController inputController;
    public Animator RobotAnimator;

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Colision1");
        if (inputController.isJumping)
        {
            Debug.Log("Colision2");
            inputController.isJumping = false;
            RobotAnimator.SetTrigger("JumpFin");
        }
    }
}
