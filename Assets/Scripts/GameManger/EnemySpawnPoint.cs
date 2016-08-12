using UnityEngine;
using System.Collections;

public class EnemySpawnPoint : MonoBehaviour {

    public GameObject bull;
    public GameObject pasthulu;

	void Start () {
        GameObject sp = gameObject;
        if (GameStates.Bull == true)
        {
            Instantiate(pasthulu, sp.transform.position, sp.transform.rotation);
        }
        else
        {
            Instantiate(bull, sp.transform.position, sp.transform.rotation);
        }


	}
	

}
