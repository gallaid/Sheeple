using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class toOffice : MonoBehaviour
{

    void OnTriggerEnter(Collider thing)
    {
        if (thing.gameObject.tag == "Player")
        {
            GameStates.SpawnLocation = SpawnLocation.Office;
            SceneManager.LoadScene("Office1");
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

