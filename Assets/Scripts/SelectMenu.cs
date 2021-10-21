using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectMenu : MonoBehaviour
{
    private Vector3 mousePos;
    public List<GameObject> buttonPos;
    public float buttonWidth;
    public float buttonHeight;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        mousePos = Input.mousePosition;

        //new game button
        if (mousePos.x > buttonPos[0].transform.position.x - buttonWidth && mousePos.x < buttonPos[0].transform.position.x + buttonWidth)
        {
            if (mousePos.y > buttonPos[0].transform.position.y - buttonHeight && mousePos.y < buttonPos[0].transform.position.y + buttonHeight)
            {
                transform.position = buttonPos[0].transform.position;
            }
        }

        //load game button
        if (mousePos.x > buttonPos[1].transform.position.x - buttonWidth && mousePos.x < buttonPos[1].transform.position.x + buttonWidth)
        {
            if (mousePos.y > buttonPos[1].transform.position.y - buttonHeight && mousePos.y < buttonPos[1].transform.position.y + buttonHeight)
            {
                transform.position = buttonPos[1].transform.position;
            }
        }

        //controls button
        if (mousePos.x > buttonPos[2].transform.position.x - buttonWidth && mousePos.x < buttonPos[2].transform.position.x + buttonWidth)
        {
            if (mousePos.y > buttonPos[2].transform.position.y - buttonHeight && mousePos.y < buttonPos[2].transform.position.y + buttonHeight)
            {
                transform.position = buttonPos[2].transform.position;
            }
        }

        //quit button
        if (mousePos.x > buttonPos[2].transform.position.x - buttonWidth && mousePos.x < buttonPos[2].transform.position.x + buttonWidth)
        {
            if (mousePos.y > buttonPos[2].transform.position.y - buttonHeight && mousePos.y < buttonPos[2].transform.position.y + buttonHeight)
            {
                transform.position = buttonPos[2].transform.position;
            }
        }
    }
}
