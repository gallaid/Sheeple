using UnityEngine;
using System.Collections;

public class PlayerSpawnMang : MonoBehaviour {
    public GameObject MaleBull;
    public GameObject Femalebull;
    public GameObject MalePasthulu;
    public GameObject FemalePasthulu;
    GameObject SpawnPoint;


	// Use this for initialization
	void Start () {
        SpawnPoint=GameObject.FindGameObjectWithTag("SpawnPoint");
        // MaleBull=GameObject.Find("MaleBull");
        spawn();
	
	}
    void spawn()
    {
        if (GameStates.Bull == true)
        {
            if (GameStates.male == true)
            {
                print("jeje");
                Instantiate(MaleBull, SpawnPoint.transform.position, SpawnPoint.transform.rotation);
                //spawn male bull
            }
            else {
                Instantiate(Femalebull, SpawnPoint.transform.position, SpawnPoint.transform.rotation);
            }//spawn female bull
        }
        else
        {
            if (GameStates.male == true)
            {
                Instantiate(MalePasthulu, SpawnPoint.transform.position, SpawnPoint.transform.rotation);
                //spawn pasthulu male
            }
            else {
                Instantiate(FemalePasthulu,SpawnPoint.transform.position, SpawnPoint.transform.rotation);
            } //spawn pathulu female
        }
    }
	

}
