using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class NPCGameManger : MonoBehaviour {

    private SimonSaysTake2 simonsays;
    public GameObject converted;


    AudioSource SoundEffectSource;
    AudioSource Music;
    public AudioClip[] soundEffects = new AudioClip[5];



    // Use this for initialization
    void Start()
    {
        
        simonsays = GetComponent<SimonSaysTake2>();
        SoundEffectSource = SoundManager.SoundEffectPlayer;

    }

    void Update()
    {
        if (SoundEffectSource == null)
        {
            SoundEffectSource = SoundManager.SoundEffectPlayer;

        }
        
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
    public void convert()
    {
        Instantiate(converted, transform.position,Quaternion.identity);
        Destroy(gameObject);
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            chooseGame();

            SoundEffectSource.clip = soundEffects[RanNumb()];
            print(SoundEffectSource.clip);
            SoundEffectSource.Play();
           
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

    int RanNumb()
    {
        return Random.Range(0, 4);
    }
}
