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
        if (Input.GetButtonDown("Move_Front"))
        {
            Debug.Log("Walk");
            RobotAnimator.SetTrigger("Walk");
        }
        if (Input.GetButton("Move_Front"))
        {
            dt += Time.deltaTime;
            Move(dt);
        }
        else
        {
            RobotAnimator.ResetTrigger("Walk");
            dt = 0;
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
