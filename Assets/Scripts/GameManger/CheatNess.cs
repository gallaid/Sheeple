using UnityEngine;
using System.Collections;

public class CheatNess : MonoBehaviour {


	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown(KeyCode.P))
        {
            GameStates.Population += 1;
        }
	
	}
}
