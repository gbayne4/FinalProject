using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MonsterMove : MonoBehaviour
{
    GameObject player;

    NavMeshAgent agent;

    [SerializeField]
    LayerMask groundLayer, playerLayer;

    //patrol
    Vector3 destination;
    private bool walkPoint;

    [SerializeField]
    private float rangeNeg = 0;

    [SerializeField]
    private float rangePos = 245;

    [SerializeField]
    private float almostThere;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        Patrol();

        if (agent.speed == 0) walkPoint = false; //me trying to fix the issue of some of my fish not swimming 
    }


    //if it pumps into an obstacle, new destination
    private void OnCollisionEnter(Collision collision)
    {
        //avoid obstacles, might get rid of bc I'm not sure if it is even doing anything
        if (collision.gameObject.tag == "Obstacle") walkPoint = false;

    }

    void Patrol()
    {
        //have it first pick a location
        if (!walkPoint) SearchForDest();

        //if walkpoint is in a viable location, it will walk towards thta direction
        if (walkPoint) agent.SetDestination(destination);

        //once it gets close to the end, changes destination
        if (Vector3.Distance(transform.position, destination) < almostThere) walkPoint = false;
    }

    void SearchForDest()
    {
        //sets a random location
        float x = Random.Range(-rangeNeg, rangePos);
        float z = Random.Range(-rangeNeg, rangePos);


        //gives it a new location to patrol / swim to
        destination = new Vector3(transform.position.x + x, transform.position.y, transform.position.z + z);

        //keeps fish from going off the board
        if (Physics.Raycast(destination, Vector3.down, groundLayer))
        {
            walkPoint = true;
        }
    }
}