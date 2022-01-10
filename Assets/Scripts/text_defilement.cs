using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class text_defilement : MonoBehaviour
{
    private float scrollSpeed = 4.3f;
    public GameObject m_camera;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<TextMeshPro>().color = new Color(0, 0, 0, 0);
    }

    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    // Update is called once per frame
    void Update()
    {
        if (m_camera.transform.position.z > -50)
        {
            GetComponent<TextMeshPro>().color = new Color(0, 0.7766089f, 1, 1);
            GetComponent<AudioSource>().enabled = true;

            Vector3 pos = transform.position;
            Vector3 localVectorUp = transform.TransformDirection(0, 1, 0);
            pos += localVectorUp * scrollSpeed * Time.deltaTime;
            transform.position = pos;

            if (!GetComponent<AudioSource>().isPlaying) LoadScene("Scene_Guilaume");
        }
        else m_camera.transform.position = new Vector3(m_camera.transform.position.x, m_camera.transform.position.y, m_camera.transform.position.z + 0.4f);
    }
}
