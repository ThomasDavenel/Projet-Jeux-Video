using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class activer_courant : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("oui");
    }

    // Update is called once per frame
    void Update()
    {
        //if (GetComponent<BoxCollider>().isTrigger) Debug.Log("oui");
    }
}
