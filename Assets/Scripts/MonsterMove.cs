using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class MonsterMove : MonoBehaviour
{
    [SerializeField]
    private GameObject player, hostage1, hostage2, hostage3, hostage4, hostage5;

    NavMeshAgent agent;

    [SerializeField]
    LayerMask groundLayer, playerLayer;

    //patrol
    Vector3 destination;
    private bool walkPoint;

    [SerializeField]
    private float rangeNeg = 0;

    [SerializeField]
    private float rangePos = 143;

    [SerializeField]
    private float almostThere;

    private int timer, limbs = 14;
    private int distance = 30;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    private void OnCollisionEnter(Collision collision)
    {

        //if you hit an obstacle
        if (collision.gameObject.tag == "Player")
        {
            if (Random.Range(0, 100) % 5 == 0) { SceneManager.LoadScene("EndScene"); } // if the moster gets too close, theres a random chance it might kill you

            if (Input.GetKey(KeyCode.Space)) // if you're able to kill the monster
            {
                transform.position = new Vector3(Random.Range(-rangeNeg, rangePos), .87f, Random.Range(-rangeNeg, rangePos));

                Destroy(this.transform.GetChild(0));

                ScoreManager.score += 200;
                limbs -= 1;

                MessageShow.displayMessage = true;

                MessageShow.message = "You hit the monster.";
            }

        }
        if (collision.gameObject.tag == "Hostage")
        {
            Debug.Log("hit hostage");
        }
    }

            // Update is called once per frame
            void Update()
    {
        //once it runs out of limbs, the player wins
        if (limbs == 0) { SceneManager.LoadScene("EndScene"); }

        if (Vector3.Distance(player.transform.position, this.transform.position) < distance)
        {
            // transform.position = Vector3.MoveTowards(transform.position, player.transform.position, Time.fixedDeltaTime * 15);
            // agent.SetDestination(player.transform.position);
            // transform.LookAt(player.transform.position);
            // transform.eulerAngles = new Vector3(0, transform.eulerAngles.y, transform.eulerAngles.z);
        }

        else if (Vector3.Distance(hostage1.transform.position, this.transform.position) < distance)
        {
            agent.SetDestination(hostage1.transform.position);
            transform.LookAt(hostage1.transform.position);
        }
        else if (Vector3.Distance(hostage2.transform.position, this.transform.position) < distance)
        {
            agent.SetDestination(hostage2.transform.position);
            transform.LookAt(hostage2.transform.position);
        }
        else if (Vector3.Distance(hostage3.transform.position, this.transform.position) < distance)
        {
            agent.SetDestination(hostage3.transform.position);
            transform.LookAt(hostage3.transform.position);
        }
        else if (Vector3.Distance(hostage4.transform.position, this.transform.position) < distance)
        {
            agent.SetDestination(hostage4.transform.position);
            transform.LookAt(hostage4.transform.position);
        }
        else if (Vector3.Distance(hostage5.transform.position, this.transform.position) < distance)
        {
            agent.SetDestination(hostage5.transform.position);
            transform.LookAt(hostage5.transform.position);
        }
        else
        {
            timer++;

            Patrol();

            if (agent.speed == 0) walkPoint = false; //me trying to fix the issue of some of my fish not swimming 


            //every so often it will just randomly teleport
            if (timer % 5000 == 0)
            {
                transform.position = new Vector3(Random.Range(-rangeNeg, rangePos), .87f, Random.Range(-rangeNeg, rangePos));
            }
        }

    }

    void Patrol()
    {
        //have it first pick a location
        if (!walkPoint) SearchForDest();

        //if walkpoint is in a viable location, it will walk towards thta direction
        if (walkPoint) agent.SetDestination(destination);
       // Debug.Log(destination);

        //once it gets close to the end, changes destination
        if (Vector3.Distance(transform.position, destination) < almostThere) walkPoint = false;
    }

    void SearchForDest()
    {
        //sets a random location
        float x = Random.Range(-rangeNeg, rangePos);
        float z = Random.Range(-rangeNeg, rangePos);


        //gives it a new location to patrol / swim to
        destination = new Vector3(x, .87f, z);

        walkPoint = true;
    }
}