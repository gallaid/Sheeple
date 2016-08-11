using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class toOffice : MonoBehaviour
{

    void OnTriggerEnter(Collider thing)
    {
        if (thing.gameObject.tag == "Player")
        {
            GameStates.SpawnLocation = SpawnLocation.Office;
            SceneManager.LoadScene("Office");
        }

    }

}

