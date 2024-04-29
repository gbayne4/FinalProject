using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceHostages : MonoBehaviour
{
    [SerializeField]
    private int HostageNumTimesFive;
    [SerializeField]
    public GameObject hostage1, hostage2, hostage3, hostage4, hostage5;

    // Start is called before the first frame update
    void Start()
    {
        ScoreManager.hostages = HostageNumTimesFive * 5;
        //generating the hostages throughout the map
        for (int i = 0; i < HostageNumTimesFive; i++)
        {
            //number is based on platform, lmk if theres an easier way to do this.
            Instantiate(hostage1, new Vector3(Random.Range(0, 245), 1, Random.Range(0, 245)), Quaternion.identity);
            Instantiate(hostage2, new Vector3(Random.Range(0, 245), 1, Random.Range(0, 245)), Quaternion.identity);
            Instantiate(hostage3, new Vector3(Random.Range(0, 245), 1, Random.Range(0, 245)), Quaternion.identity);
            Instantiate(hostage4, new Vector3(Random.Range(0, 245), 1, Random.Range(0, 245)), Quaternion.identity);
            Instantiate(hostage5, new Vector3(Random.Range(0, 245), 1, Random.Range(0, 245)), Quaternion.identity);

        }

    }

}
