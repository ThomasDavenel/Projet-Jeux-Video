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
    private Orientation m_orientation;
    private bool isJumping;
    public bool noFloor;
    private bool startJump;
    public float coefJump = 0.08f;

    private float lastY;

    private bool turn;

    private ParticleSystem[] l_particule;
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
        turn = false;
        lastY = Character.transform.position.y;
        l_particule = Character.GetComponentsInChildren<ParticleSystem>();
    }

    void Update()
    {

        if (!isJumping)
        {
            //Check if falling
            //In progress
            if(lastY- Character.transform.position.y > 0.001 && false)
            {
                CheckIfJumping();
            }
            lastY = Character.transform.position.y;
            //Move
            if (Input.GetButtonDown("Move_Right"))
            {
                if (m_orientation == Orientation.Left)
                {
                    turn = true;
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
                    turn = true;
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
            if ((Input.GetButton("Move_Right") || Input.GetButton("Move_Left")) && !turn)
            {
                Move(Time.deltaTime);
            }

            //STOP
            if (Input.GetButtonUp("Move_Right") && m_orientation== Orientation.Right)
            {
                resetAllTriggers();
                RobotAnimator.SetTrigger("StopR");
                Input.ResetInputAxes();
            }
            if (Input.GetButtonUp("Move_Left") && m_orientation == Orientation.Left)
            {
                resetAllTriggers();
                RobotAnimator.SetTrigger("StopL");
                Input.ResetInputAxes();
            }

            //Jump
            if (Input.GetButtonDown("Jump"))
            {
                //PARTICULE
                foreach(ParticleSystem p in l_particule)
                {
                    p.Play();
                }

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
    {
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
    private float dtTurn = 0;
    private void FixedUpdate()
    {
        if (startJump)
        {
            dtJump += Time.deltaTime;
            Character.transform.position += coefJump * (float)Math.Pow(1 - dtJump, 2) * Character.transform.up;
            if(m_orientation == Orientation.Right)
            {
                Character.transform.position += 3 * Time.deltaTime * Character.transform.forward;
            }
            else if(m_orientation == Orientation.Left)
            {
                Character.transform.position += 3 * Time.deltaTime * -Character.transform.forward;
            }
        }
        else
        {
            dtJump = 0;
        }
        if (turn)
        {
            dtTurn += Time.deltaTime;
            if (dtTurn > 0.15)
            {
                turn = false;
            }
        }
        else
        {
            dtTurn = 0;
        }
    }

    public void EndAnimJump()
    {
        isJumping = false;
        Invoke("resetParamAfterEndAnimJump", 0.2f);
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
    private void resetParamAfterEndAnimJump()
    {
        noFloor = false;
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

    public void CheckIfJumping()
    {
        if (!noFloor)
        {
            isJumping = true;
            noFloor =true;
            if(m_orientation == Orientation.Right)RobotAnimator.SetTrigger("Fall_R");
            else if(m_orientation == Orientation.Left) RobotAnimator.SetTrigger("Fall_L");
        }
    }
}
