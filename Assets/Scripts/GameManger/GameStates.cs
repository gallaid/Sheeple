using UnityEngine;
using System.Collections;

public class GameStates : MonoBehaviour {
    public static GameStates Instance {
        get { return _instance; }
    }

    private static GameStates _instance;
    private GameObject GameManagerObj;

    
    private static int population, belief;
    enum Gamestate {MENU, WIN, BEGIN, MED, ADV};
    Gamestate gameState;
    // Use this for initialization
    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
        if (_instance == null)
        {
            _instance = this;
        }
        else if(_instance != this)
        {
            Destroy(this);
        }
        GameManagerObj = this.gameObject;
    }
    
    void Start () {
        population = 1;
        belief =50;
        Gamestate gameState = Gamestate.BEGIN;
	}
	
	// Update is called once per frame
	void Update () {


	}
    void ChangeGameState()
    {
        if (population > 15)
            gameState = Gamestate.ADV;
        else if (population > 5)
            gameState = Gamestate.MED;
        else
            gameState = Gamestate.BEGIN;
    }
    Gamestate getgameState()
    {
        return gameState;

    }

    public int Population
    {
        get{ return population; }
        set { population = value; }
    }

    public int Belief
    {
        get { return belief; }
        set { belief = value; }
    }

    public void LoseCheck()
    {
        if (belief <= 0)
        {
            //lose game load lose screen
        }
    }
    public GameObject GameManager
    {
        get { return GameManagerObj; }
    }
}
