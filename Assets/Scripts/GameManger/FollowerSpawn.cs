using UnityEngine;
using System.Collections;

public class FollowerSpawn : MonoBehaviour {
    public GameObject Follower;

    //-22x 118y 45x 90y

	void Start () {

        int population = GameStates.Population;
        //float ranx = Random.Range(-22, 45);
        //float ranz = Random.Range(90, 118);

        for(int i = 0; i< population; i++)
        {
            float ranx = Random.Range(-22, 45);
            float ranz = Random.Range(90, 118);
            Vector3 randomv3 = new Vector3(ranx, 2, ranz);
            Instantiate(Follower, randomv3, Quaternion.identity);
        }
	
	}
	

}
