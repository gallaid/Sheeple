using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TabletUI : MonoBehaviour {

    public Canvas MissionStatus;
    void OnTriggerEnter2D(Collider2D other)
    {
        //print(other.gameObject.name);

        if (other.gameObject.name == "Player")
        {
            MissionStatus.enabled = true;
        }

    }
    void OnTriggerExit2D(Collider2D other)
    {
        print("hello");
        if (other.gameObject.name == "Player")
        {
            MissionStatus.enabled = false;
        }
    }
    public Slider PopSlider;
    public Slider BelSlider;
    GameStates gs;

    void Start()
    {

        GameStates gs = new GameStates();
        print(gs);
        print(gs.Population);
        PopSlider.maxValue = 15;
        BelSlider.maxValue = 100;
        PopSlider.value = gs.Population;
        BelSlider.value = gs.Belief;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            GameStates gs = new GameStates();
            gs.Population += 4;
            gs.Belief += 7;
        }
        if (Input.GetKeyDown(KeyCode.O))
        {
            GameStates gs = new GameStates();
            gs.Population -= 4;
            gs.Belief -= 7;
        }

    }



}
