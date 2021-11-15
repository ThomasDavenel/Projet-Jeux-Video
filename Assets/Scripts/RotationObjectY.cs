using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationObjectY : MonoBehaviour
{
    public float rotation;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, rotation, 0);
    }
}
