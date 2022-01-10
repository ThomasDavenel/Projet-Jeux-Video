using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Sortie : MonoBehaviour
{
    private void OnTriggerEnter(Collider collid)
    {
        SceneManager.LoadScene("SceneVictoire");
    }
}
