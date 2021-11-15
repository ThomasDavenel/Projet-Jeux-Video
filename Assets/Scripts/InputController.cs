using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InputController : MonoBehaviour
{
    public GameObject Character;
    public Animator RobotAnimator;
    private float dt;
    private Orientation m_orientation;
    enum Orientation
    {
        Right,
        Left,
    }

    private void Start()
    {
        m_orientation = Orientation.Right;
    }

    void Update()
    {
        //Move
        if (Input.GetButtonDown("Move_Right"))
        {
            if(m_orientation == Orientation.Left)
            {
                RobotAnimator.SetTrigger("WalkR");
                m_orientation = Orientation.Right;
            }
            else
            {
                RobotAnimator.SetTrigger("WalkR");
            }
        }

        if (Input.GetButtonDown("Move_Left"))
        {
            if (m_orientation == Orientation.Right)
            {
                RobotAnimator.SetTrigger("WalkL");
                m_orientation = Orientation.Left;
            }
            else
            {
                RobotAnimator.SetTrigger("WalkL");
            }
        }
        if (Input.GetButton("Move_Right") || Input.GetButton("Move_Left"))
        {
            dt += Time.deltaTime;
            Move(dt);
        }

        //STOP
        if (Input.GetButtonUp("Move_Right"))
        {
            dt = 0;
            RobotAnimator.SetTrigger("StopR");
        }
        if (Input.GetButtonUp("Move_Left"))
        {
            dt = 0;
            RobotAnimator.SetTrigger("StopL");

        }

        //Jump
        if (Input.GetButtonDown("Jump"))
        {
            RobotAnimator.SetTrigger("Jump");
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
        float t = Mathf.Clamp(dtsqrt, 0, 2.5f)/50;
        if (m_orientation == Orientation.Left) t = -t;
        Character.transform.position += t * Character.transform.forward;
    }
}
