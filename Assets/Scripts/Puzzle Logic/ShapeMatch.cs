using UnityEngine;
using System.Collections;

public class ShapeMatch : MonoBehaviour {

    enum MiniState {NPCDISPLAY, PLAYERGUESS, RESETPUZZLE, WIN, LOSE};
    MiniState miniState;
    enum DisplayState {SHOW1, SHOW2, SHOW3, END};
    DisplayState displayState;
    int time;



	// Use this for initialization
	void Start () {
        miniState = MiniState.NPCDISPLAY;
	
	}
	
	// Update is called once per frame
	void Update () {
        //time = timeGetTime()
        switch(miniState)
        {
            case MiniState.NPCDISPLAY:
                switch(displayState)
                {
                case DisplayState.SHOW1:
                    break;
                case DisplayState.SHOW2:
                    break;
                case DisplayState.SHOW3:
                    break;
                case DisplayState.END:
                    displayState = DisplayState.SHOW1;
                    miniState = MiniState.PLAYERGUESS;
                    break;
                default:
                    print("Das Error(NPCDISPLAY.displayState");
                    break;
                }
                break;
            case MiniState.PLAYERGUESS:
                switch (displayState)
                {
                    case DisplayState.SHOW1:
                        //if (time < changetime) 
                        //show first color for time
                        //else displayState = Displaystate.SHOW2
                        break;
                    case DisplayState.SHOW2:
                        break;
                    case DisplayState.SHOW3:
                        break;
                    case DisplayState.END:
                        displayState = DisplayState.SHOW1;
                        miniState = MiniState.PLAYERGUESS;
                        break;
                    default:
                        print("Das Error(PLAYERGUESS.displayState)");
                        break;
                }
                break;
            case MiniState.RESETPUZZLE:
                //if wincounter != enough
                {
                    //Update win counter
                    //randomize and clear puzzle arrays.
                    miniState = MiniState.PLAYERGUESS;
                }
                //else win
                break;
            case MiniState.WIN:
                break;
            case MiniState.LOSE:
                break;
            default:
                print("Das Error(miniState)");
                break;
        }
	
	}

}
