using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameStates : MonoBehaviour {
    public static GameStates Instance {
        get { return _instance; }
    }

    private static GameStates _instance;
    private GameObject GameManagerObj;
    private int totalPopulation=15;

    
    public static int population, belief;
   public enum Gamestate {MENU, WIN, BEGIN, MED, ADV};
    Gamestate gameState;
    public static bool bull=true;
    public static bool male = true;
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
        population = 0;
        belief = 50;
        Gamestate gameState = Gamestate.BEGIN;
	}
	
	// Update is called once per frame
	void Update () {
        print(belief);

	}
    void ChangeGameState()
    {
        if (population >= 10)
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

    public static int Population
    {
        get{ return population; }
        set { population = value; }
    }
    public static bool Bull
    {
        get { return bull; }
        set { bull = value; }
    }

    public static int Belief
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

    public void checkWin()
    {
        if (population == totalPopulation && belief > 0)
        {
            //able to go to the chapel
        }
    }
    public static bool IsMale
    {
        get { return male; }
        set { male = value; }
    }



}
