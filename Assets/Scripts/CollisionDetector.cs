using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetector : MonoBehaviour
{
    InputController inputController;
    private void Awake()
    {
        inputController = GameObject.FindObjectOfType<InputController>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (inputController.noFloor)
        {
            inputController.EndAnimJump();
        }
    }
}
