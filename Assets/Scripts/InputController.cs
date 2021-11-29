using System;
using System.Collections;
using System.Collections.Generic;
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
                    RobotAnimator.ResetTrigger("StopL");
                    RobotAnimator.ResetTrigger("StopR");
                    RobotAnimator.SetTrigger("WalkR");
                    m_orientation = Orientation.Right;
                }
                else
                {
                    RobotAnimator.ResetTrigger("StopL");
                    RobotAnimator.ResetTrigger("StopR");
                    RobotAnimator.SetTrigger("WalkR");
                }
            }

            if (Input.GetButtonDown("Move_Left"))
            {
                if (m_orientation == Orientation.Right)
                {
                    RobotAnimator.ResetTrigger("StopL");
                    RobotAnimator.ResetTrigger("StopR");
                    RobotAnimator.SetTrigger("WalkL");
                    m_orientation = Orientation.Left;
                }
                else
                {
                    RobotAnimator.ResetTrigger("StopL");
                    RobotAnimator.ResetTrigger("StopR");
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
                RobotAnimator.SetTrigger("StopR");
                Input.ResetInputAxes();
            }
            if (Input.GetButtonUp("Move_Left") && m_orientation == Orientation.Left)
            {
                dt = 0;
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
                    RobotAnimator.SetTrigger("JumpR");
                }
                else
                {
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
        Invoke("StartJump", 0.65f);
        Invoke("EndJump", 1.5f);
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

    private void FixedUpdate()
    {
        if (startJump)
        {
            Character.transform.position += coefJump * Character.transform.up;
        }
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
}
