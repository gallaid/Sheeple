using UnityEngine;
using System.Collections;

public class GameStates : MonoBehaviour {

    private int population; // ,belief
    enum gamestates {MENU, WIN, BEGIN, MED, ADV};
    gamestates gameState;
    // Use this for initialization
    void Start () {
        population = 1;
        //belief = 0;
        gamestates gameState = gamestates.BEGIN;
	}
	
	// Update is called once per frame
	void Update () {
        if (population > 15)
            gameState = gamestates.ADV;
        else if (population > 5)
            gameState = gamestates.MED;
        else
            gameState = gamestates.BEGIN;

	
	}

    int getPopulation()
    {
        return population;
    }

    void setPopulation(int p)
    {
        population = p;
    }

    void addPopulation(int p)
    {
        population += p;
    }

    //int getBelief()
    //{
    //    return belief;
    //}

    //void setBelief(int b)
    //{
    //    belief = b;
    //}

    //void addBelief(int b)
    //{
    //    belief += b;
    //}
}
