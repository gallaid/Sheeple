using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class RoomSwitch3 : MonoBehaviour
{

    void OnCollisionEnter2D(Collision2D thing)
    {
        if (thing.gameObject.tag == "Player")
        {
            SceneManager.LoadScene("Bar");
        }

    }

}

