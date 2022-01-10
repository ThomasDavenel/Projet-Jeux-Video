using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    GameObject parent;
    private void Awake()
    {
        parent = GameObject.FindGameObjectWithTag("ListBullet");
        transform.SetParent(parent.transform);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<Player>().hitted();
        }
        else if (collision.gameObject.CompareTag("Enemy"))
        {
            collision.gameObject.GetComponent<Enemy>().hitted();
        }
        Debug.Log(collision.gameObject.name);
        GetComponent<MeshRenderer>().enabled = false;
    }
}
