using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class SimonSays : MonoBehaviour {

    public int[] numberCombo;
    public Text chatBubble;
    public int waitTime = 5;
    private bool changeNumber=true;
    public int RandomNumber;
    private int numberIndex=0;
    public int HowManyTimes=3;
    public bool PlayersTurn = false;
    public int numberInSequence = 0;
    public SpriteRenderer Bubble;
    public Sprite[] RGB;
    

    void Start()
    {
        //RandomNumber = numberGen();
        numberCombo = new int[HowManyTimes];
        //ChangeColor(); 
    }
    void Update()
    {

        if (PlayersTurn == false)
        {
            if (changeNumber == true)
            {
                changeNumber = false;
                chatBubble.fontSize = 14;
                StartCoroutine(WaitingForNextColor());
            }
            else chatBubble.fontSize += 1;
        }
        else PlayerTurn();
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
            ChangeColor();
            numberCombo[numberIndex] = RandomNumber;
            numberIndex++;
            changeNumber = true;
        }
        
    }
    private void ChangeColor()
    {
        chatBubble.fontSize = 14;
        if (RandomNumber == 1)
        {
            chatBubble.text = "Red";
            Bubble.sprite = RGB[0];
        }else if (RandomNumber == 2)
        {
            chatBubble.text = "Blue";
            Bubble.sprite = RGB[1];
        }
        else if (RandomNumber == 3)
        {
            chatBubble.text = "Green";
            Bubble.sprite = RGB[0];
        }
        else
        {
            chatBubble.text = "Gold";
        }

    }
    private int numberGen()
    {
        return UnityEngine.Random.Range(1, 3);
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
                ChangeColor();
                numberInSequence += 1;

                print("rightkey");
                
                

            }
            else
            {
                PlayersTurn = false;
                print("you lose");
                changeNumber = true;
                numberIndex = 0;
            }
           
        }
        if (numberInSequence >= numberCombo.Length)
        {
            print("you this shit");
        }
    }
    void winning()
    {
        //gain follower
    }
}
