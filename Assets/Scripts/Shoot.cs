using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    private bool isReadyToShoot;
    private float dtShoot;

    public float rayDistance;
    public float speedBullet;
    public float intervalEntre2Tirs;
    public GameObject[] l_Joueurs;

    private Vector3 pt1 = new Vector3(0, 0,0);
    private Vector3 pt2 = new Vector3(1, 0, 0);
    private float radius = 1;

    public GameObject Bullet;
    public Transform bulletTransform;
    private Dictionary<GameObject, float> l_Bullet;

    private void Awake()
    {
        isReadyToShoot = true;
        dtShoot = 0;
        l_Bullet = new Dictionary<GameObject, float>();
    }
    private void Start()
    {
        l_Joueurs = GameObject.FindGameObjectsWithTag("Player");
    }

    private void Update()
    {
        dtShoot += Time.deltaTime;

        if (dtShoot > intervalEntre2Tirs)
        {
            isReadyToShoot = true;
        }
        //turn raycast
        foreach (GameObject p in l_Joueurs)
        {
            RaycastHit hitTurn;
            if (Physics.Raycast(transform.position, Vector3.Normalize(p.transform.position - transform.position), out hitTurn, rayDistance))
            {
                if (hitTurn.collider.gameObject.CompareTag("Player"))
                {
                    transform.LookAt(hitTurn.transform);
                    if (isReadyToShoot)
                    {
                        isReadyToShoot = false;
                        dtShoot = 0;
                        print("Shoot");
                        GameObject b = Instantiate(Bullet, bulletTransform);
                        l_Bullet.Add(b, 0);
                    }
                }
            }
        };               

        List<GameObject> bulletToDestroy = new List<GameObject>();
        List<GameObject> bulletToInc = new List<GameObject>();
        foreach (KeyValuePair<GameObject,float> bullet in l_Bullet)
        {
            if (bullet.Value > rayDistance)
            {
                bulletToDestroy.Add(bullet.Key);
                Destroy(bullet.Key);
            }
            else
            {
                bulletToInc.Add(bullet.Key);
                (bullet.Key).transform.position += speedBullet * Time.deltaTime * (bullet.Key).transform.up;
            }
        }
        foreach (GameObject b in bulletToInc)
        {
            l_Bullet[b] += speedBullet * Time.deltaTime;
        }

        foreach (GameObject b in bulletToDestroy)
        {
            l_Bullet.Remove(b);
        }
    }

    public void ShootBullet()
    {
        if (dtShoot > intervalEntre2Tirs)
        {
            dtShoot = 0;
            if (GetComponent<AudioSource>())
            {
                GetComponent<AudioSource>().enabled = true;
                GetComponent<AudioSource>().Play();
            }
            GameObject b = Instantiate(Bullet, bulletTransform);
            l_Bullet.Add(b, 0);
        }
    }

}

