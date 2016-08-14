using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class toStreet : MonoBehaviour
{

    void OnCollisionEnter2D(Collision2D thing)
    {
        if (thing.gameObject.tag == "Player")
        {
            
            SceneManager.LoadScene("StreetTest");
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

