using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move_item : MonoBehaviour
{
    public float mvmt_spd;
    public float mvmt_dist;
    private Vector3 _startPosition;

    void Start()
    {
        mvmt_spd = 2;
        mvmt_dist = 5;
        _startPosition = transform.position;
    }

    void Update()
    {
        transform.position = _startPosition + new Vector3(0.0f, Mathf.Sin(Time.time*mvmt_spd)/mvmt_dist, 0.0f);
    }
}
