using UnityEngine;
using System.Collections;

public class Officesounds : MonoBehaviour {

    AudioSource Music = SoundManager.MusicPlayer;
    public AudioClip Office;
    // Use this for initialization
    void Start()
    {
        if (Music == null)
        {
            Music = SoundManager.MusicPlayer;
            MusicPlayer();
        }

        MusicPlayer();
    }

    // Update is called once per frame
    void Update()
    {
        if (Music == null)
        {
            Music = SoundManager.MusicPlayer;
            MusicPlayer();
        }
    }

    void MusicPlayer()
    {
        Music.clip = Office;
        Music.Play();
    }
}
