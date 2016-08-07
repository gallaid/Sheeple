using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class toGodRoom : MonoBehaviour
{

    void OnTriggerEnter(Collider thing)
    {
        print("Hello");
        if (thing.gameObject.tag == "Player")
        {
            SceneManager.LoadScene("GodRoom1");
        }

    }

}

