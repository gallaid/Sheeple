using UnityEngine;
using System.Collections;
using System;
using UnityEngine.SceneManagement;

public class SimonSaysTake2 : MonoBehaviour {

    public int[] numberCombo;
    public SpriteRenderer NPCBubble;
    public SpriteRenderer PlayerBubble;
    public Sprite[] RGB;

    bool waiting;

    public int Waittime;

    public int colorindex;
    public int Guessespreturn;

    private float AlphaforNPC = 1f;
    private float AlphaforPC = 1f;
    public bool NPCTurn=true;

    public int pcGuess = 0;

    public int timesToWin = 3;
    public int wins = 0;

    public int timesToLose = 3;
    public int losecounter = 0;

    public int populationgain;

    public bool bossbattle;
    public bool is3d;

    


    // Use this for initialization
    void Start () {
        numberCombo = new int[Guessespreturn];

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
            if (pic.name == "Speech Bubble")
            {
                //print("Found CB");
                PlayerBubble = pic;
            }

        }
        NPCBubble.enabled = true;
        PlayerBubble.enabled = true;

    }
	
	// Update is called once per frame
	void Update () {
        WhosTurnIsIt();
        DisapearOverTime();
        DIsapearOverTimePC();

        if (NPCBubble.enabled == false)
        {
            NPCBubble.enabled = true;
        }
        if (PlayerBubble.enabled == false)
        {
            PlayerBubble.enabled = true;
        }
	}

    void WhosTurnIsIt()
    {
        if (wins < timesToWin)
        {
            if (NPCTurn)
            {
                NPCRunThrough();
            }
            else
            {
                // print("pcrun");
                PCRunThrough();
            }
        }
        else win();

    }

    void NPCChoiceColor()
    {
        if (waiting)
        {
            //spennd time here


        }
        else
        {
            StartCoroutine(Wait());
            int randomnumber = randomNum();
            numberCombo[colorindex] = randomnumber;

            NPCBubble.sprite = RGB[randomnumber];
            NPCBubble.color = new Color(1f, 1f, 1f, 1f);
            AlphaforNPC = 1f;

            colorindex++;
        }

    }


    void NPCRunThrough()
    {
        if (colorindex >= Guessespreturn)
        {
            pcGuess = 0;
            NPCTurn = false;
            for (int num = 0; num < Guessespreturn; num++)
            {
                print(numberCombo[num]+" NPC Number");
            }

        }
        else NPCChoiceColor();
    }

    void PCRunThrough()
    {
        if (wins < timesToWin)
        {


            if (losecounter < timesToLose)
            {


                if (pcGuess >= Guessespreturn)
                {

                    NPCTurn = true;
                    colorindex = 0;


                }
                else PlayerGuesses();
            }
            else lose();
        }
        else win();
    }

    void PlayerGuesses()
    {

        //print(numberCombo[pcGuess]);
        if (Input.anyKeyDown)
        {

            string keyDown = Input.inputString;
            print(keyDown+" keydown");
            if (keyDown == numberCombo[pcGuess].ToString())
            {//correct

                int number = Convert.ToInt32(keyDown);
                
               // print(number);
                PlayerBubble.sprite = RGB[number];
                AlphaforPC = 1f;
                pcGuess++;


                if (pcGuess >= Guessespreturn)
                {
                    wins++;

                }


            }
            else
            {
                pcGuess = Guessespreturn;
                PlayerBubble.sprite = RGB[0];
                losecounter++;
            }

        }
    }

    void win()
    {
        if (bossbattle)
        {
            if (GameStates.Bull)
            {
                SceneManager.LoadScene("BullEnd");
            }
            else SceneManager.LoadScene("PasthuluEnd");
        }
        NPCBubble.enabled = false;
        PlayerBubble.enabled = false;
        turnoff();
        if (is3d)
        {
            GetComponent<NPCGameManger>().winGame(populationgain);
        }
        else
        {
            GetComponent<NPCGameManger2d>().winGame(populationgain);
        }
        
    

    }
    void lose()
    {
        turnoff();
        GetComponent<NPCGameManger>().loseGame();

    }
   public void turnoff()
    {
        NPCBubble.enabled = false;
        PlayerBubble.enabled = false;
    }

    int randomNum() { return UnityEngine.Random.Range(1, 4); }

    IEnumerator Wait()
    {
        waiting = true;
        yield return new WaitForSeconds(Waittime);
        //print("afterwait");
        waiting= false;
    }
    void DisapearOverTime()
    {
        AlphaforNPC -= Time.deltaTime;
        NPCBubble.color = new Color(1f, 1f, 1f, AlphaforNPC);
        //PlayerBubble.color = new Color(1f, 1f, 1f, AlphaforNPC*.5f);

        //if (NPCTurn)
        //{
        //    AlphaforNPC -= Time.deltaTime;
        //    NPCBubble.color = new Color(1f, 1f, 1f, AlphaforNPC);
        //}
        //else
        //{
        //    AlphaforNPC = 1;
        //    NPCBubble.color = new Color(1f, 1f, 1f, AlphaforNPC);
        //}


    }
    void DIsapearOverTimePC()
    {
        AlphaforPC -= Time.deltaTime*.5f;
        PlayerBubble.color = new Color(1f, 1f, 1f, AlphaforPC);
    }
    


}
