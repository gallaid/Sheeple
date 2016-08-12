using UnityEngine;
using System.Collections;

[RequireComponent (typeof(CharacterController))]
public class PlayerController : MonoBehaviour {
    public float speed;
        public Sprite[] Directions = new Sprite[4];
    SpriteRenderer rs;

    CharacterController control;

    public static PlayerController pcontrol {
        get { return yourworstnightmarescomereal; }
    }

    private static PlayerController yourworstnightmarescomereal;
    void Awake()
    {
        yourworstnightmarescomereal = this;
        control = transform.GetComponent<CharacterController>();




    }

    void Start()
    {

        SpriteRenderer[] PCSprites = new SpriteRenderer[3];
        PCSprites = GetComponentsInChildren<SpriteRenderer>();

        foreach (SpriteRenderer sprite in PCSprites)
        {
            if (sprite.name == "PlayerMBack")
            {
                rs = sprite;
                //print("here");
            }
        }
    }

    void Update()
    {
       // print(Input.GetAxis("Vertical") + " vert");
       // print(Input.GetAxis("Horizontal") + " hor");
        if (Input.GetAxis("Vertical") > 0)
        {
            rs.sprite = Directions[0];
        }
        else if (Input.GetAxis("Vertical") < 0)
        {
            rs.sprite = Directions[1];
        }
        else if (Input.GetAxis("Horizontal") > 0)
        {
            rs.sprite = Directions[2];
        }
        else if (Input.GetAxis("Horizontal") < 0)
        {
            rs.sprite = Directions[3];
        }



        Vector2 inputs = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        Vector3 moveVector = new Vector3(inputs.x, 0, inputs.y);

        control.Move(moveVector.normalized * speed * Time.deltaTime);
    }

}
