using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    GameObject parent;
    public bool bulletPlayer;
    private void Awake()
    {
        parent = GameObject.FindGameObjectWithTag("ListBullet");
        if(!bulletPlayer) gameObject.transform.SetParent(parent.transform);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player") && !bulletPlayer)
        {
            collision.gameObject.GetComponent<Player>().hitted();
        }
        else if (collision.gameObject.CompareTag("Enemy") && bulletPlayer)
        {
            collision.gameObject.GetComponent<Enemy>().hitted();
        }
        Debug.Log(collision.gameObject.name);
        if( !( (collision.gameObject.CompareTag("Player") && bulletPlayer) || (collision.gameObject.CompareTag("Enemy") && !bulletPlayer)) ) gameObject.SetActive(false);
    }
}
