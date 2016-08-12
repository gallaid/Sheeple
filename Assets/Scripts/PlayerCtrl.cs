using UnityEngine;
using System.Collections;

public class PlayerCtrl : MonoBehaviour {
    Animator anim;
    public Sprite[] Directions = new Sprite[4];
    SpriteRenderer rs;
	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
        SpriteRenderer[] PCSprites = new SpriteRenderer[3];
        PCSprites = GetComponentsInChildren<SpriteRenderer>();
        
        foreach (SpriteRenderer sprite in PCSprites)
        {
            if (sprite.name == "Sprite")
            {
                rs = sprite;
                //print("here");
            }
        }

    }

    // Update is called once per frame
     public float speed = 2.0f;
 
    void Update()
    {

        if (Input.GetAxis("Vertical") > 0)
        {
            rs.sprite = Directions[0];
        }else if (Input.GetAxis("Vertical")<0)
        {
            rs.sprite = Directions[1];
        }else if (Input.GetAxis("Horizontal") > 0)
        {
            rs.sprite = Directions[2];
        }else if (Input.GetAxis("Horizontal") < 0)
        {
            rs.sprite = Directions[3];
        }


        var move = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0);
        transform.position += move * speed * Time.deltaTime;
      

        //if (Input.anyKey)
        //    anim.SetBool("IsWalking", true);
        //else anim.SetBool("IsWalking", false);

    }

}
