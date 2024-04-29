using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InOutScreen : MonoBehaviour
{
    private int timer = 0;

    [SerializeField]
    private GameObject monster;
    private void Start()
    {
        monster.SetActive(false);
    }
    void Update()
    {
        timer++;
        Debug.Log(timer);

        if (timer % 1000 == 0)
        { monster.SetActive(true); }
        if (timer % 1005 == 0)
        { monster.SetActive(false); }
        if (timer % 1010 == 0)
        { monster.SetActive(true); }
        if (timer % 1015 == 0)
        { monster.SetActive(false); }
        if (timer % 1020 == 0)
        { monster.SetActive(true); }
        if (timer % 1025 == 0)
        { monster.SetActive(false); }
    }
}