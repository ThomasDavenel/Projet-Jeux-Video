using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class delete_item_on_touch : MonoBehaviour
{
    public GameObject pickup_sound;
    public InputController inputController;

    private void OnTriggerEnter(Collider collid)
    {
        inputController.havePistol = true;
        pickup_sound.SetActive(true);
        Destroy(gameObject);
    }
}
