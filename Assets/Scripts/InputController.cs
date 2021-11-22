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
    public bool isJumping;
    private bool startJump;
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
                    Character.transform.position += 5 * Time.deltaTime * -Character.transform.forward;
            }
            if (Input.GetButton("Move_Right"))
            {
                    Character.transform.position += 5 * Time.deltaTime * Character.transform.forward;
            }
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

    public void Jump()
    {
        Invoke("StartJump", 0.65f);
        Invoke("EndJump", 1.8f);
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
    }

    private void FixedUpdate()
    {
        if (startJump)
        {
            Character.transform.position += 0.07f * Character.transform.up;
        }
    }

    public void EndAnimJump()
    {
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
