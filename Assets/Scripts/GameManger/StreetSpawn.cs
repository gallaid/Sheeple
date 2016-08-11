using UnityEngine;
using System.Collections;

public class StreetSpawn : MonoBehaviour {
    public GameObject MaleBull;
    public GameObject Femalebull;
    public GameObject MalePasthulu;
    public GameObject FemalePasthulu;
    

    SpawnLocation SP = GameStates.SpawnLocation;

    // Use this for initialization
    void Start()
    {
        GameObject SpawnHere;
        if (SP == SpawnLocation.Bar)
        {
            SpawnHere = GameObject.FindGameObjectWithTag("BarSpawn");
            spawn(SpawnHere);
            //spawnatbar
        }else if (SP == SpawnLocation.Cathedral)
        {
            SpawnHere = GameObject.FindGameObjectWithTag("CathedralSpawn");
            spawn(SpawnHere);

            //spawn chath
        }
        else if (SP == SpawnLocation.CultHouse)
        {
            SpawnHere = GameObject.FindGameObjectWithTag("CultHouseSpawn");
            spawn(SpawnHere);
            //spawnCulthouse
        }
        else if (SP == SpawnLocation.Office)
        {
            SpawnHere = GameObject.FindGameObjectWithTag("OfficeSpawn");
            spawn(SpawnHere);
            //spawn at office
        }
        

        



    }
    void spawn(GameObject SpawnPoint)
    {
        if (GameStates.Bull == true)
        {
            if (GameStates.IsMale == true)
            {

                Instantiate(MaleBull, SpawnPoint.transform.position, SpawnPoint.transform.rotation);
                //spawn male bull
            }
            else {
                Instantiate(Femalebull, SpawnPoint.transform.position, SpawnPoint.transform.rotation);
            }//spawn female bull
        }
        else
        {
            if (GameStates.IsMale == true)
            {
                Instantiate(MalePasthulu, SpawnPoint.transform.position, SpawnPoint.transform.rotation);
                //spawn pasthulu male
            }
            else {
                Instantiate(FemalePasthulu, SpawnPoint.transform.position, SpawnPoint.transform.rotation);
            }
        }
    }



}
