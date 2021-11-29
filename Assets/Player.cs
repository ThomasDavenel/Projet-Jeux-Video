using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int nbPtsVie;

    private void Awake()
    {
        nbPtsVie = 10;
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
        if (nbPtsVie < 0)
        {
            print("DEAD");
        }
    }
}
