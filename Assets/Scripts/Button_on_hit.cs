using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button_on_hit : MonoBehaviour
{
    public List<GameObject> objectsToToggle;
    public Texture textureActive;
    public Texture textureInactive;
    public float timeActive;

    private Material m_Material;
    private bool active;
    private float timeSinceActive;

    void Start()
    {
        m_Material = GetComponent<Renderer>().material;
        timeSinceActive = 0f;
        active = false;
    }

    private void OnTriggerEnter(Collider collid)
    {
        foreach (GameObject obj in objectsToToggle)
        {
            if (obj.activeSelf)
            {
                obj.SetActive(false);
            }
            else { obj.SetActive(true); }  
        }
        m_Material.SetTexture("_MainTex", textureActive);
        active = true;
    }

    private void Update()
    {
        if (active)
        {
            timeSinceActive += Time.deltaTime;
            if(timeSinceActive >= timeActive)
            {
                m_Material.SetTexture("_MainTex", textureInactive);
                active = false;
                timeSinceActive=0f;
            }
        }
    }
}