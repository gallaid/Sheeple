using UnityEngine;
using System.Collections;

public class GodRoomPicture : MonoBehaviour {

    public Sprite bull;
    public Sprite spagiti;
    void Start() {



        //print(GameStates.Bull);
    SpriteRenderer godPic = GetComponent<SpriteRenderer>();
        if (GameStates.Bull == true)
        {
            print(GameStates.Bull);
            godPic.sprite = bull;
        }
        else godPic.sprite = spagiti;

    }

}
