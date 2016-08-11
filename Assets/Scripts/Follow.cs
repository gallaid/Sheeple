using UnityEngine;
using System.Collections;

public class Follow : MonoBehaviour {

    GameObject player;
    public float speed;
    public float distance;
    
	// Use this for initialization
	void Start () {
        player = GameObject.FindWithTag("Player");
        
	}
	
	// Update is called once per frame
	void Update () {
        if (player == null)
        {
            player = GameObject.FindWithTag("Player");
        }
        if (Vector3.Distance(player.transform.position,transform.position) >= distance)
        MoveTo();
	
	}
    void MoveTo()
    {
        float step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, player.gameObject.transform.position, step);
    }
}
