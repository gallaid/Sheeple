using UnityEngine;
using System.Collections;

[RequireComponent (typeof(CharacterController))]
public class PlayerController : MonoBehaviour {
    public float speed;

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

    void Update()
    {
        Vector2 inputs = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        Vector3 moveVector = new Vector3(inputs.x, 0, inputs.y);

        control.Move(moveVector.normalized * speed * Time.deltaTime);
    }

}
