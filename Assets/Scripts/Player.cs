using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public int nbPtsVie;
    public Animator m_Animator;
    private bool isAlive;

    private void Awake()
    {
        isAlive = true;
    }

    public void hitted(int damages = 1)
    {
        nbPtsVie -= damages;
    }

    public void healed(int heal = 1)
    {
        nbPtsVie += heal;
    }

    private void Update()
    {
        if (nbPtsVie <= 0 && isAlive)
        {
            isAlive = false;
            if (m_Animator)m_Animator.SetTrigger("DieR");
            Debug.Log("Dead");
        }
        if (m_Animator.GetCurrentAnimatorStateInfo(0).IsName("DyingR2"))
        {
            SceneManager.LoadScene("SceneMort");
        }
    }

    public bool IsAlive()
    {
        return isAlive;
    }
}
