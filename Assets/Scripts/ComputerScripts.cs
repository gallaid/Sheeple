using UnityEngine;
using System.Collections;

public class ComputerScripts : MonoBehaviour {

    public Canvas MissionStatus;
    void OnTriggerEnter2D(Collider2D other)
    {
        //print(other.gameObject.name);
        
        if (other.gameObject.name== "Tablet")
        {
            MissionStatus.enabled = true;
        }
        
    }
    void OnTriggerExit2D(Collider2D other)
    {
        print("hello");
        if (other.gameObject.name == "Tablet")
        {
            MissionStatus.enabled = false;
        }
    }


}
