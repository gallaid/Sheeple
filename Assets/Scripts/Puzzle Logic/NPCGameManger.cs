using UnityEngine;
using System.Collections;

public class NPCGameManger : MonoBehaviour {

    public SimonSays simonsays;
    public GameObject converted;
    public int numberHaveToWinSS = 5;
    private int numberOfWinsSS = 0;
    public int numberCanFailSS = 3;
    private int numberOfFailsSS = 0;



    // Use this for initialization
    void Start()
    {
        
        simonsays = GetComponent<SimonSays>();

    }

    void Update()
    {
        //chooseGame();
    }
    void chooseGame()
    {
        int randomNumber = Random.Range(1, 2);
        if (randomNumber == 1)
        {
            //simon says
            simonsays.enabled = true;

        }
        else
        {
            //shapes
        }
    }
    public void GameEnd()
    {
        simonsays.enabled = false;
        
        //symbols.enabled=false;
    }
    public void convert()
    {
        Instantiate(converted, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
    public void checkifdoneSS()
    {
        simonsays.enabled = false;
        numberOfWinsSS++;
        print(numberHaveToWinSS+"numberHavetowinNPC");
        print(numberOfWinsSS+"numberofwins");

        if (numberOfWinsSS >= numberHaveToWinSS)
        {
            
            
            //convert();
        }else
        {
            simonsays.enabled = true;
        }
    }
}
