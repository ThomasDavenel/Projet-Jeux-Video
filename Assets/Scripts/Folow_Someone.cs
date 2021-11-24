using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Folow_Someone : MonoBehaviour
{
    public Transform ObjectToFolow;

    public Vector3 view;
    public Vector3 offset;
    private GameObject objToFollow;
    private void Awake()
    {
        objToFollow = new GameObject();
    }
    // Update is called once per frame
    void Update()
    {
        this.gameObject.transform.position = ObjectToFolow.position + view;
        objToFollow.transform.position = ObjectToFolow.position + offset;
        this.transform.LookAt(objToFollow.transform);
    }
}
