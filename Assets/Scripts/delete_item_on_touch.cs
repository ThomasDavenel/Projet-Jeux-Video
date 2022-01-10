using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class delete_item_on_touch : MonoBehaviour
{
    public GameObject pickup_sound;

    private void OnTriggerEnter(Collider collid)
    {
        pickup_sound.SetActive(true);
        Destroy(gameObject);
    }
}
