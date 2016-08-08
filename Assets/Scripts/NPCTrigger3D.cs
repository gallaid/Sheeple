using UnityEngine;
using System.Collections;

public class NPCTrigger3D : MonoBehaviour {

    // Update is called once per frame


    void OnTriggerEnter(Collider thing)
    {
        if (thing.gameObject.tag == "Player")
        {

        }
    }


}
