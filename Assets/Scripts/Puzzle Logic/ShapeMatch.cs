using UnityEngine;
using System.Collections;

public class ShapeMatch : MonoBehaviour {

    enum MiniState {NPCDISPLAY, PLAYERGUESS, RESETPUZZLE, WIN, LOSE};
    MiniState miniState;



	// Use this for initialization
	void Start () {
        miniState = MiniState.NPCDISPLAY;
	
	}
	
	// Update is called once per frame
	void Update () {
        switch(miniState)
        {
            case MiniState.NPCDISPLAY:
                break;
            case MiniState.PLAYERGUESS:
                break;
            case MiniState.RESETPUZZLE:
                break;
            case MiniState.WIN:
                break;
            case MiniState.LOSE:
                break;
            default:
                break;
        }
	
	}
}
