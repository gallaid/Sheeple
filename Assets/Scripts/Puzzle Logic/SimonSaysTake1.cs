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
    public int Waittime;

    bool NeedColor = true;
    bool waitingtoend=true;
    



    // Use this for initialization
    void Start()
    {
        miniState = MiniState.NPCDISPLAY;
        numberCombo = new int[3];

        SpriteRenderer[] NPCSprites = new SpriteRenderer[3];
        NPCSprites = GetComponentsInChildren<SpriteRenderer>();
        foreach (SpriteRenderer sprite in NPCSprites)
        {
            if (sprite.name == "Speech Bubble")
            {
                NPCBubble = sprite;
                //print("here");
            }
        }
        SpriteRenderer[] PlayerSprites = new SpriteRenderer[3];
        PlayerSprites = GameObject.FindGameObjectWithTag("Player").GetComponentsInChildren<SpriteRenderer>();
        foreach (SpriteRenderer pic in PlayerSprites)
        {
            //print(pic.name);
            if (pic.name == "ChatBox")
            {
                //print("Found CB");
                PlayerBubble = pic;
            }

        }

        
    }



    void Update () {
        game();
	
	}

    int randomNum() { return Random.Range(1, 3); }

    bool AmIwaiting()
    {
        if (waitingtoend)
        {
            return true;
        }
        else return false;
 
    }

   
    IEnumerator Wait()
    {
        waitingtoend = true;
        yield return new WaitForSeconds(Waittime);
        print("afterwait");
        waitingtoend = false;
    }
    void game()
    {
        switch (miniState)
        {
            case MiniState.NPCDISPLAY:
                switch (displayState)
                {
                    case DisplayState.SHOW1:
                        print(NeedColor + "bam");

                        if (NeedColor)
                        {

                            //get color
                            int randomnumber = randomNum();
                            numberCombo[0] = randomnumber;

                            NPCBubble.sprite = RGB[randomnumber];
                            NeedColor = false;

                        }
                        else if (AmIwaiting())
                        {
                            //stay here
                        }
                        else {
                            displayState = DisplayState.SHOW2;
                            NeedColor = true;
                        }
                        
                        break;
                    case DisplayState.SHOW2:
                        if (NeedColor)
                        {

                            //get color
                            int randomnumber = randomNum();
                            numberCombo[0] = randomnumber;

                            NPCBubble.sprite = RGB[randomnumber];
                            NeedColor = false;

                        }
                        else if (AmIwaiting())
                        {
                            //stay here
                        }
                        else displayState = DisplayState.SHOW3;
                        break;
                    case DisplayState.SHOW3:
                        if (NeedColor)
                        {

                            //get color
                            int randomnumber = randomNum();
                            numberCombo[0] = randomnumber;

                            NPCBubble.sprite = RGB[randomnumber];
                            NeedColor = false;

                        }
                        else if (AmIwaiting())
                        {
                            //stay here
                        }
                        else displayState = DisplayState.END;
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
                            }
                            else
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



}
