using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectMenu : MonoBehaviour
{
    Vector3 mousePos = Input.mousePosition;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //new game button
        if(mousePos.x > 282.7f && mousePos.x < 442.7 && mousePos.y > 19 && mousePos.y < 49)
        {
            transform.position = new Vector3(mousePos.x, mousePos.y, transform.position.z);
        }

        //load game button
        if (mousePos.x > 282.7f && mousePos.x < 442.7 && mousePos.y > -36 && mousePos.y < -6)
        {

        }

        //controls button
        if (mousePos.x > 282.7f && mousePos.x < 442.7 && mousePos.y > -90 && mousePos.y < -60)
        {

        }

        //quit button
        if (mousePos.x > 282.7f && mousePos.x < 442.7 && mousePos.y > -145 && mousePos.y < -115)
        {

        }
    }
}
