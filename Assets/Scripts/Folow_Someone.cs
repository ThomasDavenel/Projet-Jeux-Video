using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Folow_Someone : MonoBehaviour
{
    public Transform ObjectToFolow;

    public Vector3 view;
    // Update is called once per frame
    void Update()
    {
        this.gameObject.transform.position = ObjectToFolow.position + view;
        this.transform.LookAt(ObjectToFolow);
    }
}
