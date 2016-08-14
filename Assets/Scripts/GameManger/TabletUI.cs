using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TabletUI : MonoBehaviour {

    public Slider PopSlider;
    public Slider BelSlider;
   
    public Canvas MissionStatus;

    AudioSource SoundEffectSource;
    AudioSource Music;
    public AudioClip[] soundEffects=new AudioClip[0];
   


    void OnTriggerEnter2D(Collider2D other)
    {
        //print(other.gameObject.name);

        if (other.gameObject.tag == "Player") 
        {
            MissionStatus.enabled = true;
        }
        SoundEffectSource.clip = soundEffects[0];
        SoundEffectSource.Play();

    }
    void OnTriggerExit2D(Collider2D other)
    {
       // print("hello");
        if (other.gameObject.tag == "Player")
        {
            MissionStatus.enabled = false;
        }
        SoundEffectSource.clip = soundEffects[0];
        SoundEffectSource.Play();
    }


    void Start()
    {
        MissionStatus = GameObject.FindGameObjectWithTag("UIGODROOM").GetComponent<Canvas>();

        Slider[] sliders = new Slider[2];

        sliders = MissionStatus.GetComponentsInChildren<Slider>();
        foreach (Slider slide in sliders)
        {
            //print(slide.name);
            if (slide.name == "PopulationSlider")
            {
                PopSlider = slide;
            }
            else if (slide.name == "BeliefSlider")
            {
                BelSlider = slide;
            }
            
        }

        
       
       // print(gs.Population);
        PopSlider.maxValue = 15;
        BelSlider.maxValue = 100;
        PopSlider.value = GameStates.Population;
        BelSlider.value = GameStates.Belief;
        MusicPlayer();
        //print(Music.name + " missionStatus");

    }
    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.P))
        //{
        //    //GameStates gs = new GameStates();

        //    GameStates.Population += 4;
        //    GameStates.Belief += 7;
        //}
        //if (Input.GetKeyDown(KeyCode.O))
        //{

        //    GameStates.Population -= 4;
        //    GameStates.Belief -= 7;
        //}
        PopSlider.value = GameStates.Population;
        BelSlider.value = GameStates.Belief;
        if (SoundEffectSource == null || Music == null)
        {
            SoundEffectSource = SoundManager.SoundEffectPlayer;
            Music = SoundManager.MusicPlayer;
            MusicPlayer();
        }

    }
    void MusicPlayer()
    {
        SoundEffectSource = SoundManager.SoundEffectPlayer;
        Music = SoundManager.MusicPlayer;

        if (GameStates.getgameState == Gamestate.BEGIN)
        {
            Music.clip = soundEffects[1];
            Music.Play();
        }
        else if (GameStates.getgameState == Gamestate.MED)
        {
            Music.clip = soundEffects[2];
            Music.Play();

        }
        else if (GameStates.getgameState == Gamestate.ADV || GameStates.getgameState == Gamestate.END)
        {
            if (GameStates.Bull == true)
            {
                Music.clip = soundEffects[3];
                Music.Play();
            }
            else
            {
                Music.clip = soundEffects[4];
                Music.Play();
            }
        }
    }




}
