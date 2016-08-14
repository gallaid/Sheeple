using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GamePauseMenu : MonoBehaviour {

    public static GamePauseMenu _instance;

    Canvas pausemenu;
    public Sprite CitadelUnlocked;


    public Image Upgrade;


    void Awake()
    {
        if (!_instance)
        {
            _instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }


        DontDestroyOnLoad(this.gameObject);
    }
	void Start () {
        pausemenu = GetComponent<Canvas>();
        
	
	}
	
	// Update is called once per frame
	void Update () {
        if (pausemenu == null)
        {
            pausemenu =GetComponent<Canvas>();
        }



        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (pausemenu.enabled == false)
            {
                Pause();
            }else if(pausemenu.enabled == true){
                Time.timeScale = 1;
                pausemenu.enabled = false;
                Upgrade.enabled = false;
            }

        }

        if (GameStates.CheckPop())
        {
            if (GameStates.Population >= 15)
            {
                Upgrade.sprite = CitadelUnlocked;
            }
            Upgrade.enabled = true;
            Pause();
        }

	
	}

    void Pause()
    {
        
        Time.timeScale = 0;
        pausemenu.enabled = true;
    }
}
