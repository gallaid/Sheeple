using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class toBar : MonoBehaviour
{

    void OnTriggerEnter(Collider thing)
    {
        if (thing.gameObject.tag == "Player")
        {
            GameStates.SpawnLocation = SpawnLocation.Bar;
            SceneManager.LoadScene("Bar");
        }

    }

}

