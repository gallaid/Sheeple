using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public static class GameStates {
 
    
    static int totalPopulation=15;

    
    static int population, belief;

    static Gamestate gameState;
    static Gamestate LastgameState;



    public static void StartUp()
    {
        LastgameState = gameState;
        gameState = Gamestate.BEGIN;
        belief = 50;
        population = 0;
    }
    public static SpawnLocation SpawnLocal=SpawnLocation.CultHouse;
    static bool bull=false;
    static bool male =false;

    public static void  CheckGameState()
    {
        CheckPop();
        CheckBelief();
    }
    public static Gamestate getgameState
    {
        get { return gameState; }
        set { gameState = value; }

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

    public static void LoseCheck()
    {
        if (belief <= 0)
        {
            //lose game load lose screen
        }
    }

    public static void checkWin()
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

    public static SpawnLocation SpawnLocation
    {
        get { return SpawnLocal; }
        set { SpawnLocal = value; }
    }
    static void CheckBelief()
    {
        if (belief <= 0)
        {
            //end game
        }
    }
    static void CheckPop()
    {
        if (population >= 15)
        {
            gameState = Gamestate.END;
        }
        else if (population >= 10)
            gameState = Gamestate.ADV;
        else if (population >= 5)
            gameState = Gamestate.MED;
        else
            gameState = Gamestate.BEGIN;

        CheckStateChange();
    }
    static void CheckStateChange()
    {
        if (LastgameState != gameState)
        {
            //gui change gamestate
            LastgameState = gameState;
        }
    }

}
