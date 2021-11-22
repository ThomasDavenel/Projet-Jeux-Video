using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class defilement_text : MonoBehaviour
{
    private string scenar;
    private string path;
    private Vector2 scrollposition = Vector2.zero;
    private int nblines = 4;

    // Start is called before the first frame update
    void Start()
    {
        path = Application.dataPath + "/Scripts/scenar.txt";
        if(File.Exists(path))
        {
            scenar = File.ReadAllText(path);
        }
    }

    void OnGUI()
    {
        scrollposition.y += 5.0f * Time.deltaTime;
        if (scrollposition.y > nblines*50) scrollposition.y = 0.0f;

        GUI.contentColor = new Color(0.384313725f, 0.729411765f, 1);
        GUI.BeginScrollView(new Rect(0, 0, 500, 200), scrollposition, new Rect(0, 0, 500, nblines*50), false, true);
        GUI.Label(new Rect(0, 50, 500, nblines*50), scenar);
        GUI.EndScrollView();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}