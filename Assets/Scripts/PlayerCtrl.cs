using UnityEngine;
using System.Collections;

public class PlayerCtrl : MonoBehaviour {
    Animator anim;
	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
	}

    // Update is called once per frame
     public float speed = 2.0f;
 
    void Update()
    {
        var move = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0);
        transform.position += move * speed * Time.deltaTime;
      

        if (Input.anyKey)
            anim.SetBool("IsWalking", true);
        else anim.SetBool("IsWalking", false);

    }

}
