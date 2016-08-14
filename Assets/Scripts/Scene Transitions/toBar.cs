using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class toBar : MonoBehaviour
{
    

    void OnTriggerEnter(Collider thing)
    {
        if (thing.gameObject.tag == "Player")
        {
            GameStates.SpawnLocation = SpawnLocation.Bar;
            SceneManager.LoadScene("Bar");
            DoorSound();
        }

    }
    public AudioClip door;
    void DoorSound()
    {
        AudioSource soundseffect = SoundManager.SoundEffectPlayer;
        soundseffect.clip = door;
        soundseffect.Play();

    }

}

