using UnityEngine;
using System.Collections;

public class CameraManager : MonoBehaviour {
    Camera cam;
    GameObject player;



    void Awake()
    {
        cam = GetComponent<Camera>();
        player = GameObject.FindGameObjectWithTag("Player");

        cam.orthographicSize = 45;
        cam.transform.position = new Vector3(0, 100, 0);
        cam.transform.eulerAngles = new Vector3(90, 0, 0);
    }
	// Use this for initialization
	void Start () {




    }
	
	// Update is called once per frame
	void Update () {

        if (player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player");
        }
        cam.transform.position = new Vector3(player.transform.position.x, 100, player.transform.position.z);
        
	
	}
}
