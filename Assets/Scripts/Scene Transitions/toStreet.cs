using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class toStreet : MonoBehaviour
{

    void OnCollisionEnter(Collision thing)
    {
        if (thing.gameObject.tag == "Player")
        {
            SceneManager.LoadScene("Street");
        }

    }

}

