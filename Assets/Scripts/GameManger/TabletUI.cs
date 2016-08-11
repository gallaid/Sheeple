using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TabletUI : MonoBehaviour {

    public Slider PopSlider;
    public Slider BelSlider;
   
    public Canvas MissionStatus;


    void OnTriggerEnter2D(Collider2D other)
    {
        //print(other.gameObject.name);

        if (other.gameObject.tag == "Player") 
        {
            MissionStatus.enabled = true;
        }

    }
    void OnTriggerExit2D(Collider2D other)
    {
        print("hello");
        if (other.gameObject.tag == "Player")
        {
            MissionStatus.enabled = false;
        }
    }


    void Start()
    {
        MissionStatus = GameObject.FindGameObjectWithTag("UIGODROOM").GetComponent<Canvas>();

        Slider[] sliders = new Slider[2];

        sliders = MissionStatus.GetComponentsInChildren<Slider>();
        foreach (Slider slide in sliders)
        {
            print(slide.name);
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
        
        print(MissionStatus + " missionStatus");

    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            //GameStates gs = new GameStates();

           GameStates.Population += 4;
           GameStates.Belief += 7;
        }
        if (Input.GetKeyDown(KeyCode.O))
        {
            
            GameStates.Population -= 4;
            GameStates.Belief -= 7;
        }
        PopSlider.value = GameStates.Population;
        BelSlider.value = GameStates.Belief;

    }
        



}
