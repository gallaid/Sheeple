using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class toCathedral : MonoBehaviour
{

    void OnTriggerEnter(Collider thing)
    {
        if (thing.gameObject.tag == "Player")
        {
            if (GameStates.getgameState == Gamestate.END)
            {
                GameStates.SpawnLocation = SpawnLocation.Cathedral;
                SceneManager.LoadScene("Cathedral");
            }
            
        }

    }

}

