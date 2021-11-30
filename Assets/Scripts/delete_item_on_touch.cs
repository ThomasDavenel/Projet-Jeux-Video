using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class delete_item_on_touch : MonoBehaviour
{
    private void OnTriggerEnter(Collider collid)
    {
        Destroy(gameObject);
    }
}
