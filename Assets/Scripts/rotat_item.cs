using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotat_item : MonoBehaviour
{

    public float rot_spd;
    private Vector3 _startRotation;

    void Start()
    {
        rot_spd = 90;
        _startRotation = transform.eulerAngles;
    }

    // Update is called once per frame
    void Update()
    {
        transform.eulerAngles = _startRotation + new Vector3(0.0f, rot_spd*Time.time, 0.0f);
    }
}
