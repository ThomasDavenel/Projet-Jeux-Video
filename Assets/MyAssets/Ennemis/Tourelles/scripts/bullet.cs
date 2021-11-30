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
        GetComponent<MeshRenderer>().enabled = false;
    }
}
