using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int nbPtsVie;
    public Animator m_Animator;

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
        if (nbPtsVie < 0)
        {
            if(m_Animator)m_Animator.SetTrigger("DieR");
            Debug.Log("Dead");
        }
    }
}
