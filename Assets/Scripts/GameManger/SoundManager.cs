using UnityEngine;
using System.Collections;

public class SoundManager : MonoBehaviour {

    public static SoundManager _instancesound;
    static AudioSource Music;
   static AudioSource SoundEffect;
    // Use this for initialization


    void Awake()
    {
        if (!_instancesound)
        {
            _instancesound = this;
        }
        else
        {
            Destroy(this.gameObject);
        }


        DontDestroyOnLoad(this.gameObject);

        getAudiosources();
	
	}
	
	// Update is called once per frame
	void Update () {
        if (SoundEffect == null||Music==null)
        {
            getAudiosources();
        }

        //print(Music);
	}

    void getAudiosources()
    {
        AudioSource[] audioscorces = new AudioSource[2];
        audioscorces= GetComponentsInChildren<AudioSource>();

        foreach(AudioSource getas in audioscorces)
        {
            if (getas.name == "Music")
            {
                Music = getas;
            }else if (getas.name == "Soundeffect")
            {
                SoundEffect = getas;
            }
        }
    }

    public static AudioSource MusicPlayer
    {
        get { return Music; }
        

    }
    public static AudioSource SoundEffectPlayer
    {
        get { return SoundEffect; }
    }
}
