using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetector : MonoBehaviour
{
    public InputController inputController;

    private void OnCollisionEnter(Collision collision)
    {
        if (inputController.isJumping)
        {
            inputController.EndAnimJump();
        }
    }
}
