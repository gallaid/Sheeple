using UnityEngine;
using System.Collections;


[RequireComponent (typeof(NavMeshAgent))]
public class navMeshEnemy : MonoBehaviour {

    NavMeshAgent perrytheplatapus;

    public float stepdist;

    public enum agentstates
    {
        FollowPlayer,
        Wait,
        Wander, 
        drinkheavilyandregretdecisions
    }

    public agentstates currentState;


    void Start()
    {
        perrytheplatapus = transform.GetComponent<NavMeshAgent>();
    }

    bool waitforwander;
    public float wanderwaitTime;

    void Update()
    {
        switch (currentState)
        {
            case agentstates.FollowPlayer:
                perrytheplatapus.SetDestination(PlayerController.pcontrol.transform.position);
                break;
            case agentstates.Wander:
                if (waitforwander)
                {
                    StartCoroutine(wandering());
                }

                break;
            case agentstates.Wait:
                perrytheplatapus.destination = transform.position;
                break;
        }

    }

    IEnumerator wandering()
    {
        waitforwander = false;
        float x = Random.Range(-1.0f, 1.0f);
        float z = Random.Range(-1.0f, 1.0f);

        Vector3 adddist = new Vector3(x, 0, z);
        adddist = adddist.normalized * stepdist;

        perrytheplatapus.SetDestination(adddist + transform.position);


        yield return new WaitForSeconds(wanderwaitTime);
        waitforwander = true;
    }

}
