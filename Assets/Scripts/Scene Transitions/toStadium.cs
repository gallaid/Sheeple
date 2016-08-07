using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class toStadium : MonoBehaviour
{

    void OnTriggerEnter(Collider thing)
    {
        if (thing.gameObject.tag == "Player")
        {
            SceneManager.LoadScene("Stadium");
        }

    }

}

