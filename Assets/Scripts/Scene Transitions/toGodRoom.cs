using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class toGodRoom : MonoBehaviour
{

    void OnTriggerEnter(Collider thing)
    {
        //print("Hello");
        if (thing.gameObject.tag == "Player")
        {
            GameStates.SpawnLocation = SpawnLocation.CultHouse;
            GameStates.CheckGameState();
            if (GameStates.getgameState == Gamestate.BEGIN)
            {
                SceneManager.LoadScene("GodRoom1");
            } else if (GameStates.getgameState == Gamestate.MED)
            {
                SceneManager.LoadScene("GodRoom2");
            } else if (GameStates.getgameState == Gamestate.ADV)
            {
                SceneManager.LoadScene("GodRoom3");
            }
            
            
        }

    }

}

