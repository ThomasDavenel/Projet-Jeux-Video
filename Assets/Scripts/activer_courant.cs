using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class activer_courant : MonoBehaviour
{
    public TextMeshPro text;
    public GameObject axe;
    public List<Light> lumieres;
    private bool isActive;
    private bool isEnter;
    
    // Start is called before the first frame update
    void Start()
    {
        text.color = new Color(0, 0, 0, 0);
        isActive = false;
        isEnter = false;
    }

    private void OnTriggerEnter(Collider collider)
    {
        if(collider.gameObject.tag == "levier")
        {
            text.color = new Color(0, 0.4331563f, 1, 1);
            isEnter = true;
        }
    }

    private void OnTriggerExit(Collider collider)
    {
        text.color = new Color(0, 0, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if(isEnter)
        {
            if (Input.GetKeyDown("e"))
            {
                text.enabled = false;
                GetComponent<AudioSource>().enabled = true;
                isActive = true;
            }
        }
        if(isActive)
        {
            axe.GetComponent<Animator>().enabled = true;
            foreach(Light l in lumieres)
            {
                l.intensity = 3;
            }
        }
    }
}
