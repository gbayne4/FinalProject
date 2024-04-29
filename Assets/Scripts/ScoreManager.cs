using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour
{
    public static int hostages, hostagesDeadByMonster = 0, hostagesDeadByYou = 0, hostagesSaved = 0, score = 0, timer = 0; //resets the scores

    void Update()
    {
        timer++;
        timer = (1 / timer) * 1000;

        if (hostages <= 0)
        {
            { SceneManager.LoadScene("EndScene"); }
        }
    }
}
