using UnityEngine;
using System.Collections;

public class CathedralSetup : MonoBehaviour {

    public Sprite bull;
    public Sprite spagiti;
    void Start()
    {



        print(GameStates.bull);
        SpriteRenderer godPic = GetComponent<SpriteRenderer>();
        if (GameStates.Bull == false)
        {
            //print(GameStates.Bull);
            godPic.sprite = bull;
        }
        else godPic.sprite = spagiti;

    }
}
