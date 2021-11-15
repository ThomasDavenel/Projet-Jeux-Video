using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SelectMenu : MonoBehaviour, IPointerEnterHandler
{
    public GameObject bandeau;

    // Start is called before the first frame update
    void Start()
    {
        bandeau.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        bandeau.SetActive(true);
        bandeau.transform.position = transform.position;
    }
}
