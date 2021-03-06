﻿using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class NPCGameManger2d: MonoBehaviour {

    private SimonSaysTake2 simonsays;
    // public GameObject converted;

    AudioSource SoundEffectSource=SoundManager.SoundEffectPlayer;

    public AudioClip[] soundEffects = new AudioClip[5];


    // Use this for initialization
    void Start()
    {
        
        simonsays = GetComponent<SimonSaysTake2>();

    }

    void Update()
    {

        if (SoundEffectSource == null)
        {
            SoundEffectSource = SoundManager.SoundEffectPlayer;
        }
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

    public void winGame(int populationgain)
    {

        GameStates.Belief += populationgain*5;
        GameStates.Population += populationgain;
        //convert();
        GameEnd();
    }
    
    public void loseGame()
    {
        GameStates.Belief -= 10;
        GameEnd();
    }
    public void GameEnd()
    {
        if (GameStates.Belief <= 0)
        {
            if (GameStates.Bull)
            {
                SceneManager.LoadScene("BullLose");
            }
            else
            {
                SceneManager.LoadScene("PasthuluLose");
            }
        }
        simonsays.enabled = false;
        
        //symbols.enabled=false;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            SoundEffectSource.clip = soundEffects[RanNumb()];

            SoundEffectSource.Play();
            chooseGame();
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            GameEnd();
        }
    }




    int RanNumb()
    {
        return Random.Range(0, 4);
    }
}
