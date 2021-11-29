using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InputController : MonoBehaviour
{
    public GameObject Character;
    public Animator RobotAnimator;
    private float dt;
    private Orientation m_orientation;
    private bool isJumping;
    public bool noFloor;
    private bool startJump;
    public float coefJump = 0.08f;
    enum Orientation
    {
        Right,
        Left,
    }

    private void Awake()
    {
        m_orientation = Orientation.Right;
        isJumping = false;
        startJump = false;
        noFloor = false;
    }

    void Update()
    {
        if (!isJumping)
        {
            //Move
            if (Input.GetButtonDown("Move_Right"))
            {
                if (m_orientation == Orientation.Left)
                {
                    resetAllTriggers();
                    RobotAnimator.SetTrigger("WalkR");
                    m_orientation = Orientation.Right;
                }
                else
                {
                    resetAllTriggers();
                    RobotAnimator.SetTrigger("WalkR");
                }
            }

            if (Input.GetButtonDown("Move_Left"))
            {
                if (m_orientation == Orientation.Right)
                {
                    resetAllTriggers(); 
                    RobotAnimator.SetTrigger("WalkL");
                    m_orientation = Orientation.Left;
                }
                else
                {
                    resetAllTriggers();
                    RobotAnimator.SetTrigger("WalkL");
                }
            }
            if (Input.GetButton("Move_Right") || Input.GetButton("Move_Left"))
            {
                dt += Time.deltaTime;
                Move(Time.deltaTime);
            }

            //STOP
            if (Input.GetButtonUp("Move_Right") && m_orientation== Orientation.Right)
            {
                dt = 0;
                resetAllTriggers();
                RobotAnimator.SetTrigger("StopR");
                Input.ResetInputAxes();
            }
            if (Input.GetButtonUp("Move_Left") && m_orientation == Orientation.Left)
            {
                dt = 0;
                resetAllTriggers();
                RobotAnimator.SetTrigger("StopL");
                Input.ResetInputAxes();
            }

            //Jump
            if (Input.GetButtonDown("Jump"))
            {
                dt = 0;
                isJumping = true;
                Jump();
                if (m_orientation == Orientation.Right)
                {
                    resetAllTriggers();
                    RobotAnimator.SetTrigger("JumpR");
                }
                else
                {
                    resetAllTriggers();
                    RobotAnimator.SetTrigger("JumpL");
                }
            }
        }
        else
        {
            if (Input.GetButton("Move_Left"))
            {
                    Character.transform.position += 3 * Time.deltaTime * -Character.transform.forward;
            }
            if (Input.GetButton("Move_Right"))
            {
                    Character.transform.position += 3 * Time.deltaTime * Character.transform.forward;
            }
        }
    }

    public void Move(float dt)
    {/*
        float dtsqrt;
        if (dt < 0.5)
        {
            dtsqrt = dt;
        }
        else
        {
            dtsqrt = (float)Math.Pow(dt, 2);
        }
        */
        float t = 5*dt;
        if (m_orientation == Orientation.Left) t = -t;
        Character.transform.position += t * Character.transform.forward;
    }

    public void Jump()
    {
        Invoke("StartJump", 0.4f);
        Invoke("EndJump", 0.8f);
    }

    public void StartJump()
    {
        Character.GetComponent<Rigidbody>().useGravity = false;
        startJump = true;
    }
    public void EndJump()
    {
        Character.GetComponent<Rigidbody>().useGravity = true;
        startJump = false;
        noFloor = true;
    }

    private float dtJump=0;
    private void FixedUpdate()
    {
        if (startJump)
        {
            dtJump += Time.deltaTime;
            Character.transform.position += ((dtJump* dtJump)) * coefJump * Character.transform.up;
        }
        dtJump = 0;
    }

    public void EndAnimJump()
    {
        noFloor = false;
        isJumping = false;
        Input.ResetInputAxes();
        if (m_orientation == Orientation.Right)
        {
            RobotAnimator.SetTrigger("JumpRFin");
        }
        else
        {
            RobotAnimator.SetTrigger("JumpLFin");
        }
    }

    private void resetAllTriggers()
    {
        foreach (var trigger in RobotAnimator.parameters)
        {
            if (trigger.type == AnimatorControllerParameterType.Trigger)
            {
                RobotAnimator.ResetTrigger(trigger.name);
            }
        }
    }
}
