using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class defilement_text : MonoBehaviour
{
    private string scenar;
    private string path;
    private Vector2 scrollposition = Vector2.zero;
    private float nblines = 5.1f;

    public GameObject m_camera;
    // Start is called before the first frame update
    void Start()
    {
        path = Application.dataPath + "/Scripts/scenar.txt";
        if(File.Exists(path))
        {
            scenar = File.ReadAllText(path);
        }
    }

    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    void OnGUI()
    {
        if (m_camera.transform.position.z > -50)
        {
            GetComponent<AudioSource>().enabled = true;
            scrollposition.y += 8.0f * Time.deltaTime;
            if (scrollposition.y > nblines * 90) LoadScene("Menu");

            GUI.contentColor = new Color(0.384313725f, 0.729411765f, 1);
            
            GUI.BeginScrollView(new Rect(Screen.width * 0.2f, Screen.height * 0.57f, Screen.width * 0.65f, Screen.height * 0.4f), scrollposition, new Rect(0, -150, 500, nblines * 130));
            GUI.Label(new Rect(0, 50, 680, nblines * 60), scenar);
            GUI.skin.label.fontSize = 20;
            GUI.EndScrollView();
        }
        else m_camera.transform.position = new Vector3(m_camera.transform.position.x, m_camera.transform.position.y, m_camera.transform.position.z + 0.4f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
