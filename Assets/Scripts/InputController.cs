using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour
{
    public GameObject Character;
    public Animator RobotAnimator;
    private float dt;

    void Update()
    {
        if (Input.GetButtonDown("Move_Right"))
        {
            Debug.Log("Walk");
            RobotAnimator.SetTrigger("Walk");
        }
        if (Input.GetButton("Move_Right"))
        {
            dt += Time.deltaTime;
            Move(dt);
        }
        else
        {
            RobotAnimator.ResetTrigger("Walk");
            dt = 0;
        }

        if (Input.GetButtonDown("Move_Left"))
        {
            Debug.Log("Turn");
            RobotAnimator.SetTrigger("Turn");
        }

        if (Input.GetButtonUp("Move_Right"))
        {
            Debug.Log("Stop");
            RobotAnimator.SetTrigger("Stop");
        }
    }

    public void Move(float dt)
    {
        float dtsqrt;
        if (dt < 0.5)
        {
            dtsqrt = dt;
        }
        else
        {
            dtsqrt = (float)Math.Pow(dt, 2);
        }
        float t = Mathf.Clamp(dtsqrt, 0, 5)/50;
        Debug.Log(dt + "-->"+ dtsqrt+"-->" + t);
        Character.transform.position += t * Character.transform.forward;
    }
}
