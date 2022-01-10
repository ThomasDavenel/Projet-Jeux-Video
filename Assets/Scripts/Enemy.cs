using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int nbPtsVie;

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
            gameObject.SetActive(false);
            Debug.Log("Dead");
        }
    }
}
