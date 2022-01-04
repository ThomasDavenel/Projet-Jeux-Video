using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button_on_hit : MonoBehaviour
{
    public GameObject ObjectToAppear;
    public Texture NewTexture;

    private Material m_Material;

    void Start()
    {
        m_Material = GetComponent<Renderer>().material;
    }

        private void OnTriggerEnter(Collider collid)
    {
        ObjectToAppear.SetActive(true);
        m_Material.SetTexture("_MainTex", NewTexture);
    }
}
