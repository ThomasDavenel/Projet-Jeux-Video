using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int nbPtsVie;
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
        if (nbPtsVie < 0 && isAlive)
        {
            isAlive = false;
            foreach(MeshRenderer m in gameObject.GetComponentsInChildren<MeshRenderer>())
            {
                m.enabled = false;
            }
            ParticleSystem p = gameObject.GetComponentInChildren<ParticleSystem>();
            if (p) p.Play();
        }
        if (!isAlive)
        {
            ParticleSystem p = gameObject.GetComponentInChildren<ParticleSystem>();
            if (!p.isPlaying)
            {
                gameObject.SetActive(false);
            }
        }
    }
}
