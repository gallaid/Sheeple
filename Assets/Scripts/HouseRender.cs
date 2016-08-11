using UnityEngine;
using System.Collections;

public class HouseRender : MonoBehaviour {

    public GameObject BullHead,
        PastaHat; 

	// Use this for initialization
	void Start () {

       
        if (GameStates.Bull)
        {
            Instantiate(BullHead, GameObject.FindGameObjectWithTag("BullHouse").transform.position, GameObject.FindGameObjectWithTag("BullHouse").transform.rotation, GameObject.FindGameObjectWithTag("BullHouse").transform);
        }
        else
        {
            Instantiate(PastaHat, GameObject.FindGameObjectWithTag("PastaHouse").transform.position, GameObject.FindGameObjectWithTag("PastaHouse").transform.rotation, GameObject.FindGameObjectWithTag("PastaHouse").transform);
        }
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
