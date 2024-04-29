using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FinalScoreSet : MonoBehaviour
{
    TextMeshProUGUI saved;
    TextMeshProUGUI killed;
    TextMeshProUGUI letDie;

    TextMeshProUGUI scoreThisRound;
    TextMeshProUGUI highscore;

    // Start is called before the first frame update
    void Start()
    {
        saved = transform.GetChild(8).GetComponent<TextMeshProUGUI>();
        killed = transform.GetChild(10).GetComponent<TextMeshProUGUI>();
        letDie = transform.GetChild(8).GetComponent<TextMeshProUGUI>();

        // PlayerPrefs.SetInt("highscore", 0);
        scoreThisRound = transform.GetChild(8).GetComponent<TextMeshProUGUI>();
        highscore = transform.GetChild(10).GetComponent<TextMeshProUGUI>();

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    // Update is called once per frame
    void Update()
    {
        saved.text = ScoreManager.hostagesSaved.ToString();
        killed.text = ScoreManager.hostagesDeadByYou.ToString();
        letDie.text = ScoreManager.hostagesDeadByMonster.ToString();


        if (ScoreManager.score > PlayerPrefs.GetInt("highscore"))
        {
            PlayerPrefs.SetInt("highscore", ScoreManager.score);
        }

        scoreThisRound.text = Mathf.RoundToInt(ScoreManager.score).ToString("0000");
        highscore.text = PlayerPrefs.GetInt("highscore").ToString("0000");
    }
}