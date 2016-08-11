using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class SimonSays : MonoBehaviour {

    public int[] numberCombo;
   // public Text chatBubble;
    public int waitTime = 5;
    private bool changeNumber=true;
    public int RandomNumber;
    private int numberIndex=0;
    public int HowManyTimes=3;
    public bool PlayersTurn = false;
    public int numberInSequence = 0;
    
    private SpriteRenderer NPCBubble;
    public Sprite[] RGB;
    float transNPC = 1f;
    private SpriteRenderer PlayerBubble;
    public int numberHaveToWin=2;
    private int numberOfWins=0;
    public int numberCanFail=3;
    private int numberOfFails=0;
    private float transpc = 1f;

    public int PopulationIncrease=1;
    public int BeliefIncrease=5;
    public int BeliefDecrease=2;







    void Start()
    {
        //RandomNumber = numberGen();
        numberCombo = new int[HowManyTimes];
        //ChangeColor(); 
        SpriteRenderer[] NPCSprites = new SpriteRenderer[3];

        NPCSprites = GetComponentsInChildren<SpriteRenderer>();
        foreach(SpriteRenderer sprite in NPCSprites)
        {
            if (sprite.name == "ChatBubble")
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
    void Update()
    {
        Cheat();
        LogicGate();

    }
    IEnumerator WaitingForNextColor()
    {   
        yield return new WaitForSeconds(waitTime);
        if (numberIndex > numberCombo.Length-1)
        {
            for(int num = 0; num < HowManyTimes; num++)
            {
                print(numberCombo[num]);
            }
            print("Your Turn");
            PlayersTurn = true;
        }
        else
        {
            RandomNumber = numberGen();
            ChangeColorNPC();
            numberCombo[numberIndex] = RandomNumber;
            numberIndex++;
            changeNumber = true;
        }
        
    }
    private void ChangeColorNPC()
    {
       
        if (RandomNumber == 1)
        {
            NPCBubble.sprite = RGB[0];
        }else if (RandomNumber == 2)
        {
            NPCBubble.sprite = RGB[1];
        }
        else if (RandomNumber == 3)
        {
            NPCBubble.sprite = RGB[2];
        }
        else
        {
            
        }

    }
    private int numberGen()
    {
        return UnityEngine.Random.Range(1, 4);
    }
    private void PlayerTurn()
    {
        //print(numberInSequence);
        if (Input.anyKeyDown)
        {
            
            string keyDown = Input.inputString;
            if (keyDown == numberCombo[numberInSequence].ToString())
            {
                //correct key
                
                RandomNumber = Convert.ToInt32(keyDown);
                //print(RandomNumber + "boom");
                transpc = 1f;
                ChangeColorPlayer();
                numberInSequence += 1;
                
                print("rightkey");

            }
            else
            {
                PlayersTurn = false;
                print("you lose");
                changeNumber = true;
                numberIndex = 0;
                numberOfFails += 1;
                if (numberOfFails >= numberCanFail)
                {
                    Lose();
                }
            }
           
        }
        if (numberInSequence >= numberCombo.Length)
        {
            //numberOfWins += 1;
            // print(numberHaveToWin);
            numberIndex = 0;
            if (numberOfWins > numberHaveToWin)
            {
                print("inhere");
                winning();
            }
            else {
                //NPCGameManger NPCGM=GetComponent<NPCGameManger>();
                //NPCGM.checkifdoneSS();
                print("downhere");
                PlayersTurn = false;
                changeNumber = true;
                //StopAllCoroutines();
            }
           
        }
    }
    void ChangeColorPlayer()
    {
        if (RandomNumber == 1)
        {
            PlayerBubble.sprite = RGB[0];
        }
        else if (RandomNumber == 2)
        {
            PlayerBubble.sprite = RGB[1];
        }
        else if (RandomNumber == 3)
        {
            PlayerBubble.sprite = RGB[2];
        }
        else
        {

        }
    }
    void LogicGate()
    {
        if (PlayersTurn == false)
        {
            if (changeNumber == true)
            {
                changeNumber = false;
                NPCBubble.color = new Color(1f, 1f, 1f, 1f);
                transNPC = 1f;
                StartCoroutine(WaitingForNextColor());
            }
            else
            {
                //InvokeRepeating("GoTrasparentNPC", 1, .3f);
                GoTrasparentNPC();
            }
        }
        else {
            PlayerTurn();
            changeNumber = false;
            GoTransparentPlayer();
        } 
    }
    void GoTrasparentNPC()
    {
        transNPC -= 0.05f;
        NPCBubble.color = new Color(1f, 1f, 1f, transNPC);
    }
    void GoTransparentPlayer()
    {
        transpc -= 0.04f;
        PlayerBubble.color = new Color(1f, 1f, 1f, transpc);
    }
    void winning()
    {
        //gain follower convert

        //GetComponentInParent<NPCGameManger>().convert();


    }
    void Lose()
    {
        //lose belief dont gain followers no convert
        

        LeaveGame();
        
    }
    void LeaveGame()
    {
        GetComponentInParent<NPCGameManger>().GameEnd();
    }
    void Cheat()
    {
        if (Input.GetKeyDown(KeyCode.P))//win
        {
            PlayersTurn = true;
            changeNumber =false;
        }
        if (Input.GetKeyDown(KeyCode.L))
        {
            numberCanFail = numberOfFails;
        }
    }
}
