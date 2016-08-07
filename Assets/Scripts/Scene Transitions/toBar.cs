using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class toBar : MonoBehaviour
{

    void OnCollisionEnter(Collision thing)
    {
        if (thing.gameObject.tag == "Player")
        {
            SceneManager.LoadScene("Bar");
        }

    }

}

