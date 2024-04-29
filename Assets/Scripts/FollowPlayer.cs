using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class FollowPlayer : MonoBehaviour
{
    [SerializeField]
    private GameObject player;
    private int speed = 15;

    [SerializeField]
    public GameObject hostage1, hostage2, hostage3, hostage4, hostage5;
    [SerializeField]
    public GameObject hostage1dead, hostage2dead, hostage3dead, hostage4dead, hostage5dead;


    private bool following = false, dead = false;
    private void OnCollisionEnter(Collision collision)
    {

        //if you hit an obstacle
        if ((collision.gameObject.tag == "Player") && (!following))
        {
           // Debug.Log("hitting");
            if (Input.GetKey(KeyCode.E))
            {
                following = true;
                Debug.Log("follow player");
                ScoreManager.hostages -= 1;
                ScoreManager.hostagesSaved += 1;

                MessageShow.displayMessage = true;

                MessageShow.message = "Hostage saved.";
            }

            if (Input.GetKey(KeyCode.Space) && !dead)
            {
                dead = true;
                Death();
                ScoreManager.hostages -= 1;
                ScoreManager.hostagesDeadByYou += 1;

                MessageShow.displayMessage = true;

                MessageShow.message = "You killed a hostage.";
            }


        }

        if ((collision.gameObject.tag == "Monster") && !dead)
        {
            dead = true;
            Death();
            ScoreManager.hostages -= 1;
            ScoreManager.hostagesDeadByMonster += 1;

            MessageShow.displayMessage = true;

            MessageShow.message = "A hostage just died";
        }
    }

    private void Update()
    {
        if (following) { FollowingPlayer();}
    }
    void FollowingPlayer()
    {
        Destroy(gameObject);
        //transform.position = Vector3.MoveTowards(transform.position, player.transform.position, Time.fixedDeltaTime * speed);
        following = true;
    }

    void Death()
    {
        Destroy(gameObject);

        if (this.gameObject == hostage1)
        { Instantiate(hostage1dead, new Vector3(transform.position.x, .1f, transform.position.z), Quaternion.identity); }

        else if (this.gameObject == hostage2)
        { Instantiate(hostage2dead, new Vector3(transform.position.x, .1f, transform.position.z), Quaternion.identity); }

        else if (this.gameObject == hostage3)
        { Instantiate(hostage3dead, new Vector3(transform.position.x, .1f, transform.position.z), Quaternion.identity); }

        else if (this.gameObject == hostage4)
        { Instantiate(hostage4dead, new Vector3(transform.position.x, .1f, transform.position.z), Quaternion.identity); }

        else if (this.gameObject == hostage4)
        { Instantiate(hostage4dead, new Vector3(transform.position.x, .1f, transform.position.z), Quaternion.identity); }

    }
}
