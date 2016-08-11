using UnityEngine;
using System.Collections;

public class NPCGameManger : MonoBehaviour {

    private SimonSaysTake2 simonsays;
    public GameObject converted;




    // Use this for initialization
    void Start()
    {
        
        simonsays = GetComponent<SimonSaysTake2>();

    }

    void Update()
    {
        //chooseGame();
    }
    void chooseGame()
    {
        simonsays.enabled = true;
        //int randomNumber = Random.Range(1, 2);
        //if (randomNumber == 1)
        //{
        //    //simon says
        //    simonsays.enabled = true;

        //}
        //else
        //{
        //    //shapes
        //}
    }

    public void winGame()
    {

        GameStates.Belief += 5;
        GameStates.Population += 1;
        GameStates.CheckGameState();
        
        convert();
        GameEnd();
    }
    
    public void loseGame()
    {
        GameStates.Belief -= 5;
        GameEnd();
    }
    public void GameEnd()
    {
        simonsays.enabled = false;
        
        //symbols.enabled=false;
    }
    public void convert()
    {
        Instantiate(converted, transform.position,transform.rotation);
        Destroy(gameObject);
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            chooseGame();
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            simonsays.turnoff();
            GameEnd();
        }
    }
}
