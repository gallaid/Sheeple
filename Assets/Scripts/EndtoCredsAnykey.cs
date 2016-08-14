using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class EndtoCredsAnykey : MonoBehaviour {



    bool wait=false;
    void Start()
    {
        StartCoroutine(waitforseconds());
    }
	void Update () {
        if (Input.anyKeyDown)
        {
            if (!wait)
            {
                SceneManager.LoadScene("Credits");
            }

        }
	}


    IEnumerator waitforseconds()
    {
        yield return new WaitForSeconds(5);
        wait = true;
    }
}
