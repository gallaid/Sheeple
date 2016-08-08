using UnityEngine;
using System.Collections;

public class SimonSaysTake1 : MonoBehaviour {
    public SpriteRenderer NPCBubble;
    public SpriteRenderer PlayerBubble;
    public Sprite[] RGB;
    
    public int[] numberCombo;

    enum MiniState {NPCDISPLAY, PLAYERGUESS, RESETPUZZLE, WIN, LOSE};
    MiniState miniState;
    enum DisplayState {SHOW1, SHOW2, SHOW3, END};
    DisplayState displayState;
  
    private int wincounter=0;
    public int winNeeds = 2;

    private int loseCounter = 0;
    public int loseNeeds = 2;
    public float Waittime = 4f;
    float boom = 0;
    bool hasOne = false;
    


	// Use this for initialization
	void Start () {
        miniState = MiniState.NPCDISPLAY;
        numberCombo = new int[3];
	
	}



    void Update () {

        switch(miniState)
        {
            case MiniState.NPCDISPLAY:
                switch(displayState)
                {
                case DisplayState.SHOW1:

                        if (bam())
                        {
                            if (!hasOne)
                            {
                                int randomnumber = randomNum();
                                numberCombo[0] = randomnumber;

                                NPCBubble.sprite = RGB[randomnumber];
                                print(randomnumber);
                                hasOne = true;
                            }

                        }
                        else {
                            displayState = DisplayState.SHOW2;
                            hasOne = false;
                        }
                    break;
                case DisplayState.SHOW2:
                        if (bam())
                        {
                            if (!hasOne)
                            {
                                int randomnumber = randomNum();
                                numberCombo[1] = randomnumber;

                                NPCBubble.sprite = RGB[randomnumber];
                                //print(randomnumber);
                                hasOne = true;
                            }

                        }
                        else
                        {
                            displayState = DisplayState.SHOW2;
                            hasOne = false;
                        }
                        break;
                    case DisplayState.SHOW3:
                        if (bam())
                        {
                            if (!hasOne)
                            {
                                int randomnumber = randomNum();
                                numberCombo[2] = randomnumber;

                                NPCBubble.sprite = RGB[randomnumber];
                                print(randomnumber);
                                hasOne = true;
                            }

                        }
                        else
                        {
                            displayState = DisplayState.SHOW2;
                            hasOne = false;
                        }
                        break;
                    case DisplayState.END:
                        NPCBubble.sprite = RGB[3];
                        miniState = MiniState.PLAYERGUESS;
                        displayState = DisplayState.SHOW1;

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
                        if (Input.anyKeyDown)
                        {
                            string keyDown = Input.inputString;
                            if (keyDown == numberCombo[0].ToString())
                            {
                                //correct key
                                print("rightkey");
                            } else
                            {
                                loseCounter++;
                                miniState = MiniState.RESETPUZZLE;
                            }
                         }                 
                        break;
                    case DisplayState.SHOW2:
                        if (Input.anyKeyDown)
                        {
                            string keyDown = Input.inputString;
                            if (keyDown == numberCombo[1].ToString())
                            {
                                //correct key
                                print("rightkey");
                            }
                            else
                            {
                                loseCounter++;
                                miniState = MiniState.RESETPUZZLE;
                            }
                        }
                        break;
                    case DisplayState.SHOW3:
                        if (Input.anyKeyDown)
                        {
                            string keyDown = Input.inputString;
                            if (keyDown == numberCombo[2].ToString())
                            {
                                //correct key
                                print("rightkey");
                            }
                            else
                            {
                                loseCounter++;
                                miniState = MiniState.RESETPUZZLE;
                            }
                        }
                        break;
                    case DisplayState.END:
                        displayState = DisplayState.SHOW1;
                        miniState = MiniState.PLAYERGUESS;
                        wincounter++;
                        break;
                    default:
                        print("Das Error(PLAYERGUESS.displayState)");
                        break;
                }
                break;
            case MiniState.RESETPUZZLE:
                if (wincounter >= winNeeds)
                {
                    miniState = MiniState.WIN;
                    break;
                }
                if (loseCounter >= loseNeeds)
                {
                    miniState = MiniState.LOSE;
                    break;
                }
                    miniState = MiniState.NPCDISPLAY;
                
                break;
            case MiniState.WIN:
                //conver
                break;
            case MiniState.LOSE:
                //lose beief
                break;
            default:
                print("Das Error(miniState)");
                break;
        }
        
	
	}
    int randomNum() { return Random.Range(1, 3); }

    bool bam()
    {
        
        if (Waittime > boom)
        {
            boom += 0.5f;
            return true;
        }
        else
        {
            boom = 0;
            return false;
        }
    }

}
