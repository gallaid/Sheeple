using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ButtonControl : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void PickPastholu()
    {
        GameStates.Bull= false;
        SceneManager.LoadScene("PasthuluCharacterPick");
    }
    public void PickBull()
    {
        GameStates.Bull = true;
        SceneManager.LoadScene("BullCharacterPick");

    }

    public void BacktoGodChoice()
    {
        SceneManager.LoadScene("GodChoiceStart");
    }
    public void PickMale()
    {
        GameStates.IsMale = true;
        SceneManager.LoadScene("GodRoom1");
    }
    public void PickFemale()
    {
        GameStates.IsMale = false;
        SceneManager.LoadScene("GodRoom1");

    }
}
